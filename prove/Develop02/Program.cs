using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }
}

class Journal
{
    private List<Entry> entries;

    public List<Entry> Entries
    {
        get { return entries; }
    }

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine("--------------------");
        }
    }

    public void SaveJournal(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadJournal(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            Entry entry = new Entry
            {
                Date = DateTime.Parse(parts[0]),
                Prompt = parts[1],
                Response = parts[2]
            };
            entries.Add(entry);
        }
    }
}

class Program
{
    private Journal journal;
    private List<string> prompts;

    public Program()
    {
        journal = new Journal();
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n=========== MENU ===========");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                WriteNewEntry();
            }
            else if (choice == "2")
            {
                DisplayJournal();
            }
            else if (choice == "3")
            {
                SaveJournalToFile();
            }
            else if (choice == "4")
            {
                LoadJournalFromFile();
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    private void WriteNewEntry()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.Write($"{prompt} ");
        string response = Console.ReadLine();
        Entry entry = new Entry
        {
            Prompt = prompt,
            Response = response,
            Date = DateTime.Now
        };
        journal.AddEntry(entry);
        Console.WriteLine("Entry added successfully.");
    }

    private void DisplayJournal()
    {
        if (journal.Entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
        }
        else
        {
            journal.DisplayEntries();
        }
    }

    private void SaveJournalToFile()
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();
        journal.SaveJournal(filename);
        Console.WriteLine("Journal saved successfully.");
    }

    private void LoadJournalFromFile()
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();
        journal.LoadJournal(filename);
        Console.WriteLine("Journal loaded successfully.");
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }
}
