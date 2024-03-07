﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Console_RPG
{
    class Player : Entity
    {
        public static List<Item> inventory = new List<Item>() { };
        public static List<Equipment> equipmentInventory = new List<Equipment>() { };
        public int levelUpCeiling = 100; 

        public static Player player = new Player("Player", hp: 50, mana: 25, new Stats(strength: 15, defense: 0, hp: 50, mana: 25), level: 1, exp: 0, doorknob: 1000);
        
        public int level; 
        public int currentExperience;
        public int doorKnobCount;

        public Stats levelUpIncrease = new Stats(10, 5, 10, 25);

        public Player(string name, int hp, int mana, Stats stats, int level, int exp, int doorknob) : base(name, hp, mana, stats)
        {
            this.level = level;
            this.currentExperience = exp;
            this.doorKnobCount = doorknob;
        }

        public override Entity ChooseTarget(List<Entity> choices)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Type in the number of the entity you want to target:\n");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1}: {choices[i].name}");
            }

            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
            catch (Exception ex)
            {
                return ChooseTarget(choices);
            }

        }
        public Item ChooseItem(List<Item> choices)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Type in the number of the item you want to use:\n");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1}: {choices[i].name}");
            }
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
            catch (Exception ex)
            {
                return ChooseItem(choices);
            }
        }
        public static Equipment ChooseEquipment(List<Equipment> choices)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Type in the number of the item you want to equip/unequip:\n");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1}: {choices[i].name} (Is the item Equipped: {choices[i].isEquipped})");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
            catch (Exception ex)
            {
                return ChooseEquipment(choices);
            }
        }

        public override void Attack(Entity target, Entity user)
        {
            if (heldWeapon == null)
            {
                Console.WriteLine("You have no weapon so you simply use your fists.\n");
                int calculatedFistDamage = this.stats.strength - target.stats.defense;
                target.currentHP -= calculatedFistDamage;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{this.name} attacked {target.name} for {calculatedFistDamage} damage!\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{target.name}'s hp is now: {target.currentHP}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (heldWeapon is ManaWeapon)
            {
                heldWeapon.Use(user, target);
                Console.ForegroundColor= ConsoleColor.Yellow; 
                Console.WriteLine($"{this.name} attacked {target.name} for {heldWeapon.damage} damage!\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{target.name}'s hp is now: {target.currentHP}\n");
                Console.WriteLine($"You now have {this.currentMana} mana left\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (heldWeapon is RangedWeapon)
            {
                int calculatedDamage = (heldWeapon.damage + user.stats.strength) - target.stats.defense;
                heldWeapon.Use(user, target);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{this.name} attacked {target.name} for {calculatedDamage + 10} damage!\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{target.name}'s hp is now: {target.currentHP}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (heldWeapon is MeleeWeapon)
            {
                int calculatedDamage = (heldWeapon.damage + user.stats.strength) - target.stats.defense;
                target.currentHP -= calculatedDamage;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{this.name} attacked {target.name} for {calculatedDamage} damage!\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{target.name}'s hp is now: {target.currentHP}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (heldWeapon is SpecialWeapon)
            {
                heldWeapon.Use(user, target);
            }
        }
        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Console.WriteLine("What do you want to do?");
            if (heldWeapon is RangedWeapon castedWeapon)
            {
                Console.WriteLine($"Hey just so you know you have {castedWeapon.ammo} ammo left.. don't know if you want to use your weapon or not");
            }
            else if (heldWeapon is ManaWeapon castedWeapon2)
            {
                Console.WriteLine($"Hey just so you know you have {Player.player.currentMana} mana left.. don't know if you want to use your weapon or not");
            }
            Console.WriteLine("ATTACK || INVENTORY");
            string choice = Console.ReadLine();
            if (choice == "ATTACK")
            {
                Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                Attack(target, this);
            }
            else if (choice == "INVENTORY")
            {
                Inventory(Player.player); 
            }
            else
            {
                Console.WriteLine("Try that again!");
                DoTurn(players, enemies);
            }
            
        }
        
        public void LevelUp()
        {
            if (this.currentExperience > levelUpCeiling) 
            {
                this.level++;
                this.stats.maxHP += levelUpIncrease.maxHP;
                this.currentExperience = levelUpCeiling - this.currentExperience;
                levelUpCeiling += levelUpCeiling;
                this.currentHP = this.stats.maxHP;
                this.currentMana = this.stats.maxMana;
                levelUpIncrease.maxHP = levelUpIncrease.maxHP + 5;
                levelUpIncrease.maxMana = levelUpIncrease.maxMana + 5;
                levelUpIncrease.strength = levelUpIncrease.strength + 5;
                levelUpIncrease.defense = levelUpIncrease.defense + 5;
                Console.WriteLine($"You leveled up!! Your level is now {this.level}. Keep on keeping on!\n");


            }
        }
        public static void Inventory(Player player)
        {
            List<Entity> playerChoice = new List<Entity>() { player };
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What do you want to do?\n");
                Console.WriteLine("USE ITEM || SWITCH EQUIP || STATS || LEAVE\n");
                string choice = Console.ReadLine();
                if (choice == "USE ITEM")
                {
                    if (Player.inventory.Count == 0)
                    {
                        Console.WriteLine("You've got nothing to use\n");
                    }
                    else
                    {
                        Item item = Player.player.ChooseItem(Player.inventory);
                        Entity target = Player.player.ChooseTarget(playerChoice);
                        item.Use(player, target);
                        Player.inventory.Remove(item);
                        break;
                    }
                }
                else if (choice == "SWITCH EQUIP")
                {
                    if (Player.equipmentInventory.Count == 0)
                    {
                        Console.WriteLine("You've have no equipments.\n");
                    }
                    else
                    {
                        Equipment equipment = ChooseEquipment(Player.equipmentInventory);
                        if (equipment.isEquipped == false)
                        {
                            equipment.Equip(Player.player);
                            Console.WriteLine($"You have now equipped {equipment.name}\n");
                        }
                        else if (equipment.isEquipped == true)
                        {
                            equipment.UnEquip(Player.player);
                            Console.WriteLine($"You have now unequpped {equipment.name}\n");
                        }
                    }
                    break;
                }
                else if (choice == "STATS")
                {
                    Console.WriteLine("Here are your stats.\n");
                    Console.WriteLine($"Max HP: {player.stats.maxHP}\n");
                    Console.WriteLine($"Max Mana: {player.stats.maxMana}\n");
                    Console.WriteLine($"Strength: {player.stats.strength} \n");
                    Console.WriteLine($"Defense: {player.stats.defense} \n");
                    Console.WriteLine($"Level: {player.level}\n");
                    Console.WriteLine($"Exp: {player.currentExperience}\n");
                    Console.WriteLine($"Doorknob Count: {player.doorKnobCount}\n");
                    if (player.heldWeapon != null)
                    {
                        Console.WriteLine($"Equipped Weapon: {player.heldWeapon.name}\n");
                    }

                    if (player.equippedArmor != null)
                    {
                        Console.WriteLine($"Equipped Armor: {player.equippedArmor.name}\n");
                    }

                }
                else if (choice == "LEAVE")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                }
                else
                {
                    Console.WriteLine("That's not an option try again!\n");
                }
            }
        }

    }


}