using System;
using RpgBattleProject.Characters;

namespace RpgBattleProject.Items
{
    public class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Value { get; private set; }

        public Item(string name, string description, int value)
        {
            Name = name;
            Description = description;
            Value = value;
        }

        public void Use(Character target)
        {
            Console.WriteLine($"{target.Name} uses {Name}.");
            target.Heal(Value);
        }
    }
}