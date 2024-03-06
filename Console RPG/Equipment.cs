using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Item
    {
        public bool isEquipped;
        protected Equipment(string name, string description, int shopPrice, int sellPrice, int maxAmount) : base(name, description, shopPrice, sellPrice, maxAmount)
        {
            this.isEquipped = false;
        }

        public abstract void Equip(Entity user);
        public abstract void UnEquip(Entity user);
    }
}
