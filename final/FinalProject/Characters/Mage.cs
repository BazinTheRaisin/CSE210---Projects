using System;
using RpgBattleProject.Abilities;

namespace RpgBattleProject.Characters
{
    public class Mage : Character
    {
        public Mage(string name, int level = 1)
            : base(name, level, 25)
        {
            AttackPower = 3;
            MagicPower = 12;

            Abilities.Add(new Ability("Fireball", 0, 18, AbilityType.Magical));
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} casts a weak spell at {target.Name}!");
            target.TakeDamage(AttackPower);
        }
    }
}