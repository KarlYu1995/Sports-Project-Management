
[System.Serializable]
public class Sports {
    float cost;
    float ticket;
    float live;
    int location;
    int popularity;

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

    public int Location
    {
        get { return this.location; }
        set { this.location = value; }
    }

    public int Popularity{
        get { return this.popularity; }
        set { this.popularity = value; }
    }

    public Sports(float cost,float ticket,float live,int location,int popularity) {
        this.cost = cost;
        this.ticket = ticket;
        this.live = live;
        this.location = location;
        this.popularity = popularity;
    }
}
