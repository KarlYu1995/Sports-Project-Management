using UnityEngine;
using UnityEngine.UI;

public class SportButtonController : MonoBehaviour {

    [SerializeField]
    float cost;
    [SerializeField]
    float ticket;
    [SerializeField]
    float live;
    [SerializeField]
    string location;
    [SerializeField]
    int index;
    [SerializeField]
    SportsListController list;
    Sports sport;

	// Use this for initialization
	void Start () {
        sport = new Sports(cost, ticket, live, location);
        GetComponent<Button>().onClick.AddListener(addThisSportToList);
	}

    void addThisSportToList() {
        list.SetList(index,sport);
    }
}
