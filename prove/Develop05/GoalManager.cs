using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // NEW: Leveling system
    private int _level = 1;
    private int _xp = 0;

    private int XPToNextLevel => _level * 1000; // simple formula

    public void AddXP(int amount)
    {
        _xp += amount;

        while (_xp >= XPToNextLevel)
        {
            _xp -= XPToNextLevel;
            _level++;

            Console.WriteLine($"\n🎉 LEVEL UP! You reached Level {_level}!");
            Console.WriteLine("Keep going — your Eternal Quest continues.");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nChoose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string choice = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;

            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;

            case "3":
                Console.Write("Target count: ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nWhich goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].Name}");

        Console.Write("Choice: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"\nYou earned {earned} points!");

        // NEW: XP gain
        AddXP(earned);
    }

    public void ShowGoals()
    {
        Console.WriteLine("\nYour Goals:");
        foreach (Goal g in _goals)
            Console.WriteLine($"{g.GetStatus()} {g.Name} — {g.Description}");
    }

    public void ShowScore()
    {
        Console.WriteLine($"\nScore: {_score}");
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"XP: {_xp}/{XPToNextLevel}");
    }

    public void Save()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(file))
        {
            sw.WriteLine(_score);
            sw.WriteLine(_level);
            sw.WriteLine(_xp);

            foreach (Goal g in _goals)
                sw.WriteLine(g.Serialize());
        }
    }

    public void Load()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        _goals.Clear();

        string[] lines = File.ReadAllLines(file);

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        _xp = int.Parse(lines[2]);

        for (int i = 3; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string type = parts[0];

            if (type == "Simple")
            {
                _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (type == "Eternal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (type == "Checklist")
            {
                _goals.Add(new ChecklistGoal(
                    parts[1], parts[2], int.Parse(parts[3]),
                    int.Parse(parts[4]), int.Parse(parts[6])
                ));
            }
        }
    }
}