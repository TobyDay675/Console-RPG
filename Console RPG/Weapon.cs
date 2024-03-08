using System;
using System.Collections.Generic;
using System.Text;
namespace Console_RPG
{
    class Weapon : Equipment
    {
        public int damage;

        public Weapon(string name, string description, int shopPrice, int sellPrice, int maxAmount, int damage) : base(name, description, shopPrice, sellPrice, maxAmount)
        {
            this.damage = damage;
        }

        public override void Equip(Entity user)
        {
            if (user.heldWeapon != null)
            {
                user.heldWeapon.UnEquip(user);
            }
            user.heldWeapon = this;
            this.isEquipped = true;
            
        }
        public override void UnEquip(Entity user)
        {
            if (user.heldWeapon == this) 
            {
                user.heldWeapon = null;
                this.isEquipped = false;
            }
            else
            {
                Console.WriteLine("You don't even have this equipped? Why are you trying to UnEquip it.");
            }
        }

        public override void Use(Entity user, Entity target)
        { }
    }
}