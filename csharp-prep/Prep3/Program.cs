using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101);
        Console.WriteLine("I'm thinking of a number between 1 and 100.");

        int guess;
        bool guessedCorrectly = false;
        
        while (!guessedCorrectly)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                guessedCorrectly = true;
                Console.WriteLine("You guessed it!");
            }
        }
    }
}
