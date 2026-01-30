namespace JournalProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal theJournal = new Journal();
            PromptGenerator promptGen = new PromptGenerator();

            Console.WriteLine("Welcome to the Journal Program!");

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\nPlease select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Get Random Prompt
                        string prompt = promptGen.GetRandomPrompt();
                        Console.WriteLine($"\n{prompt}");
                        
                        // Get User Input
                        Console.Write("> ");
                        string response = Console.ReadLine();
                        string date = DateTime.Now.ToShortDateString();

                        // Create Entry and Add to Journal
                        Entry newEntry = new Entry(date, prompt, response);
                        theJournal.AddEntry(newEntry);
                        break;

                    case "2":
                        theJournal.DisplayAll();
                        break;

                    case "3":
                        Console.Write("What is the filename? ");
                        string loadFile = Console.ReadLine();
                        theJournal.LoadFromFile(loadFile);
                        break;

                    case "4":
                        Console.Write("What is the filename? ");
                        string saveFile = Console.ReadLine();
                        theJournal.SaveToFile(saveFile);
                        break;

                    case "5":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}