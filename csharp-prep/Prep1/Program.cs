using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for their first name
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        // Prompt the user for their last name
        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        // Display the name in the desired format
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}");
    }
}
