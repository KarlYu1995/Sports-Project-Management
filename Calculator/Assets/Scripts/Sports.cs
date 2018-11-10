
[System.Serializable]
public class Sports {
    float cost;
    float ticket;
    float live;
    string location;

    public float Cost
    {
        get { return this.cost; }
        set { this.cost = value; }
    }

    public float Ticket
    {
        get { return this.ticket; }
        set { this.ticket = value; }
    }

    public float Live {
        get { return this.live; }
        set { this.live = value; }
    }

    public string Location
    {
        get { return this.location; }
        set { this.location = value; }
    }

    public Sports(float cost,float ticket,float live,string location) {
        this.cost = cost;
        this.ticket = ticket;
        this.live = live;
        this.location = location;
    }
}
