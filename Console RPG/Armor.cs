using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Armor : Equipment
    {
        public int defense;

        public Armor(string name, string description, int shopPrice, int sellPrice, int maxAmount, int defense) : base(name, description, shopPrice, sellPrice, maxAmount)
        {
            this.defense = defense;
        }

        public override void Equip(Entity user)
        {
            user.equippedArmor = this;
            this.isEquipped = true;
            user.stats.defense += this.defense;
        }

        public override void UnEquip(Entity user)
        {
            if (user.equippedArmor == this)
            {
                user.equippedArmor= null;
                this.isEquipped = false;
                user.stats.defense -= this.defense;
            }
        }

        public override void Use(Entity user, Entity target)
        { 
        }

    }
}
