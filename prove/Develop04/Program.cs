using System;

class Program
{
    static void Main(string[] args)
    {
    int choice = 0;
    while (choice != 4)
    {
        Console.WriteLine("Menu:  ");
        Console.WriteLine("1. Begin Breathing Activity");
        Console.WriteLine("2. Begin Reflecting Activity");
        Console.WriteLine("3. Start Listing Activity");
        Console.WriteLine("4. Quit");

        Console.WriteLine("Select a menu choice: ");
        string enter = Console.ReadLine();
        choice = int.Parse(enter);
        if (choice == 1)
        {
            // may need n/ at beginning and end of string
            Console.WriteLine("This Breathing Activity will begin shortly.");
            Console.WriteLine("We will walk you through a breathing exercise to help you relax.");
            Breathing myBreathing = new Breathing();
            myBreathing.pauseTimer(3);
            myBreathing.StartActivity();
            myBreathing.EndMessage();
        }
        if (choice == 2)
        {
            // may need n/ as well in string
            Console.WriteLine("Welcome to the Reflection Activity.");
            Console.WriteLine("During this activity we would like you to focus on a time when you were resilient. This will allow you to decompress and visualize your ability to overcome any obstacles you currently face.");
            Reflection myReflection = new Reflection();
            myReflection.pauseTimer(3);
            myReflection.Run();
            myReflection.EndMessage();
        }
        if (choice == 3)
        {
            Console.WriteLine("Welcome to Listing Activiry.");
            Console.WriteLine("During this activity we will help you reflect on times reflect on the positives in your life. List as many things you are grateful for.");
            Listing myListing = new Listing();
            myListing.pauseTimer(3);
            myListing.Run();
            myListing.EndMessage();
        }
    }
}

class Activity
{
    protected int _duration;
        
    public void EndMessage()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed another {_duration} seconds of the breathing Activity.");
    }
    public void pauseTimer(int _activationCount)
    {
        int countDown = _activationCount;
        Console.Write("Get ready...\n\n");

        while (countDown > 0)
        {
            Console.Write($"{countDown}");
            countDown--;
            Thread.Sleep(2000);// pause for 2 seconds
            Console.Write("\b \b");
        }

    }
    public  Activity()
    {
        Console.Write("How long in seconds, would you like for your session? ");
        string text = Console.ReadLine();
        int q = int.Parse(text);
        _duration = q;        
    }
    
}

    public void StartActivity()
    {
        int i = _duration;

        DateTime start = DateTime.Now;
        while ((DateTime.Now - start).TotalSeconds < i)
        {
            Console.WriteLine("Take a deep breath in...");
            Thread.Sleep(2000); 
            Console.WriteLine("Now breathe out...");
            Thread.Sleep(4000);

            i--;
        }
        Console.WriteLine(".");
        Thread.Sleep(4000);
    }

//Missing breathing class
class Breathing : Activity {
    public Breathing() : base(){

    }


    public void StartActivity()
    {
        int i = _duration;

        DateTime start = DateTime.Now;
        while ((DateTime.Now-start).TotalSeconds < i);
        {
            Console.WriteLine("Breath in...");
            Thread.Sleep(2000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(4000);

            i--;
        }
        Console.Write(".");
        Thread.Sleep(4000);
    }

//Reflection
class Reflection : Activity
{
    private Random random = new Random();

    private List<string>prompts = new List<string>()
    {
        "What is one of the most difficult tasks you've had to do?",
        "What was one of the best experiences of your life?",
        "What do you fear most? Have your fears changed throughout life?", //prompt may need to be changed/re-worded based off questions
        "How do you prioritize self-care?",
        "How do you show yourself kindness and compassion each day?",
    };
    private List<string>questions = new List<string>()
    {
        "What was your best take away from that experience?",
        "What did you learn about yourself from these expreiences?",
        "How can you keep this expreince in mind for the future?",
        "How did you feel after the task was complete?",
        "How do you shift your mindset if it isn't working for you?",
        "What new opportunities have come out of challenges you’ve faced?",
        "How has this experience allowed you to grow our of your comfort zone?",
        "What made this time different than other instances when you not succussful?", //?
    };
    public Reflection() : base()
    {

    }

    public void Run()
    {
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine("Consider the following:");
        Console.WriteLine($"----{prompt}----");
        Console.WriteLine("Press enter when something comes to mind."); //error
        string input = Console.ReadLine();

        foreach (string question in questions)
        {
            Console.WriteLine(question + " ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(".");
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
        Console.Write(".");
        Thread.Sleep(4000);

    }
}

//Listing
class Listing : Activity
{
    private static Random random = new Random();

    private static List<string> prompts = new List<string>()
    {
        "What are some of your best strengths? ",
        "What are some improvements you'd like to make?",
        "Someone that has made an impact on your life, and why were they impactful?", //spelling, fix sentence
        "What tasks did you have to complete in your last act of service. How did serving make you feel?",
        "Who are some of your personal heros?",
    };

    public Listing() : base()
    {

    }

    public void Run()
    {
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine("Press enter when something comes to mind.");
        string input = Console.ReadLine();
        List<string> items = new List<string>();

        int i = _duration;

        DateTime start = DateTime.Now;
        while ((DateTime.Now - start).TotalSeconds < i)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
            {
                break;
            }
            items.Add(item);
        }
        Console.WriteLine($"You've listed {items.Count} items.");
        Console.Write(".");
        Thread.Sleep(4000);
    
    }
}
}
}

