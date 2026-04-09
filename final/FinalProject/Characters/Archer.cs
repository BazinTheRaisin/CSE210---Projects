using System;
using RpgBattleProject.Abilities;

namespace RpgBattleProject.Characters
{
    public class Archer : Character
    {
        public Archer(string name, int level = 1)
            : base(name, level, 30)
        {
            // Replace property assignments with setter methods
            SetAttackPower(8);
            SetMagicPower(4);

            // Replace Abilities.Add(...) with GetAbilities().Add(...)
            GetAbilities().Add(new Ability("Piercing Arrow", 0, 14, AbilityType.Physical));
        }

        public override void Attack(Character target)
        {
            // Replace Name with GetName()
            Console.WriteLine($"{GetName()} shoots an arrow at {target.GetName()}!");

            // Replace AttackPower with GetAttackPower()
            target.TakeDamage(GetAttackPower());
        }
    }
}
