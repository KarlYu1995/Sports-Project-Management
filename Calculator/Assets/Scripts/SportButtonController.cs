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
    bool currentActiveState = false;//このSportsがリストに入ているならtrueそうでないならfalse
    

	void Start () {
        sport = new Sports(cost, ticket, live, location);
        GetComponent<Image>().color = Color.gray;
        GetComponent<Button>().onClick.AddListener(ClickBehavior);
        list.SetList(index, sport);
	}

    void ClickBehavior()
    {
        if (currentActiveState)
        {
            Deactivate();
            GetComponent<Image>().color = Color.gray;
        }
        else {
            Activate();
            GetComponent<Image>().color = Color.green;
        }
        list.UpdateResult();
    }

    void Activate() {
        list.SetActiveList(index, true);
        currentActiveState = true;
    }

    void Deactivate() {
        list.SetActiveList(index, false);
        currentActiveState = false;
    }

}
