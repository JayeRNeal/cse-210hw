using System;
using System.IO;

class Program
{

    static void Menu()
    {
        Console.WriteLine();
        Console.WriteLine("Please select one of the following options: ");
        List<string> menu = new List<string>()
        {
            "Write",
            "Display",
            "Load",
            "Save",
            "Quit",
        };
        foreach (string option in menu)
        {
            Console.WriteLine($"{menu.IndexOf(option)+1}.{option}");
        }
        Console.Write("What would you like to do? : ");
    }

    static void Main(string[] args)
    {
        var choice = 0; 
        
        Journal myJournal = new Journal(); 

        while (choice != 5)
        {

            Menu();
            var response = Console.ReadLine();
            choice = int.Parse(response);

            if (choice == 1) 
            {
                myJournal.Write();
            }
            else if (choice == 2)
            {
                myJournal.Display();
            }
            else if (choice == 3)
            {
                myJournal.Load();
            }
            else if (choice == 4)
            {
                Console.WriteLine("Please choose one of these options: ");
                List<string> save = new List<string>()
                {
                    "Save a new file to all the entries",
                    "Save to an exsiting file with new entries.",  
                };
                foreach (string option in save)
                {
                    Console.WriteLine($"{save.IndexOf(option)+1}.{option}");
                }
                Console.Write("What would you like to do? : ");
                var saveChoice = Console.ReadLine();
                var saveOpt = int.Parse(saveChoice);

                if (saveOpt == 1)
                {
                    myJournal.SaveAll();
                }
                else if (saveOpt == 2)
                {
                    myJournal.SaveNew();
                }
            }
            else if (choice == 5) // Quit
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Write("That is not a valid choice. Please choose again?");
            }

        }
    }

public class Prompt
{
    List<int> usedPrompts = new List<int>();

    public string GetPrompts()
    {
      string prompt ="";
      List<string> prompts = new List<string>() 
      {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What goals do you want to accomplish today?",
        "If you could stay anywhere in the world where would you stay and why?",
        "What are you most excited about for today?",
        "List 10 things you love about yourself.",
        "Who has been your biggest insipation?",
        "What is your dream job?",
        "Who makes you happiest?",
        "Who makes you laugh the most?",
        "What are you most Thankful for?",
        "What do you do when you are faced with challenges?",
        "What are you most proud of?",
        "What are some of your favorite memories as a child.",
        "In what ways will you improve in your life?",
        "What are somethings you would like to own?.",
        "Write down a list of books to read, movies to watch, or skills you'd like to have?",
        "Who would you like to meet?",
        "What do you miss most about the past?",
        "What are your strengths and weaknesses?",
        "What are the most valuable life lessons you have learned?",
        "How would you describe yourself to someone you’ve never met?",
        "What advice would you give your younger self?",
        "What is your favoirte quote and how have you applied it to your life?",
      };

      Random rand = new Random();
      int num = rand.Next(0, prompts.Count);

      if (usedPrompts.Count() < 26)

      {
        if (!usedPrompts.Contains(num))

        {
          usedPrompts.Add(num);
          prompt = prompts[num];
        }

        else{
        GetPrompts();
        }

      }else
      {
        Console.WriteLine("All done for today!");
      }

      return prompt;
    }
}
public class Journal
{
  public List<Entry> entryList = new List<Entry>(); //List of New entries

  public List<Entry> loadList = new List<Entry>(); //List of Loaded entries

  private string fileName;

  public void Write()
  {
    Entry entry = new Entry();
    entry.Write();
    entryList.Add(entry);

  }  

  public void Display()
    {
      foreach (Entry entry in entryList)  // Add all new entries to the Load List
      {
        loadList.Add(entry);
      }
      foreach (Entry entry in loadList)  // Now that Load List has all entries
      {
        Console.WriteLine($"---------------------------------");
        Console.WriteLine($"Date: {entry._date} - Prompt: {entry._prompt}");
        Console.WriteLine($"Response: {entry._entry}");
        Console.WriteLine($"---------------------------------");
        Console.WriteLine();
      }
    }
  public void Load()
  {
    Console.Write("Enter the Filename: ");
    fileName = Console.ReadLine();

    string[] lines = System.IO.File.ReadAllLines(fileName);

    for (int x = 0; x < lines.Count(); x+=3){
      Entry entry = new Entry();
      entry._date = lines[x];
      entry._prompt = lines[x+1];
      entry._entry = lines[x+2];
      loadList.Add(entry);
    }
  }

  public void SaveNew()
  {
    Console.Write("Enter the Filename: ");
    fileName = Console.ReadLine();

    foreach (Entry entry in entryList){
      using (StreamWriter file = new StreamWriter(fileName,append:true))
      {
        file.WriteLine(entry._date);
        file.WriteLine(entry._prompt);
        file.WriteLine(entry._entry);
      }
    }
  }

    public void SaveAll()
  {
    Console.Write("Enter the Filename: ");
    fileName = Console.ReadLine();
    foreach (Entry entry in entryList)  // Add all new entries to the Load List
      {
        loadList.Add(entry);
      }
    foreach (Entry entry in loadList){
      using (StreamWriter file = new StreamWriter(fileName,append:true))
      {
        file.WriteLine(entry._date);
        file.WriteLine(entry._prompt);
        file.WriteLine(entry._entry);
      }
    }
  }
}

public class Entry
{
    public string _entry;

    public string _date;

    private DateTime _dateTime = DateTime.Now;

    public string _prompt;

    private Prompt _newPrompt = new Prompt();

    public void Write()
    {
      _date = _dateTime.ToShortDateString();
      _prompt = _newPrompt.GetPrompts();
      Console.WriteLine(_prompt);
      Console.Write("Entry: ");
      _entry = Console.ReadLine();

    }   
  }

}