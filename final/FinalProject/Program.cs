using System;
using RpgBattleProject.Characters;
using RpgBattleProject.Battle;
using RpgBattleProject.Items;

namespace RpgBattleProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== RPG Character Simulator & Battle Engine ===");
            Console.Write("Enter your character name: ");
            string name = Console.ReadLine();

            Character player = ChooseCharacterClass(name);
            Character enemy = new Warrior("Goblin Warrior");

            // Replace Inventory.AddItem with GetInventory().AddItem(...)
            player.GetInventory().AddItem(new Item("Small Potion", "Heals a small amount of HP.", 10));

            BattleManager battle = new BattleManager(player, enemy);
            battle.StartBattle();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static Character ChooseCharacterClass(string name)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose your class:");
                Console.WriteLine("1. Warrior");
                Console.WriteLine("2. Mage");
                Console.WriteLine("3. Archer");
                Console.Write("Choice: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": return new Warrior(name);
                    case "2": return new Mage(name);
                    case "3": return new Archer(name);
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
