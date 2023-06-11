using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);
        float gradePercentage = float.Parse(Console.ReadLine());


        char letter;

        if (gradePercentage >= 90)
        {
            letter = 'A';
        }
        else if (gradePercentage >= 80)
        {
            letter = 'B';
        }
        else if (gradePercentage >= 70)
        {
            letter = 'C';
        }
        else if (gradePercentage >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        bool passing = gradePercentage >= 70;

        if (passing)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep up the good work! Try again next time.");
        }

        // Stretch Challenge
        int lastDigit = (int)(gradePercentage % 10);
        char sign = ' ';

        if (letter == 'A' && lastDigit >= 7)
        {
            sign = '+';
        }
        else if (letter != 'F')
        {
            if (lastDigit < 3)
            {
                sign = '-';
            }
        }

        if (letter == 'A' && sign == '+')
        {
            Console.WriteLine("Grade: A+");
        }
        else if (letter == 'A' && sign == ' ')
        {
            Console.WriteLine("Grade: A");
        }
        else if (letter == 'A')
        {
            Console.WriteLine("Grade: A-");
        }
        else
        {
            Console.WriteLine($"Grade: {letter}{sign}");
        }
    }
}
