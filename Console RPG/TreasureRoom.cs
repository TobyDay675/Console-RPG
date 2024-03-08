using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class TreasureRoom : LocationFeature
    {
        public List<Item> nonEquipmentLoot;
        public List<Equipment> equipmentLoot;

        public TreasureRoom(List<Item> nonEquipmentLoot, List<Equipment> equipmentLoot) : base(false)
        {
            this.nonEquipmentLoot = nonEquipmentLoot;
            this.equipmentLoot = equipmentLoot;
        }
        public override void Resolve(List<Player> players)
        {
            Console.WriteLine("Seems like there is some loot here.\n");
            Console.WriteLine("Here I'll put them into your inventory.\n");
            foreach (var item in nonEquipmentLoot)
            {
                Console.WriteLine($"You got a/an {item.name}!");
                Player.inventory.Add(item);
            }
            foreach (var equipment in equipmentLoot)
            {
                Console.WriteLine($"You got a/an {equipment.name}!");
                Player.equipmentInventory.Add(equipment);
            }
            isResolved = true;
        }
    }
}