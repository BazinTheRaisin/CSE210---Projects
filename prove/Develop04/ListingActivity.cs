using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt spiritual peace this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing",
              "This activity will help you reflect on the good things in life by listing as many items as you can.")
    {}

    protected override void RunActivity()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");

        Console.Write("\nYou may begin in: ");
        Countdown(5);

        Console.WriteLine("\nStart listing items:");

        DateTime end = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
    }
}