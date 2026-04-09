using System;
using System.Collections.Generic;
using RpgBattleProject.Items;
using RpgBattleProject.Abilities;

namespace RpgBattleProject.Characters
{
    public abstract class Character
    {
        // Private fields
        private string _name;
        private int _level;
        private int _maxHealth;
        private int _currentHealth;
        private int _attackPower;
        private int _magicPower;
        private Inventory _inventory;
        private List<Ability> _abilities;

        protected Character(string name, int level, int maxHealth)
        {
            _name = name;
            _level = level;
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
            _inventory = new Inventory();
            _abilities = new List<Ability>();
        }

        // Getters
        public string GetName() => _name;
        public int GetLevel() => _level;
        public int GetMaxHealth() => _maxHealth;
        public int GetCurrentHealth() => _currentHealth;
        public int GetAttackPower() => _attackPower;
        public int GetMagicPower() => _magicPower;
        public Inventory GetInventory() => _inventory;
        public List<Ability> GetAbilities() => _abilities;

        // Setters (only where your original properties allowed setting)
        public void SetCurrentHealth(int value) => _currentHealth = value;
        public void SetAttackPower(int value) => _attackPower = value;
        public void SetMagicPower(int value) => _magicPower = value;

        // Optional setters (if you want to allow changing these)
        public void SetLevel(int value) => _level = value;
        public void SetName(string value) => _name = value;

        // Replaces: public bool IsAlive => CurrentHealth > 0;
        public bool IsAlive()
        {
            return _currentHealth > 0;
        }

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            if (_currentHealth < 0)
                _currentHealth = 0;

            Console.WriteLine($"{_name} takes {amount} damage. HP: {_currentHealth}/{_maxHealth}");
        }

        public void Heal(int amount)
        {
            _currentHealth += amount;
            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;

            Console.WriteLine($"{_name} heals {amount} HP. HP: {_currentHealth}/{_maxHealth}");
        }

        public abstract void Attack(Character target);

        public virtual void UseAbility(int index, Character target)
        {
            if (index < 0 || index >= _abilities.Count)
            {
                Console.WriteLine("Invalid ability.");
                return;
            }

            _abilities[index].Execute(this, target);
        }
    }
}
