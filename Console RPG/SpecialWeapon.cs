using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class SpecialWeapon : Weapon
    {
        public static SpecialWeapon lightingGavel = new SpecialWeapon("Lightning Gavel", "Wielded by the great Chicken Guardian", shopPrice: 0, sellPrice: 10000, maxAmount: 1, damage: 3000, ammo: 0, manaUsed: 150, isMagic: true);
        public int ammo;
        public int manaUsed;
        public bool isMagic;
        public bool isRanged;
        public SpecialWeapon(string name, string description, int shopPrice, int sellPrice, int maxAmount, int damage, int ammo, int manaUsed, bool isMagic = false, bool isRanged = false) : base(name, description, shopPrice, sellPrice, maxAmount, damage)
        {
            this.ammo = ammo;
            this.manaUsed = manaUsed;
            this.isMagic = isMagic;
            this.isRanged = isRanged;
        }
        public override void Use(Entity user, Entity target)
        {
            int calculatedDamage = (this.damage + user.stats.strength) - target.stats.defense;
            Console.WriteLine("This weapon has multiple different abilities (type in the number of the ability you want to use):");
            if (this.isMagic == true && this.isRanged == false) 
            {
                while (true)
                {
                    Console.WriteLine("1: Melee Attack\n");
                    Console.WriteLine("2: Magic Attack\n");
                    string attackOption = Console.ReadLine();

                    if (attackOption == "1")
                    {
                        target.currentHP -= calculatedDamage;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{this.name} attacked {target.name} for {calculatedDamage} damage!\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{target.name}'s hp is now: {target.currentHP}\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    if (attackOption == "2" || user.currentMana > 0)
                    {
                        target.currentHP -= this.damage;
                        user.currentMana -= manaUsed;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{this.name} zapped {target.name} for {this.damage} damage!\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{target.name}'s hp is now: {target.currentHP}\n");
                        Console.WriteLine($"You now have {user.currentMana} mana left\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    if (attackOption == "2" || user.currentMana <= 0)
                    {
                        Console.WriteLine("Hey you are out of mana you should melee attack instead.");
                    }
                }
            }
            else if  (this.isRanged == true && this.isMagic == false) 
            {
                while (true)
                {
                    Console.WriteLine("1: Melee Attack\n");
                    Console.WriteLine("2: Ranged Attack\n");
                    string attackOption = Console.ReadLine();

                    if (attackOption == "1")
                    {
                        target.currentHP -= calculatedDamage;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{this.name} attacked {target.name} for {calculatedDamage} damage!\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{target.name}'s hp is now: {target.currentHP}\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    if (attackOption == "2" || this.ammo > 0)
                    {
                        target.currentHP -= (this.damage + 10 + user.stats.strength) - target.stats.defense;
                        --ammo;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{this.name} attacked {target.name} for {calculatedDamage + 10} damage!\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{target.name}'s hp is now: {target.currentHP}\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    if (attackOption == "2" || this.ammo <= 0)
                    {
                        Console.WriteLine("Hey you are out of ammo you should melee attack instead.");
                    }
                }
            }
            else if (this.isRanged == true && this.isMagic == true)
            {
                while (true)
                {
                    Console.WriteLine("1: Melee Attack\n");
                    Console.WriteLine("2: Ranged Attack\n");
                    Console.WriteLine("3: Magic Attack\n");
                    string attackOption = Console.ReadLine();

                    if (attackOption == "1")
                    {
                        target.currentHP -= calculatedDamage;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{this.name} attacked {target.name} for {calculatedDamage} damage!\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{target.name}'s hp is now: {target.currentHP}\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    if (attackOption == "2" || this.ammo > 0)
                    {
                        target.currentHP -= (this.damage + 10 + user.stats.strength) - target.stats.defense;
                        --ammo;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{this.name} attacked {target.name} for {calculatedDamage + 10} damage!\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{target.name}'s hp is now: {target.currentHP}\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    if (attackOption == "2" || this.ammo <= 0)
                    {
                        Console.WriteLine("Hey you are out of ammo you should melee attack instead or a magic attack if you have mana.");
                    }
                    if (attackOption == "3" || user.currentMana > 0)
                    {
                        target.currentHP -= this.damage;
                        user.currentMana -= manaUsed;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{this.name} zapped {target.name} for {this.damage} damage!\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{target.name}'s hp is now: {target.currentHP}\n");
                        Console.WriteLine($"You now have {user.currentMana} mana left\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    if (attackOption == "3" || user.currentMana <= 0)
                    {
                        Console.WriteLine("Hey you are out of mana you should melee attack instead or a ranged attack if you have the ammo.");
                    }
                }
            }
            else
            {
                Console.WriteLine("How did you even find a weapon with out other abilities.");
                Console.WriteLine("This is literally just a melee weapon then, how did I not notice this?");
                Console.WriteLine("I don't think this dialogue will even be able to be found in game... why am I writing this?");
                return;
            }
        }
    }
}
