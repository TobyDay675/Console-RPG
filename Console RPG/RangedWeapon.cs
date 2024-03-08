using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
namespace Console_RPG
{
    class RangedWeapon : Weapon
    {
        public static RangedWeapon basicBow = new RangedWeapon("Basic Bow", "Bing Boom", shopPrice: 50, sellPrice: 25, 1, damage: 55, ammo: 100, maxAmmo: 100);
        public static RangedWeapon crossbow = new RangedWeapon("Crossbow", "You don't wanna cross me", shopPrice: 100, sellPrice: 50, 1, damage: 150, ammo: 200, maxAmmo: 200);
        public static RangedWeapon thumbTackLauncher = new RangedWeapon("Thumb Tack Launcher", "OWWWWWWWW", shopPrice: 600, sellPrice: 300, 1, damage: 400, ammo: 500, maxAmmo: 500);
        public static RangedWeapon pickaxeGun = new RangedWeapon("Pickaxe Gun", "Mining the American way", shopPrice: 2600, sellPrice: 1300, 1, damage: 2500, ammo: 45, maxAmmo: 45);

        public int currentAmmo;
        public int maxAmmo;
        public RangedWeapon(string name, string description, int shopPrice, int sellPrice, int maxAmount, int damage, int ammo, int maxAmmo) : base(name, description, shopPrice, sellPrice, maxAmount, damage)
        {
            this.currentAmmo = ammo;
            this.maxAmmo = maxAmmo;
        }
        public override void Use(Entity user, Entity target)
        {
            if (currentAmmo == 0)
            {
                Console.WriteLine("You are out of ammo, your turn is skipped.\n");
                return;
            }
            target.currentHP -= (this.damage + 10 + user.stats.strength) - target.stats.defense;
            currentAmmo -= maxAmmo / 8;
        }
    }
}