using System;
using RpgBattleProject.Characters;

namespace RpgBattleProject.Abilities
{
    public class Ability
    {
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public int Power { get; private set; }
        public AbilityType Type { get; private set; }

        public Ability(string name, int cost, int power, AbilityType type)
        {
            Name = name;
            Cost = cost;
            Power = power;
            Type = type;
        }

        public void Execute(Character user, Character target)
        {
            Console.WriteLine($"{user.Name} uses {Name} on {target.Name}!");
            target.TakeDamage(Power);
        }
    }
}