using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string Name { get; set; }
    
    public abstract void MarkComplete();
    public abstract int CalculatePoints();
}

public class SimpleGoal : Goal
{
    public override void MarkComplete()
    {
        // Marking logic for simple goal
    }

    public override int CalculatePoints()
    {
        // Points calculation logic for simple goal
        return 1000;
    }
}

public class EternalGoal : Goal
{
    public override void MarkComplete()
    {
        // Marking logic for eternal goal
    }

    public override int CalculatePoints()
    {
        // Points calculation logic for eternal goal
        return 100;
    }
}

public class ChecklistGoal : Goal
{
    public int CompletionCount { get; set; }
    public int TargetCount { get; set; }

    public override void MarkComplete()
    {
        // Marking logic for checklist goal
        CompletionCount++;
    }

    public override int CalculatePoints()
    {
        // Points calculation logic for checklist goal
        if (CompletionCount == TargetCount)
            return 500; // Bonus points
        else
            return 50;
    }
}

// Usage:
Goal goal1 = new SimpleGoal();
Goal goal2 = new EternalGoal();
Goal goal3 = new ChecklistGoal();
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
