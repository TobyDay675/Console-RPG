using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Ammo : Item
    {
        public static Ammo jerrysAllPurposeAmmo = new Ammo("Jerry's All Purpose Ammo", "For all your ammo filling needs", 250, 25, 32);

        public Ammo(string name, string description, int shopPrice, int sellPrice, int maxAmount) : base(name, description, shopPrice, sellPrice, maxAmount)
        { 
        }

        public override void Use(Entity user, Entity target)
        {
            Console.WriteLine($"This item will restore all the ammo to your held weapon.");
            if (user.heldWeapon is RangedWeapon castedweapon)
            {
                castedweapon.currentAmmo = castedweapon.maxAmmo;
                Player.inventory.Remove(this);
            }
            else if (user.heldWeapon is SpecialWeapon castedweapon2 && castedweapon2.isRanged == true)
            {
                castedweapon2.currentAmmo += castedweapon2.maxAmmo;
                Player.inventory.Remove(this);
            }
            else
            {
                Console.WriteLine("You aren't holding a weapon that uses ammo, use this somewhere else!");
            }

        }
    }
}
