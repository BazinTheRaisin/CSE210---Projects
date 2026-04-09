using System;
using RpgBattleProject.Abilities;

namespace RpgBattleProject.Characters
{
    public class Warrior : Character
    {
        public Warrior(string name, int level = 1)
            : base(name, level, 40)
        {
            // Replace property assignments with setter methods
            SetAttackPower(10);
            SetMagicPower(2);

            // Replace Abilities.Add(...) with GetAbilities().Add(...)
            GetAbilities().Add(new Ability("Power Strike", 0, 15, AbilityType.Physical));
        }

        public override void Attack(Character target)
        {
            // Replace Name with GetName()
            Console.WriteLine($"{GetName()} swings a sword at {target.GetName()}!");

            // Replace AttackPower with GetAttackPower()
            target.TakeDamage(GetAttackPower());
        }
    }
}
