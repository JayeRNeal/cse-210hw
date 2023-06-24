using System.IO;

class Program
{
    private static List<Goal> goals = new List<Goal>();

    static int totalPoints = 0;
    static void Main(string[] args)
    {
        int choice = 0;
        while (choice != 6)
        {
            Console.WriteLine("\nMenu Options: ");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Please select a choice from menu: ");
            string enter = Console.ReadLine();
            choice = int.Parse(enter);

            if (choice == 1)
            {
                string name;
                string description;
                int point;
                void StandardInput()
                {
                    Console.Write("What will you name your goal? --- ");
                    name = Console.ReadLine();
                    Console.Write("How would you describe it? --- ");
                    description = Console.ReadLine();
                    Console.Write("The amount of points associated with your goal? ---");
                    point = int.Parse(Console.ReadLine());
                }

                int secondChoice = 0;
                Console.WriteLine("The types of Goals are: ");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal ");
                Console.WriteLine("3. CheckList Goal ");

                Console.Write("What goal would you like to make? --- ");
                string secondEnter = Console.ReadLine();
                secondChoice = int.Parse(secondEnter);

                if (secondChoice == 1)
                {
                    StandardInput();
                    SimpleGoal mySimple = new SimpleGoal(name, description, point);
                    goals.Add(mySimple);

                }
                else if (secondChoice == 2)
                {
                    StandardInput();
                    EternalGoal myEternal = new EternalGoal(name, description, point);
                    goals.Add(myEternal);
                }
                else if (secondChoice == 3)
                {
                    int bonus;
                    int target;
                    StandardInput();
                    Console.Write("To get a bouns, how many times must you complete this goal?: --- ");
                    target = int.Parse(Console.ReadLine());
                    Console.Write("What is the total amount of the bonus?: --- ");
                    bonus = int.Parse(Console.ReadLine());
                    CheckListGoal myCheckList = new CheckListGoal(name, description, point, target, bonus);
                    goals.Add(myCheckList);
                }
            }
            else if (choice == 2)
            {
                ListGoals();
            }
            else if (choice == 3)
            {
                SaveGoal();
            }
            else if (choice == 4)
            {
                LoadGoal();
            }
            else if (choice == 5)
            {
                RecordEvent();
            }
        }
    }

    public static void ListGoals()
    {
         Console.WriteLine("Your goals are: ");
        foreach (Goal goal in goals)
        {
            goal.Status();
        }
        Console.Write($"\nYou have {totalPoints} points\n");
    }

    public static void SaveGoal()
    {

        Console.Write("Enter filename ");
        string filename = Console.ReadLine();
        foreach (Goal goal in goals)
        {
            using (StreamWriter outputFile = new StreamWriter(filename, append: true))
            {
                if (goal is CheckListGoal checklist)
                    outputFile.WriteLine($"{checklist.GetType()}|{checklist.GetName()}|{checklist.GetDescription()}|{checklist.GetPoint()}|{checklist.GetIsComplete()}|{checklist.GetCount()}|{checklist.GetTarget()}|{checklist.GetBonus()}");
                else if (goal is EternalGoal eternal)
                {
                    outputFile.WriteLine($"{eternal.GetType()}|{eternal.GetName()}|{eternal.GetDescription()}|{eternal.GetPoint()}|{eternal.GetIsComplete()}|{eternal.GetCount()}");
                }
                else
                    outputFile.WriteLine($"{goal.GetType()}|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPoint()}|{goal.GetIsComplete()}");
            }
        }
    }

