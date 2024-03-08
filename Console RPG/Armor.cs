using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Armor : Equipment
    {
        public static Armor bubbleArmor = new Armor("Bubble Armor", "Suprisingly good armor", 100, 50, 1, 15);
        public static Armor ironArmor = new Armor("Iron Armor", "Steel of a deal", 2500, 50, 1, 25);
        public static Armor chickenSuit = new Armor("Chicken Suit", "You are now the chicken god", 2500, 50000, 1, 50);
        public static Armor nopePowerSuit = new Armor("Nope Power Suit", "You are ready to wreak havoc", shopPrice: 0, sellPrice: 100000, maxAmount: 1, defense: 100);

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