using System;
using System.Collections.Generic;

// Base class for all goals
public abstract class Goal
{
    public string Name { get; protected set; }
    public bool Completed { get; protected set; }

    public abstract int CalculatePoints();

    public void MarkComplete()
    {
        Completed = true;
    }
}

// Simple goal that can be marked complete
public class SimpleGoal : Goal
{
    private int points;

    public SimpleGoal(string name, int points)
    {
        Name = name;
        this.points = points;
    }

    public override int CalculatePoints()
    {
        return Completed ? points : 0;
    }
}

// Eternal goal that can be recorded multiple times
public class EternalGoal : Goal
{
    private int points;

    public EternalGoal(string name, int points)
    {
        Name = name;
        this.points = points;
    }

    public override int CalculatePoints()
    {
        return points;
    }
}

// Checklist goal that requires a certain number of completions
public class ChecklistGoal : Goal
{
    private int pointsPerCompletion;
    private int targetCount;
    private int bonusPoints;
    private int completionCount;

    public ChecklistGoal(string name, int pointsPerCompletion, int targetCount, int bonusPoints)
    {
        Name = name;
        this.pointsPerCompletion = pointsPerCompletion;
        this.targetCount = targetCount;
        this.bonusPoints = bonusPoints;
    }

    public override int CalculatePoints()
    {
        int totalPoints = completionCount * pointsPerCompletion;
        if (Completed)
            totalPoints += bonusPoints;
        return totalPoints;
    }

    public new void MarkComplete()
    {
        completionCount++;
        if (completionCount >= targetCount)
            Completed = true;
    }

    public int CompletionCount { get { return completionCount; } }
    public int TargetCount { get { return targetCount; } }
}

// Player class to track goals and score
public class Player
{
    private string name;
    private List<Goal> goals;
    private int score;

    public Player(string name)
    {
        this.name = name;
        goals = new List<Goal>();
        score = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        Goal goal = goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.MarkComplete();
            score += goal.CalculatePoints();
        }
    }

    public void DisplayGoals()
    {
        foreach (Goal goal in goals)
        {
            string goalStatus = goal.Completed ? "[X]" : "[ ]";
            if (goal is ChecklistGoal checklistGoal)
            {
                goalStatus += $" Completed {checklistGoal.CompletionCount}/{checklistGoal.TargetCount} times";
            }
            Console.WriteLine($"{goalStatus} {goal.Name}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Score: {score}");
    }
}

// Example usage
public class Program
{
    public static void Main(string[] args)
    {
        Player player = new Player("John");
        Goal goal1 = new SimpleGoal("Run a marathon", 1000);
        Goal goal2 = new EternalGoal("Read scriptures", 100);
        Goal goal3 = new ChecklistGoal("Attend the temple", 50, 10, 500);

        player.AddGoal(goal1);
        player.AddGoal(goal2);
        player.AddGoal(goal3);

        player.RecordEvent("Run a marathon");
        player.RecordEvent("Read scriptures");
        player.RecordEvent("Read scriptures");
        player.RecordEvent("Attend the temple");
        player.RecordEvent("Attend the temple");
        player.RecordEvent("Attend the temple");

        player.DisplayGoals();
        player.DisplayScore();
    }
}
