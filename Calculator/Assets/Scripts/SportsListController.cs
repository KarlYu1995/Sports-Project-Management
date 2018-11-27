using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SportsListController : MonoBehaviour
{

    [SerializeField]
    int totalSportNum;
    Sports[] list;
    //[SerializeField]
    bool[] activeList;

    //All number in thousand(e.g:500->500,000 dollar)
    //初期値の宣言と初期化
    [SerializeField]
    float sponsor = 500f;
    [SerializeField]
    float contribution = 1800f;
    [SerializeField]
    float[] net = { 2000f, 3000f };
    [SerializeField]
    float goods = 500f;
    [SerializeField]
    float advertisement = 4000f;
    [SerializeField]
    float otherCost = 1000f;
    [SerializeField]
    float formOneBase = 3500f;
    [SerializeField]
    float formTwoBase = 4500f;
    //表示項目
    [SerializeField]
    Text groupOneResultText;
    [SerializeField]
    Text groupTwoResultText;
    [SerializeField]
    Text totalCostResultText;
    [SerializeField]
    Text totalTicketResultText;
    //変色用引数
    float lastFormOneResult = 0f;
    float lastFormTwoResult = 0f;
    float lastCostResult = 0f;
    float lastTicketResult = 0f;

    //スポーツリスト
    public void SetList(int index, Sports sport)
    {
        list[index] = sport;
    }

    //押されていれば参入する関数
    public void SetActiveList(int index, bool state)
    {
        activeList[index] = state;
    }

    private void Awake()//押される状態
    {
        list = new Sports[totalSportNum];
        activeList = new bool[totalSportNum];
        for (int i = 0; i < totalSportNum; i++)
        {
            activeList[i] = false;
        }
        UpdateResult(false);
    }

    //あらゆる計算の集合
    public void UpdateResult(bool changeColor)
    {//まずは命名から
        float totalLive = 0f;
        float formOneResult = 0f;
        float formTwoResult = 0f;
        float weightedTotalLive = 0f;
        float totalCost = 0f;
        float totalTicket = 0f;
        var testList = new List<Test> { };//人気順位？

        for (int i = 0; i < totalSportNum; i++)
        {
            if (activeList[i])
            {
                totalLive += list[i].Live;//グループ１の放映権
                testList.Add(new Test(i, list[i].Popularity));//人気順位
                if (list[i].Location == 2 && list[i].Location == 6)//開催地のコストとチケットoff
                {
                    totalCost += list[i].Cost * 0.8f;
                    totalTicket += list[i].Ticket * 0.9f;
                }
                else if(list[i].Location == 4 && list[i].Location == 5){
                    totalCost += list[i].Cost * 0.8f;
                }
                else
                {
                    totalCost += list[i].Cost;
                    totalTicket += list[i].Ticket;
                }
            }
        }


        var topTenPopularityIndex = testList.ToLookup(s => s.popularity, s => s.index).OrderBy(s => s.Key).Take(Mathf.Min(15, testList.Count));//人気度上位１０のグループ選択（未実現）
        int count = 0;
        List<int> topTenIndexes = new List<int> { };
        foreach (IGrouping<int, int> i in topTenPopularityIndex)
        {
            if (count < 10)
            {
                weightedTotalLive += i.Key * 0.4f;
                topTenIndexes.Add(i.ToList()[0]);//これはなんだろう。。
            }
            else
            {
                weightedTotalLive += i.Key * 0.3f;
            }
            count++;
        }

        formOneResult = formOneBase + 0.5f * totalLive + net[0];//グループ1の放映権計算式
        formTwoResult = formTwoBase + weightedTotalLive + net[1];//グループ２の放映権計算式
        groupOneResultText.text = "Group1 : " + formOneResult.ToString();//結果表示
        groupTwoResultText.text = "Group2 : " + formTwoResult.ToString();//結果表示
        totalCostResultText.text = "Total Cost : " + totalCost.ToString();//結果表示
        totalTicketResultText.text = "Total Ticket : " + totalTicket.ToString();//結果表示
        if (changeColor)//色を変える操作
        {
            CompareAndChangeColor(groupOneResultText, lastFormOneResult, formOneResult, Color.red, Color.green);//色の変更
            CompareAndChangeColor(groupTwoResultText, lastFormTwoResult, formTwoResult, Color.red, Color.green);//色の変更
            CompareAndChangeColor(totalCostResultText, lastCostResult, totalCost, Color.green, Color.red);//色の変更
            CompareAndChangeColor(totalTicketResultText, lastTicketResult, totalTicket, Color.red, Color.green);//色の変更

            lastFormOneResult = formOneResult;//色変更の対比
            lastFormTwoResult = formTwoResult;//色変更の対比
            lastCostResult = totalCost;//色変更の対比
            lastTicketResult = totalTicket;//色変更の対比
        }
    }



    void CompareAndChangeColor(Text targetText, float lastvalue, float thisValue, Color targetColor, Color otherColor)//色変更の関数
    {//if lastvalue > thisvulue Change targetText to TargetColor
        if (lastvalue > thisValue)
        {
            targetText.color = targetColor;
        }
        else
        {
            targetText.color = otherColor;
        }
    }
}//計算集合体終わり



public class Test//人気度計算用の並べ替え？
{
    public int popularity;
    public int index;
    public Test(int index, int popularity)
    {
        this.popularity = popularity;
        this.index = index;
    }
}

