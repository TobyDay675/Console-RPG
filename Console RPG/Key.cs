using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    internal class Key : Item
    {
        public Location locationItUnlocks;

        public Key(string name, string description, int shopPrice, int sellPrice, int maxAmount, Location locationItUnlocks = null) : base(name, description, shopPrice, sellPrice, maxAmount)
        {
            this.locationItUnlocks = locationItUnlocks;
        }

        public override void Use(Entity user, Entity target)
        {
            
        }
    }
}
