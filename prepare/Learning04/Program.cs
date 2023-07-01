using System;

public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}

public class MathAssignment : Assignment
{
    private int _homeworkList;

    public MathAssignment(string studentName, string topic, int homeworkList) : base(studentName, topic)
    {
        _homeworkList = homeworkList;
    }

    public int GetHomeworkList()
    {
        return _homeworkList;
    }
}

public class WritingAssignment : Assignment
{
    private string _writingInformation;

    public WritingAssignment(string studentName, string topic, string writingInformation) : base(studentName, topic)
    {
        _writingInformation = writingInformation;
    }

    public string GetWritingInformation()
    {
        return _writingInformation;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        string summary = assignment.GetSummary();
        Console.WriteLine(summary);

        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", 7);
        summary = mathAssignment.GetSummary();
        int homeworkList = mathAssignment.GetHomeworkList();

        Console.WriteLine(summary);
        Console.WriteLine($"Section {homeworkList} Problems 8-19");

        WritingAssignment writingAssignment = new WritingAssignment("John Doe", "Essay", "Introduction and Conclusion");
        summary = writingAssignment.GetSummary();
        string writingInformation = writingAssignment.GetWritingInformation();

        Console.WriteLine(summary);
        Console.WriteLine($"Writing information: {writingInformation}");
    }
}
