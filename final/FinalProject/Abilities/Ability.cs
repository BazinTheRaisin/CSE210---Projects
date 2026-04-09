using System;
using RpgBattleProject.Characters;

namespace RpgBattleProject.Abilities
{
    public class Ability
    {
        // Private fields
        private string _name;
        private int _cost;
        private int _power;
        private AbilityType _type;

        public Ability(string name, int cost, int power, AbilityType type)
        {
            _name = name;
            _cost = cost;
            _power = power;
            _type = type;
        }

        // Getters
        public string GetName() => _name;
        public int GetCost() => _cost;
        public int GetPower() => _power;
        public AbilityType GetAbilityType() => _type;

        // No setters needed — your original properties were read‑only

        public void Execute(Character user, Character target)
        {
            Console.WriteLine($"{user.GetName()} uses {_name} on {target.GetName()}!");
            target.TakeDamage(_power);
        }
    }
}
