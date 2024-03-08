using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
namespace Console_RPG
{
    class ManaWeapon : Weapon
    {
        public static ManaWeapon bubbleWand = new ManaWeapon("Bubble Wand", "How does this even cast spells", shopPrice: 500, sellPrice: 250, 1, damage: 200, manaUsed: 50);
        public static ManaWeapon plasticWand = new ManaWeapon("Plastic Wand", "Bippity Boppity Boo", shopPrice: 2000, sellPrice: 1000, 1, damage: 2000, manaUsed: 200);
        public static ManaWeapon ancientStaff = new ManaWeapon("Ancient Staff", "Summon doors to attack your enemies", shopPrice: 5000, sellPrice: 2500, 1, damage: 6000, manaUsed: 500);

        public int manaUsed;
        public ManaWeapon(string name, string description, int shopPrice, int sellPrice, int maxAmount, int damage, int manaUsed) : base(name, description, shopPrice, sellPrice, maxAmount, damage)
        {
            this.manaUsed = manaUsed;
        }
        public override void Use(Entity user, Entity target)
        {
            if (user.currentMana <= 0)
            {
                Console.WriteLine("You are out of mana");
                user.currentMana = user.stats.maxMana / 2;
                return;
            }
                

            target.currentHP -= this.damage;
            user.currentMana -= manaUsed;
        }
    }
}
