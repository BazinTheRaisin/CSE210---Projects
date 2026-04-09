using RpgBattleProject.Characters;
using System;

namespace RpgBattleProject.Battle
{
    public class BattleManager
    {
        private Character _player;
        private Character _enemy;

        public BattleManager(Character player, Character enemy)
        {
            _player = player;
            _enemy = enemy;
        }

        public void StartBattle()
        {
            Console.WriteLine($"Battle start - {_player.GetName()} vs {_enemy.GetName()}");

            while (_player.IsAlive() && _enemy.IsAlive())
            {
                PlayerTurn();
                if (!_enemy.IsAlive()) break;

                EnemyTurn();
            }

            Console.WriteLine(_player.IsAlive()
                ? $"{_player.GetName()} wins!"
                : $"{_enemy.GetName()} wins!");
        }

        private void PlayerTurn()
        {
            Console.WriteLine($"{_player.GetName()}'s turn!");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use Ability");
            Console.WriteLine("3. Inventory");

            Console.Write("Choose an action: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    _player.Attack(_enemy);
                    break;
                case "2":
                    UseAbilityMenu();
                    break;
                case "3":
                    InventoryMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void UseAbilityMenu()
        {
            var abilities = _player.GetAbilities();

            if (abilities.Count == 0)
            {
                Console.WriteLine("You have no abilities.");
                return;
            }

            Console.WriteLine("Choose an ability:");
            for (int i = 0; i < abilities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {abilities[i].GetName()}");
            }

            Console.Write("Ability number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                _player.UseAbility(choice - 1, _enemy);
            }
        }

        private void InventoryMenu()
        {
            var inventory = _player.GetInventory();

            inventory.ListItems();

            Console.Write("Choose item to use: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                inventory.UseItem(choice - 1, _player);
            }
        }

        private void EnemyTurn()
        {
            Console.WriteLine($"{_enemy.GetName()}'s turn!");
            _enemy.Attack(_player);
        }
    }
}
