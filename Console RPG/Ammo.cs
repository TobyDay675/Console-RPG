using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Ammo : Item
    {
        int ammoRestored;

        public Ammo(string name, string description, int shopPrice, int sellPrice, int maxAmount, int ammoRestored) : base(name, description, shopPrice, sellPrice, maxAmount)
        {
            this.ammoRestored = ammoRestored;   
        }

        public override void Use(Entity user, Entity target)
        {
            Console.WriteLine($"This item will restore {ammoRestored} ammo to your held weapon.");
            if (user.heldWeapon is RangedWeapon castedweapon)
            {
                castedweapon.ammo += this.ammoRestored;
                Player.inventory.Remove(this);
            }
            else if (user.heldWeapon is RangedWeapon castedweapon2)
            {
                castedweapon2.ammo += this.ammoRestored;
                Player.inventory.Remove(this);
            }
            else
            {
                Console.WriteLine("You aren't holding a weapon that uses ammo, use this somewhere else!");
            }

        }
    }
}
