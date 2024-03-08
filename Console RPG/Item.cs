using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public string name;
        public string description;

        public int shopPrice;
        public int sellPrice;
        public int maxAmount;

        public Item(string name, string description, int shopPrice, int sellPrice, int maxAmount)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.sellPrice = sellPrice;
            this.maxAmount = maxAmount;
        }

        public abstract void Use(Entity user, Entity target);
    }
}