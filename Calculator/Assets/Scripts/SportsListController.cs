
using UnityEngine;
using UnityEngine.UI;

public class SportsListController : MonoBehaviour {

    [SerializeField]
    int totalSportNum;
    Sports[] list;
    [SerializeField]
    bool[] activeList;

    public void SetList(int index, Sports sport)
    {
        list[index] = sport;;
    }

    public void SetActiveList(int index,bool state)
    {
        activeList[index] = state;
    }

    private void Awake()
    {
        list = new Sports[totalSportNum];
        activeList = new bool[totalSportNum];
        for (int i = 0; i < totalSportNum; i++) {
            activeList[i] = false;
        }
    }

    public void UpdateResult()
    {
        float result = 0f;
        for (int i = 0; i < totalSportNum; i++) {
            if (activeList[i]) {
                result += (list[i].Ticket + list[i].Live - list[i].Cost);
            }
        }
        GetComponent<Text>().text = result.ToString();
    }
}
