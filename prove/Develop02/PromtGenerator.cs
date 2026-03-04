public class PromptGenerator
    {
        public List<string> _prompts = new List<string>();

        public PromptGenerator()
        {
            // Adding the required prompts from the assignment description
            _prompts.Add("Who was the most interesting person I interacted with today?");
            _prompts.Add("What was the best part of my day?");
            _prompts.Add("How did I see the hand of the Lord in my life today?");
            _prompts.Add("What was the strongest emotion I felt today?");
            _prompts.Add("If I had one thing I could do over today, what would it be?");
            // Added extra custom prompts as requested
            _prompts.Add("What is a new idea I had today?");
            _prompts.Add("What was a small act of kindness I witnessed?");
        }

        public string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }
    }