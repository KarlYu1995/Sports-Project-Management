
using UnityEngine;
using UnityEngine.UI;

public class SportsListController : MonoBehaviour {

    //[SerializeField]
    Sports[] list;

    public void SetList(int index, Sports sport)
    {
        list[index] = sport;
        UpdateResult();
    }

    private void Start()
    {
        list = new Sports[1];
    }

    void UpdateResult()
    {
        float result = 0f;
        foreach (Sports sport in list) {
            result += (sport.Ticket + sport.Live - sport.Cost);
        }
        GetComponent<Text>().text = result.ToString();
    }
}
