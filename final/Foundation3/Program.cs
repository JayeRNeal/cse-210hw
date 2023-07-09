using System;

public class Program
{
    public static void Main()
    {
        Address myAddress1 = new Address("4444 W Way Ave", "Provo", "UT", "84604");
        Address myAddress2 = new Address("1572 Service Rd", "Toronto", "BC","98425");
        Address myAddress3 = new Address("1492 Ocean Blue St", "Valladolid", "Spain", "90210");

        Lecture mylecture = new Lecture(
            "Inheritance",
            "Learning Inheritance in C#.",
            new DateTime(2023, 7, 17, 13, 0, 0),
            myAddress1,
            "Professeor Himathoy Williams", 50
        );
        Console.WriteLine("Lecture:");
        mylecture.GetFullDetails();

        Reception myReception = new Reception(
            "Join our Party",
            "An event for all employees.",
            new DateTime(2023, 7, 24, 15, 3, 0),
            myAddress2, "pcsrsv@company.com"
        );
        Console.WriteLine("Reception:");        
        myReception.GetFullDetails();   

        OutDoor myOutDoor = new OutDoor(
            "Utah County BYUI students",
            "A end of the semester party.",
            new DateTime(2023, 8,24, 12,3,0), myAddress3, "Jaye"
        );
        Console.WriteLine("Out Door Event:");       
        myOutDoor.GetFullDetails();
        }
}

class Event {
    private string _title;
    private string _description;
    protected DateTime _dateTime;
    protected Address _address;

    public Event(string title, string description, DateTime dateTime, Address address) {
        _title = title;
        _description = description;
        _dateTime = dateTime;
        _address = address;
    }
   
    public virtual void GetFullDetails() {
        
        Console.WriteLine($"{_title}\n{_description}\n{_dateTime}\n{_address.GetAddressString()}\n");
    }
     public string GetTitle()
    {
        return _title;
    }
    public string GetDescription()
    {
        return _description;
    }
    
    
}

class Address {
    private string _street;
    private string _city;
    private string _state;
    private string _zip;

    public Address(string street, string city, string state, string zip) {
        _street = street;
        _city = city;
        _state = state;
        _zip = zip;
    }

    public string GetAddressString() {
        return ($"{_street}, {_city}, {_state} {_zip}");
    }
    public string GetStreet()
    {
        return _street;
    }
    public string GetCity()
    {
        return _city;
    }
    public string GetState()
    {
        return _state;
    }
    public string GetZip()
    {
        return _zip;
    }
}

class Lecture : Event {
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, DateTime dateTime, Address address, string speaker, int capacity)
        :base(title, description, dateTime, address) {
        _speaker = speaker;
        _capacity = capacity;
    }
   
    public override void GetFullDetails()
    {
        Console.WriteLine($"{GetTitle()}\n{GetDescription()}\n{_dateTime}\n{_address.GetAddressString()}\nSpeaker: {_speaker}\nCapacity: {_capacity}\n");
    }
    public string GetSpeaker()
    {
        return _speaker;
    }
    public int GetCapacity()
    {
        return _capacity;
    }
   
}

class OutDoor : Event {
    private string _weather;

    public OutDoor(string title, string description, DateTime dateTime, Address address, string weather)
        : base(title, description, dateTime, address)
        {
        _weather = weather;
    }

    public override void GetFullDetails()
    {
        Console.WriteLine($"{GetTitle()}\n{GetDescription()}\n{_dateTime}\n{_address.GetAddressString()}\nWeather: {_weather}\n");
    }
    public string GetWeather()
    {
        return _weather;
    }
}

class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, DateTime dateTime, Address address, string rsvpEmail)
        : base(title, description, dateTime, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override void GetFullDetails()
    {
        Console.WriteLine($"{GetTitle()}\n{GetDescription()}\n{_dateTime}\n{_address.GetAddressString()}\nRSVP Email: {_rsvpEmail}\n");
    }
    public string GetRSVPemail()
    {
        return _rsvpEmail;
    }
}
