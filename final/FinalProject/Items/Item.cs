using System;
using RpgBattleProject.Characters;

namespace RpgBattleProject.Items
{
    public class Item
    {
        // Private fields
        private string _name;
        private string _description;
        private int _value;

        public Item(string name, string description, int value)
        {
            _name = name;
            _description = description;
            _value = value;
        }

        // Getters
        public string GetName() => _name;
        public string GetDescription() => _description;
        public int GetValue() => _value;

        // No setters needed — original properties were read‑only

        public void Use(Character target)
        {
            Console.WriteLine($"{target.GetName()} uses {_name}.");
            target.Heal(_value);
        }
    }
}
