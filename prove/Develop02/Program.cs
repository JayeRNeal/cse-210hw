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
                Console.Write("That is not a valid choice. Please choose again.");
            }

        }
    }
    //Change name to Prompt.cs to PromptGenerator.cs


public class Prompt
{
    List<int> usedPrompts = new List<int>();

    public string GetPrompts()
    {
      string prompt ="";
      List<string> prompts = new List<string>() 
      {
        "What are you most excited about for today?",
        "Who makes you feel happiest in life and why?",
        "What are you most grateful for in your life?",
        "Write about the best day you’ve had recently.",
        "What challenges have you overcome in life?",
        "What are you most proud of?",
        "Write about one of your happiest memories.",
        "List 10 things you love about yourself.",
        "What are your blessings in life?",
        "What goals are you going to accomplish today?",
        "What do you want to improve in your life?",
        "List 5 short-term goals and 10 long-term goals.",
        "Where would you like to travel and where would you stay?",
        "What adventures would you like to have?",
        "List some material possessions would you like to own.",
        "Jot down a list of books to read, movies to watch, or topics to learn about.",
        "What is your dream job?",
        "Who would you like to meet?",
        "What excites you about the future?",
        "What do you miss most about the past?",
        "Who or what inspires you?",
        "What are your strengths and weaknesses?",
        "What are the most valuable life lessons you have learned?",
        "How would you describe yourself to someone you’ve never met?",
        "What are your spiritual beliefs?",
        "Describe your ideal lifestyle.",
        "What advice would you give your younger self?",
        "Who in your life makes you laugh the most?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
      };

      Random rand = new Random();
      int num = rand.Next(0, prompts.Count);

      if (usedPrompts.Count() < 30) //Change number

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

  public Journal()
  {
    
  }

  public void Write()
  {
    Entry entry = new Entry();
    entry.Write();
    entryList.Add(entry);

  }  

  public void Display()
    {
      foreach (Entry entry in entryList)  // Add all new entries to the Load List before displaying.
      {
        loadList.Add(entry);
      }
      foreach (Entry entry in loadList)  // Now that Load List has all entries (Old and New). Display all.
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
    foreach (Entry entry in entryList)  // Add all new entries to the Load List before displaying.
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

    public Entry()
    {

    }

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