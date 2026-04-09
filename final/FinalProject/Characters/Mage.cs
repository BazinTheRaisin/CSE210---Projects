using System;
using RpgBattleProject.Abilities;

namespace RpgBattleProject.Characters
{
    public class Mage : Character
    {
        public Mage(string name, int level = 1)
            : base(name, level, 25)
        {
            // Replace property assignments with setter methods
            SetAttackPower(3);
            SetMagicPower(12);

            // Replace Abilities.Add(...) with GetAbilities().Add(...)
            GetAbilities().Add(new Ability("Fireball", 0, 18, AbilityType.Magical));
        }

        public override void Attack(Character target)
        {
            // Replace Name with GetName()
            Console.WriteLine($"{GetName()} casts a weak spell at {target.GetName()}!");

            // Replace AttackPower with GetAttackPower()
            target.TakeDamage(GetAttackPower());
        }
    }
}
