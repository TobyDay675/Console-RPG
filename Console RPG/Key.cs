using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    internal class Key : Item
    {
        public static Key finalDoorKey = new Key("Large Ornate Key", "Seems like it could unlock a giant door.", 0, 0, 1, Location.theFinalDoor);
        public Location locationItUnlocks;

        public Key(string name, string description, int shopPrice, int sellPrice, int maxAmount, Location locationItUnlocks = null) : base(name, description, shopPrice, sellPrice, maxAmount)
        {
            this.locationItUnlocks = locationItUnlocks;
        }

        public override void Use(Entity user, Entity target)
        {
            locationItUnlocks.unlockedByDefault = true;
            Console.WriteLine($"You just unlocked {locationItUnlocks.name}\n");
        }
    }
}
