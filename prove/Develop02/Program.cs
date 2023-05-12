using System;
using System.Collections.Generic;

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

        for (int i = 0; i < menu.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{menu[i]}");
        }

        Console.Write("What would you like to do? : ");
    }

    static void Main(string[] args)
    {
        int choice = 0;
        Journal myJournal = new Journal();

        while (choice != 5)
        {
            Menu();
            string response = Console.ReadLine();
            choice = int.Parse(response);

            if (choice == 1)
            {
                myJournal.WriteEntry();
            }
            else if (choice == 2)
            {
                myJournal.DisplayEntries();
            }
            else if (choice == 3)
            {
                myJournal.LoadEntries();
            }
            else if (choice == 4)
            {
                myJournal.SaveEntries();
            }
            else if (choice == 5) // Quit
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("That is not a valid choice. Please choose again.");
            }
        }
    }
}

public class Journal
{
    private List<string> entries = new List<string>();

    public void WriteEntry()
    {
        Console.WriteLine("Enter your journal entry:");
        string entry = Console.ReadLine();
        entries.Add(entry);
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }
        else
        {
            Console.WriteLine("Journal Entries:");
            for (int i = 0; i < entries.Count; i++)
            {
                Console.WriteLine($"Entry {i + 1}: {entries[i]}");
            }
        }
    }

    public void LoadEntries()
    {
        // Implementation for loading entries from a file
        Console.WriteLine("Loading entries...");
    }

    public void SaveEntries()
    {
        // Implementation for saving entries to a file
        Console.WriteLine("Saving entries...");
    }
}
