
using System.Text.Json;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;
    static string goalsFilePath = "goals.bin";
    static string scoreFilePath = "score.txt";

    static void Main(string[] args)
    {
        LoadGoals();
        LoadScore();

        while (true)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. View goals");
            Console.WriteLine("2. Add goal");
            Console.WriteLine("3. Record event");
            Console.WriteLine("4. Save and quit");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    DisplayGoals();
                    break;
                case 2:
                    AddGoal();
                    break;
                case 3:
                    RecordEvent();
                    break;
                case 4:
                    SaveGoals();
                    SaveScore();
                    return;
            }
        }
    }

    static void DisplayGoals()
    {
        Console.WriteLine("Your current goals are:");

        for (int i = 0; i < goals.Count; i++)
        {
            string progress = goals[i].IsComplete() ? "[X]" : "[ ]";
            progress += $" {goals[i].Name} - {goals[i].GetProgressString()}";
            Console.WriteLine(progress);
        }

        Console.WriteLine($"Your current score is {score}.");
    }

    static void AddGoal()
    {
        Console.WriteLine("Please enter the name of the new goal:");
        string name = Console.ReadLine();

        Console.WriteLine("Please enter the type of goal (1 = simple, 2 = eternal, 3 = checklist):");
        int type = int.Parse(Console.ReadLine());

        Console.WriteLine("Please enter the value of the goal (e.g. 100 points, 5 times, etc.):");
        int value = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
                goals.Add(new SimpleGoal { Name = name, Value = value });
                break;
            case 2:
                goals.Add(new EternalGoal { Name = name, Value = value });
                break;
            case 3:
                Console.WriteLine("Please enter the number of times the goal must be completed to be considered finished:");
                int completionCount = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal { Name = name, Value = value, CompletionCount = completionCount });
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
        Console.WriteLine($"Goal '{name}' added successfully!");
    }

    static void RecordEvent()
    {
        Console.WriteLine("Please select the goal to record an event for:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("Please enter the number of events to record:");
        int eventCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < eventCount; i++)
        {
            goals[goalIndex].RecordEvent();
        }

        Console.WriteLine("Events recorded successfully!");
    }

    static void LoadGoals()
    {
        if (File.Exists(goalsFilePath))
        {
            string json = File.ReadAllText(goalsFilePath);
            goals = JsonSerializer.Deserialize<List<Goal>>(json);
        }
        else
        {
            Console.WriteLine("No goals file found. Starting with an empty list.");
        }

    }

    static void LoadScore()
    {
        if (File.Exists(scoreFilePath))
        {
            score = int.Parse(File.ReadAllText(scoreFilePath));
        }
    }

    static void SaveGoals()
    {
        string json = JsonSerializer.Serialize(goals);
        File.WriteAllText(goalsFilePath, json);

    }

    static void SaveScore()
    {
        File.WriteAllText(scoreFilePath, score.ToString());

        Console.WriteLine("Score saved successfully!");
    }
}
