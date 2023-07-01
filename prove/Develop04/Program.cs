using System;
using System.Threading;

public abstract class Activity
{
    protected string Name { get; set; }
    protected string Description { get; set; }
    protected int Duration { get; set; }

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Start()
    {
        Console.WriteLine($"Starting {Name} Activity");
        Console.WriteLine(Description);
        Console.WriteLine($"Duration: {Duration} seconds");
        Console.WriteLine("Get ready...");
        Pause(3);
        PerformActivity();
        Console.WriteLine("Good job!");
        Pause(3);
        Console.WriteLine($"You have completed the {Name} Activity for {Duration} seconds.");
        Pause(3);
    }

    protected abstract void PerformActivity();

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Pausing for {i} seconds...");
            Thread.Sleep(1000);
        }
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        Duration = duration;
    }

    protected override void PerformActivity()
    {
        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Pause(3);
            Console.WriteLine("Breathe out...");
            Pause(3);
        }
    }
}

public class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        Duration = duration;
    }

    protected override void PerformActivity()
    {
        Random random = new Random();

        for (int i = 0; i < Duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            Pause(3);

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                Pause(3);
            }
        }
    }
}

public class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        Duration = duration;
    }

    protected override void PerformActivity()
    {
        Random random = new Random();

        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Pause(3);

        Console.WriteLine("Start listing items...");

        // Simulating user input by waiting for the specified duration
        Pause(Duration);

        Console.WriteLine($"You listed {Duration} items.");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mindfulness Activities");

        while (true)
        {
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "0")
                break;

            Console.Write("Enter the duration in seconds: ");
            int duration = int.Parse(Console.ReadLine());

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity(duration);
                    breathingActivity.Start();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity(duration);
                    reflectionActivity.Start();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity(duration);
                    listingActivity.Start();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Exiting the program. Goodbye!");
    }
}
