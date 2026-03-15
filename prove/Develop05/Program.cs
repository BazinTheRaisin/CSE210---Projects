using System;
//I added a leveling system to my program for the extra points
class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("\n--- Eternal Quest ---");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": manager.CreateGoal(); break;
                case "2": manager.ShowGoals(); break;
                case "3": manager.RecordEvent(); break;
                case "4": manager.ShowScore(); break;
                case "5": manager.Save(); break;
                case "6": manager.Load(); break;
                case "7": return;
            }
        }
    }
}