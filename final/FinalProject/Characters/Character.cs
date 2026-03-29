using System;
using System.Collections.Generic;
using RpgBattleProject.Items;
using RpgBattleProject.Abilities;

namespace RpgBattleProject.Characters
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public int AttackPower { get; protected set; }
        public int MagicPower { get; protected set; }

        public Inventory Inventory { get; private set; }
        public List<Ability> Abilities { get; private set; }

        protected Character(string name, int level, int maxHealth)
        {
            Name = name;
            Level = level;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            Inventory = new Inventory();
            Abilities = new List<Ability>();
        }

        public bool IsAlive => CurrentHealth > 0;

        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
            if (CurrentHealth < 0) CurrentHealth = 0;

            Console.WriteLine($"{Name} takes {amount} damage. HP: {CurrentHealth}/{MaxHealth}");
        }

        public void Heal(int amount)
        {
            CurrentHealth += amount;
            if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;

            Console.WriteLine($"{Name} heals {amount} HP. HP: {CurrentHealth}/{MaxHealth}");
        }

        public abstract void Attack(Character target);

        public virtual void UseAbility(int index, Character target)
        {
            if (index < 0 || index >= Abilities.Count)
            {
                Console.WriteLine("Invalid ability.");
                return;
            }

            Abilities[index].Execute(this, target);
        }
    }
}