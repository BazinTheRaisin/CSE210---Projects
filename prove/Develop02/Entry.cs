public class Entry
    {
        public string _date;
        public string _promptText;
        public string _entryText;

        public Entry(string date, string prompt, string response)
        {
            _date = date;
            _promptText = prompt;
            _entryText = response;
        }

        public void Display()
        {
            Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
            Console.WriteLine($"{_entryText}");
            Console.WriteLine(); // Empty line for spacing
        }
    }