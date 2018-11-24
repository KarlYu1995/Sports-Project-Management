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
    int location;
    [SerializeField]
    int popularity;
    [SerializeField]
    int index;
    [SerializeField]
    SportsListController list;
    Sports sport;
    bool currentActiveState = false;//このSportsがリストに入ているならtrueそうでないならfalse
    

	void Start () {
        sport = new Sports(cost, ticket, live, location,popularity);
        GetComponent<Image>().color = Color.gray;
        GetComponent<Button>().onClick.AddListener(ClickBehavior);
        UpdateSport();
	}

    void ClickBehavior()
    {
        bool changecolor;
        if (currentActiveState)
        {
            Deactivate();
            changecolor = false;
            GetComponent<Image>().color = Color.gray;
        }
        else {
            Activate();
            changecolor = true;
            GetComponent<Image>().color = Color.green;
        }
        list.UpdateResult(changecolor);
    }

    void Activate() {
        list.SetActiveList(index, true);
        currentActiveState = true;
    }

    void Deactivate() {
        list.SetActiveList(index, false);
        currentActiveState = false;
   }

    public void UpdateLocation(int newLocation){
        sport.Location = newLocation;
        this.location = newLocation;
        UpdateSport();
        list.UpdateResult(true);
    }

    void UpdateSport(){
        list.SetList(index, sport);
    }

}
