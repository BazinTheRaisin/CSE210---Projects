using System;
using RpgBattleProject.Abilities;

namespace RpgBattleProject.Characters
{
    public class Archer : Character
    {
        public Archer(string name, int level = 1)
            : base(name, level, 30)
        {
            AttackPower = 8;
            MagicPower = 4;

            Abilities.Add(new Ability("Piercing Arrow", 0, 14, AbilityType.Physical));
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} shoots an arrow at {target.Name}!");
            target.TakeDamage(AttackPower);
        }
    }
}