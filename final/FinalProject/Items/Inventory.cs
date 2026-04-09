using System;
using System.Collections.Generic;
using RpgBattleProject.Characters;

namespace RpgBattleProject.Items
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public void AddItem(Item item)
        {
            _items.Add(item);
            Console.WriteLine($"{item.GetName()} added to inventory.");
        }

        public void UseItem(int index, Character target)
        {
            if (index < 0 || index >= _items.Count)
            {
                Console.WriteLine("Invalid item.");
                return;
            }

            Item item = _items[index];
            item.Use(target);
            _items.RemoveAt(index);
        }

        public void ListItems()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine("Inventory:");
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_items[i].GetName()} - {_items[i].GetDescription()}");
            }
        }
    }
}