    public static void LoadGoal()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        goals.Clear();
        foreach (string line in lines)
        {
            string[] data = line.Split("|");
            if (data[0] == "SimpleGoal")
            {
                SimpleGoal simple = new SimpleGoal(data[1], data[2], int.Parse(data[3]), bool.Parse(data[4]));
                goals.Add(simple);
            }
            else if (data[0] == "EternalGoal")
            {
                EternalGoal eternal = new EternalGoal(data[1], data[2], int.Parse(data[3]), bool.Parse(data[4]), int.Parse(data[5]));
                goals.Add(eternal);
            }
            else
            {
                CheckListGoal checklist = new CheckListGoal(data[1], data[2], int.Parse(data[3]), bool.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]));
                goals.Add(checklist);
            }
        }
    }

    public static void RecordEvent()
    {
        Console.WriteLine("Your goals are: ");
        foreach (Goal goal in goals)
        {
            goal.Status();  
        }
        Console.Write("Which goal did you accomplish? --- ");
        int goalchoice = int.Parse(Console.ReadLine());
        totalPoints = goals[goalchoice - 1].RecordEvent(totalPoints);

    }

//Event,Status
public abstract class Goal
{  
    protected string _description;
    protected int _point;
    protected string _name;
    protected bool _isComplete;

    public Goal(string name, string description, int point)
    {
        _name = name;
        _description = description;
        _point = point;
        _isComplete = false;
    }

    public Goal(string name, string description, int point, bool isComplete)
    {
        _name = name;
        _description = description;
        _point = point;
        _isComplete = isComplete;
    }

    public virtual void Status()
    {
        Console.WriteLine($"[{(_isComplete ? 'X' : ' ')}] {_name} ({_description})");
    }

    public int GetPoint()
    {
        return _point;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }
    public bool GetIsComplete()
    {
        return _isComplete;
    }

    public abstract int RecordEvent(int totalPoints);
}


//Checklist
public class CheckListGoal : Goal
{
    private int _target;

    private int _count;
    public int _bonus;

    public CheckListGoal(string name, string description, int point, int target, int bonus) : base(name, description, point)
    {
        _target = target;
        _bonus = bonus;
        _count = 0;
    }

    public CheckListGoal(string name, string description, int point, bool isComplete, int count, int target, int bonus) : base(name, description, point, isComplete)
    {
        _target = target;
        _bonus = bonus;
        _count = count;
    }

    public override void Status()
    {
        Console.WriteLine($"[{(_isComplete ? 'X' : ' ')}] {_name} ({_description}) --- Currently completed: {_count}/{_target} ");
    }
    public override int RecordEvent(int totalPoints)
    {
        _count++;
        Console.WriteLine($"Recorded progress on {_name} (+{_point} points)");
        totalPoints += _point;
        if (_count == _target)
        {
            _isComplete = true;
            Console.WriteLine($"Congratulations, you have completed {_name} and earned a bonus of {_bonus} points!");
            totalPoints += _point + _bonus;
        }
        return totalPoints;
    }
    public int GetCount()
    {
        return _count;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public int GetTarget()
    {
        return _target;
    }
}

//GoalsEternal
public class EternalGoal : Goal
 {
    private int _count;

    public EternalGoal(string name, string description, int point) : base(name, description, point)
    {
        _count = 0;
    }

    public EternalGoal(string name, string description, int point, bool isComplete, int count) : base(name, description, point, isComplete)
    {
        _count = count;
    }

    public override void Status()
    {
        Console.WriteLine($"[{(_isComplete ? 'X' : ' ')}] {_name} ({_description})");
    }

    public override int RecordEvent(int totalPoints)
    {
        _count++;
        Console.WriteLine($"Recorded progress on {_name} (+{_point} points)");
        return totalPoints + _point;
    }
   
   public int GetCount()
   {
       return _count;
   }
}

//GoalsSimple
public class SimpleGoal : Goal
{

    public SimpleGoal(string name, string description, int point) : base(name, description, point)
    {
        
    }

    public SimpleGoal(string name, string description, int point, bool isComplete) : base(name, description, point, isComplete)
    {
        
    }

    public override int RecordEvent(int totalPoints)
    {
        _isComplete = true;
        return totalPoints + _point;
    }
    
    public override void Status()
    {        
        Console.WriteLine($"[{(_isComplete ? 'X' : ' ')}] {_name} ({_description})");
    }
}
}

