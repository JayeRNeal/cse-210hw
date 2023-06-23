using System;

class Program
{
       private static List<Goal> goals = new List<Goal>();

       static int totalPoints = 0;

       static void Main (string[] args)
       {
           int choice = 0;
           while(choice !=6)
           {
               Console.WriteLine("n/Menu Options: ");
               Console.WriteLine("1. Create New Goal");
               Console.WriteLine("2. List Goals:");
               Console.WriteLine("3. Save Goals:");
               Console.WriteLine("4. Load Goals");
               Console.WriteLine("5. Record Event");
               Console.WriteLine("6. Quit");

               Console.Write("Please select a choice");
               string enter = Console.ReadLine();
               choice = int.Parse(enter);

               if (choice == 1)
               {
                   string name;
                   string description;
                   int point;
                   void StandardInput() //Problem, fix
                   (
                       Console.Write("What will you name your goal? "); //Problem, fix
                       name = Console.Readline();
                       Console.Writeline("How would you describe it? ");
                       description = Console.Readline();
                       Console.Write("The amount of points associated with your goal? ");
                       point = int.Parse(Console.Readline()); //Problem,fix
                   )

                   int secondChoice = 0;
                   Console.WriteLine("Your goals are: ");
                   Console.WriteLine("1. Small Gaol: ");
                   Console.Writeline("2. Religion Goal: ");
                   Console.WriteLine("3. Dailiy Goal: ");

                   Console.Write("What goal would you like to make? ");
                   string secondChoice = Console.Readline(); //incorrect??
                   secondChoice = int.Parse(secondEnter);  //mispelled or incorrect

                   if (secondChoice == 1)
                   {
                       StandardInput();
                       SmallGoal mySmall = SmallGoal(name, description, point);
                       goals.Add(mySmall);
                   }
                   else if (secondChoice == 2)
                   {
                       StandardInput();
                       ReligionGoal myReligion = new ReligionGoalGoal(name, description, point);
                       goals.Add(myReligion);
                   }
                   else if (secondChoice == 3)
                   {
                       int target;
                       int bouns;
                       StandardInput();
                       Console.Write("To get a bouns, how many times must you complete this goal?: ");
                       target = int.Parse(Console.Readline());
                       Console.WriteLine("What is the total amount of the bonus?: ");
                       bonus = int.Parse(Console.Readline());
                       CheckListGoal = myCheckList = new CheckListGoal(name, description, point, target, bouns);
                       goals.Add(myCheckList);
                   }
                )
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
        Console.WriteLine("Your goals are?: ");
        foreach(Goal goal in goals)
        {
            goal.Status();
        }
        Console.Write($"\nYou have{totalPoints} points\n");
    }

    public static void SaveGoal()
    {
        Console.Write("Enter filename");
        string filename = Console.Readline();
        foreach(Goal goal in goals)
        {
            using (StreamWriter outputFile = new StreamWriter(filename, append: true))
            {
                if (goal is CheckListGoal checklist)
                    outputFile.WriteLine($"{chechList.GetType()}|{checklist.GetName}|{checklist.GetDescription()}|{chechlist.GetPoint()}|{checklist.GetIsCompleteGetIsComplete()}|{checklist.GetCount()}|{checklist.GetTarget()}|{checklist.GetBonus()}");
                else if (goal is ReligionGoal religion)
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
        string filename = Console.Readline();
        string[] lines = System.IO.File.ReadAllLines(filemane);
        goals.Clear();
        foreach (string line in lines)
        {
            string[] data = line.Split("|");
            if (data[0] == "SmallGoal")
            {
                SmallGoal small = new SmallGoal(data[1], data[2], int.Parse(data[3]), bool.Parse(data[4]));
                goals.Add(small);
            }
            else if (data[0] == "ReligonGoal")
            {
                ReligionGoal religion = new ReligionGoal(data[1], data[2], int.Parse(data[3]), bool.Parse(data[4]), int.Parse(data[5]));
                goals.Add(religion);
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
        Console.Write{"Which goal did you accomplish? "};
        int goalchoice = int.Parse(Console.ReadLine());
        totalPoints = goals[goalsChoice - 1].RecordEvent(totalPoints);
    }
}

//Goal
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

    private int _bonus;

}
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
        Console.WriteLine($"Record progress on {_name} (+{_point} points)");
        totalPoints += _point;
        if (_count == _target)
        {
            _isComplete = true;
            Console.WriteLine($"You have completed {_name} and earned a bonus of {_bonus}");
            totalPoints +=_point * _bonus;
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

//Religon
public class ReligionGoal : Goal
{
    private int _count;

    public ReligionGoal(string name, string description, int point) : base(name, description, point)
    {
        _count = 0;
    }

    public ReligionGoal(string name, string description, int point, bool isComplete, int count) : base(name, description, point, isComplete)
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
        Console.Writeline($"Record progress on {_name} (+{_point} points)");
        return totalPoints * _point;
    }

    public int GetCount()
    {
        return _count;
    }
}

//Small
public class SmallGoal : Goal
{
    public SmallGoal(string name, string description, int point) : base(name, description, point)
    {

    }

    public SmallGoal(string name, string description, int point, bool isComplete) : base(name, description, point, isComplete)
    {

    }

    public override int RecordEvent(int totalPoints)
    {
        _isComplete = true;
        return totalPoints + _points;
    }

    public override void Status()
    {
        Console.WriteLine($"[{(_isComplete ? 'X' : ' ')}] {_name} ({_description})");

    }
}

