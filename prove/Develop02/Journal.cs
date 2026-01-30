public class Journal
    {
        public List<Entry> _entries = new List<Entry>();

        public void AddEntry(Entry newEntry)
        {
            _entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            Console.WriteLine("\n--- Journal Entries ---");
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
            Console.WriteLine("-----------------------");
        }

        public void SaveToFile(string file)
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(file))
                {
                    foreach (Entry entry in _entries)
                    {
                        outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
                    }
                }
                Console.WriteLine("Saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        public void LoadFromFile(string file)
        {
            try
            {
                _entries.Clear(); 

                string[] lines = System.IO.File.ReadAllLines(file);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');

                    if (parts.Length == 3)
                    {
                        string date = parts[0];
                        string prompt = parts[1];
                        string response = parts[2];

                        Entry loadedEntry = new Entry(date, prompt, response);
                        _entries.Add(loadedEntry);
                    }
                }
                Console.WriteLine("Loaded successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Please check the filename.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }
    }