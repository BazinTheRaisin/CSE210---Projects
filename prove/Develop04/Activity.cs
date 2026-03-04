using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity!\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long (in seconds) would you like to do this activity? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        Spinner(3);

        RunActivity();

        End();
    }

    protected abstract void RunActivity();

    protected void End()
    {
        Console.WriteLine("\nGreat job! You have completed the activity.");
        Console.WriteLine($"You spent {_duration} seconds on the {_name} activity.");
        Console.WriteLine("Take a moment to reflect on how you feel.");
        Spinner(4);
    }

    protected void Spinner(int seconds)
    {
        string[] symbols = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(symbols[i % 4]);
            Thread.Sleep(200);
            Console.Write("\b");
            i++;
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}