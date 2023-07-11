using System;

class Program
{
    static void Main(string[] args)
    {
        Running running = new Running(new DateTime(2023, 7, 14), 30, 5.0);
        Cycling cycling = new Cycling(new DateTime(2023, 7, 14), 30, 20.0);
        Swimming swimming = new Swimming(new DateTime(2023, 7, 14), 30, 13);

        //Activities
        Activity[] activities = {running, cycling, swimming};

        //Results
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
//Activity class
abstract class Activity
    {
        private DateTime _date;

        private int _length;

        public Activity(DateTime date, int length)
        {
            _date = date;
            _length = length;
        }
        public int GetLength()
        {
            return _length;
        }
        public abstract double Distance();
        public abstract double Speed();
        public abstract double Pace();

        public virtual string GetSummary()
        {
            return($"{_date.ToString("dd MMM yyyy")} ");
        }
    }

//Running class
class Running : Activity
{
    private double _distance;
    public Running(DateTime date, int length, double distance) : base(date, length)
    {
        _distance = distance;
    }

    public override double Distance()
    {
        return _distance; //throw new NotImplementedException();
    }

    public override double Speed()
    {
        return _distance / GetLength() * 60; //throw new NotImplementedException();
    }

    public override double Pace()
    {
        return GetLength() / _distance; //throw new NotImplementedException();
    }
    //Running summary not displaying
    public override string GetSummary()
    {
        return ($"{base.GetSummary()} Running ({GetLength()} min) - Distance: {_distance} miles, Speed: {Speed()} mph, Pace: {Pace()} min/mile");
    }
}

//Cycling class
class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int length, double speed) : base(date, length)
    {
        _speed = speed;
    }

    public override double Distance()
    {
        return _speed * GetLength() / 60; //throw new NotImplementedException();
    }
    public override double Speed()
    {
        return _speed; //throw new NotImplementedException();
    }
    public override double Pace()
    {
       return 60 / _speed; //throw new NotImplementedException();
    }
    public override string GetSummary()
    {
    return ($"{base.GetSummary()} Cycling ({GetLength()} min) - Distance: {Distance()} km, Speed: {_speed} kph, Pace: {Pace()} min/mph");
    }
}

//Swimming class
class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int length, int laps) : base(date, length)
    {
        _laps = laps;
    }

    public override double Distance()
    {
        return _laps * 50 / 1000.0; //throw new NotImplementedException();
    }

    public override double Speed()
    {
        return Distance() / GetLength() * 60; //throw new NotImplementedException();
    }

    public override double Pace()
    {
        return GetLength() / Distance(); //throw new NotImplementedException();
    }

    public override string GetSummary()
    {
        return ($"{base.GetSummary()} Swimming ({GetLength()} min) - Distance: {Distance()} km, Speed: {Speed()} kph, Pace: {Pace()} min/km");
    }
}