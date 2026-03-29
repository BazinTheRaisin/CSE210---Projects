using System;
using RpgBattleProject.Characters;

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
            Console.WriteLine("=== Battle Start ===");
            Console.WriteLine($"{_player.Name} vs {_enemy.Name}");
            Console.WriteLine();

            while (_player.IsAlive && _enemy.IsAlive)
            {
                PlayerTurn();
                if (!_enemy.IsAlive) break;

                EnemyTurn();
            }

            Console.WriteLine(_player.IsAlive ? $"{_player.Name} wins!" : $"{_enemy.Name} wins!");
        }

        private void PlayerTurn()
        {
            Console.WriteLine();
            Console.WriteLine("Your turn!");
            Console.WriteLine("1. Basic Attack");
            Console.WriteLine("2. Use Ability");
            Console.WriteLine("3. Use Item");
            Console.Write("Choose an action: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    _player.Attack(_enemy);
                    break;

                case "2":
                    UseAbilityMenu();
                    break;

                case "3":
                    UseItemMenu();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void UseAbilityMenu()
        {
            if (_player.Abilities.Count == 0)
            {
                Console.WriteLine("You have no abilities.");
                return;
            }

            Console.WriteLine("Choose an ability:");
            for (int i = 0; i < _player.Abilities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_player.Abilities[i].Name}");
            }

            Console.Write("Ability number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                _player.UseAbility(choice - 1, _enemy);
            }
        }

        private void UseItemMenu()
        {
            _player.Inventory.ListItems();
            Console.Write("Item number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                _player.Inventory.UseItem(choice - 1, _player);
            }
        }

        private void EnemyTurn()
        {
            Console.WriteLine();
            Console.WriteLine("Enemy turn!");
            _enemy.Attack(_player);
        }
    }
}