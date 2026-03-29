using System;
using RpgBattleProject.Abilities;

namespace RpgBattleProject.Characters
{
    public class Warrior : Character
    {
        public Warrior(string name, int level = 1)
            : base(name, level, 40)
        {
            AttackPower = 10;
            MagicPower = 2;

            Abilities.Add(new Ability("Power Strike", 0, 15, AbilityType.Physical));
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} swings a sword at {target.Name}!");
            target.TakeDamage(AttackPower);
        }
    }
}