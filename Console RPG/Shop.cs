﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Shop : LocationFeature
    {
        public string shopName;
        public List<Item> items;
        public List<Equipment> equipments;

        public Shop(string shopName, List<Item> items, List<Equipment> equipment) : base(false)
        {
            this.shopName = shopName;
            this.items = items;
            this.equipments = equipment;
        }

        public override void Resolve(List<Player> players)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Welcome to the {shopName}!\n");
            
            
            while (true)
            {
                Console.WriteLine("What do you want to do?\n");
                Console.WriteLine("BUY || SELL || STEAL || WALLET || INVENTORY || LEAVE\n");
                string choice = Console.ReadLine();

                if (choice == "BUY")
                {
                    Console.WriteLine("Do you want to buy: ITEMS || EQUIPMENTS\n");
                    string buyChoice = Console.ReadLine();
                    if (buyChoice == "ITEMS")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"You have {Player.player.doorKnobCount} doorknobs\n");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Item item = ChooseItemBuy(this.items);
                        if (Player.player.doorKnobCount >= item.shopPrice)
                        {
                            Player.player.doorKnobCount -= item.shopPrice;
                            Player.inventory.Add(item);
                            Console.WriteLine($"You bought a {item.name}!\n");
                        }
                        else if (Player.player.doorKnobCount < item.shopPrice)
                        {
                            Console.WriteLine("You don't have enough doorknobs for that!\n");
                            Console.WriteLine("Buy something else or get out!\n");
                        }
                    }
                    if (buyChoice == "EQUIPMENTS")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"You have {Player.player.doorKnobCount} doorknobs\n");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Equipment equipment = ChooseEquipmentBuy(this.equipments);
                        if (Player.player.doorKnobCount >= equipment.shopPrice)
                        {
                            Player.player.doorKnobCount -= equipment.shopPrice;
                            Player.equipmentInventory.Add(equipment);
                            Console.WriteLine($"You bought a {equipment.name}!\n");
                        }
                        else if (Player.player.doorKnobCount < equipment.shopPrice)
                        {
                            Console.WriteLine("You don't have enough doorknobs for that!\n");
                            Console.WriteLine("Buy something else or get out!\n");
                        }
                    }

                }
                else if (choice == "SELL")
                {
                    Console.WriteLine("Oh selling I see... well lets see your wares.\n");
                    Console.WriteLine("Are you selling: ITEMS || EQUIPMENTS\n");
                    string sellChoice = Console.ReadLine();
                    if (sellChoice == "ITEMS")
                    {
                        Item item = ChooseItemSell(Player.inventory);
                        Player.player.doorKnobCount += item.sellPrice;
                        Player.inventory.Remove(item);
                        Console.WriteLine($"You just sold a {item.name}! I hope you don't regret that.\n");
                    }
                    if (sellChoice == "EQUIPMENTS")
                    {
                        Item equipment = ChooseEquipmentSell(Player.equipmentInventory);
                        Player.player.doorKnobCount += equipment.sellPrice;
                        Player.inventory.Remove(equipment);
                        Console.WriteLine($"You just sold a {equipment.name}! I hope you don't regret that.\n");
                    }
                }
                else if (choice == "STEAL")
                {
                    Random random = new Random();
                    int doesStealWork = random.Next(1, 7);
                    if (this.items.Count != 0 || this.equipments.Count != 0)
                    {
                        if (doesStealWork != 6)
                        {
                            Console.WriteLine("You are so evil... what do you want to steal: ITEM || EQUIPMENT\n");
                            string stealOption = Console.ReadLine();
                            if (stealOption == "ITEM")
                            {
                                Item item = ChooseItemSteal(this.items);
                                Player.inventory.Add(item);
                                this.items.Remove(item);
                                Console.WriteLine($"You just stole a {item.name}! You are a horrible person.\n");
                            }
                            if (stealOption == "EQUIPMENT")
                            {
                                Equipment equipment = ChooseEquipmentSteal(this.equipments);
                                Player.inventory.Add(equipment);
                                this.items.Remove(equipment);
                                Console.WriteLine($"You just stole a {equipment.name}! You are a horrible person.\n");
                            }
                        }
                        else if (doesStealWork == 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; 
                            Console.WriteLine("YOU ARE TRYING TO STEAL FROM ME!!!!\n");
                            Console.WriteLine($"THATS IT GET THE FLIP OUT OF MY SHOP!!!");
                            this.isResolved = true;
                            break;
                        }
                    }
                    else if (this.items.Count == 0 && this.equipments.Count == 0)
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("You stole everything from the shop with out the shopkeeper realizing.\n");
                        Console.WriteLine("What an idiot... anyway there is no point to going back here so I'll just close it up.\n");
                        this.isResolved = true;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    } 
                }
                else if (choice == "WALLET")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"You have {Player.player.doorKnobCount} doorknobs\n");
                    Console.WriteLine($"Go buy something!\n");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else if (choice == "INVENTORY")
                {
                    Inventory(Player.player);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else if (choice == "LEAVE")
                {
                    Console.WriteLine($"Finally you are leaving!\n");
                    break;
                }
                else
                {
                    Console.WriteLine("You can't do that here! Try something else.\n");
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            
        }
        public Item ChooseItemBuy(List<Item> choices)
        {
            Console.WriteLine("Type in the number of the item you want to BUY:\n");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].shopPrice} doorknobs)\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
            catch (Exception ex)
            {
                return ChooseItemBuy(choices);
            }

        }
        public static Equipment ChooseEquipmentBuy(List<Equipment> choices)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Type in the number of the item you want to BUY:\n");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].shopPrice} doorknobs)");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
            catch (Exception ex)
            {
                return ChooseEquipmentBuy(choices);
            }
        }
        public Item ChooseItemSell(List<Item> choices)
        {
            Console.WriteLine("Type in the number of the item you want to SELL:\n");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].sellPrice} doorknobs)\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
            catch (Exception ex)
            {
                return ChooseItemSell(choices);
            }

        }
        public static Equipment ChooseEquipmentSell(List<Equipment> choices)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Type in the number of the item you want to SELL:\n");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].sellPrice} doorknobs)");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
            catch (Exception ex)
            {
                return ChooseEquipmentSell(choices);
            }
        }
        public Item ChooseItemSteal(List<Item> choices)
        {
            Console.WriteLine("Type in the number of the item you want to STEAl:\n");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1}: {choices[i].name}\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
            catch (Exception ex)
            {
                return ChooseItemSteal(choices);
            }

        }
        public static Equipment ChooseEquipmentSteal(List<Equipment> choices)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Type in the number of the item you want to STEAL:\n");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1}: {choices[i].name}\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
            catch (Exception ex)
            {
                return ChooseEquipmentSteal(choices);
            }
        }
        public static Equipment ChooseEquipmentEquip(List<Equipment> choices)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Type in the number of the item you want to EQUIP:\n");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1}: {choices[i].name} (Is the item Equipped: {choices[i].isEquipped})\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
            catch (Exception ex)
            {
                return ChooseEquipmentEquip(choices);
            }
        }
        public static void Inventory(Player player)
        {
            List<Entity> playerChoice = new List<Entity>() { player };
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What do you want to do?\n");
                Console.WriteLine("ITEM || EQUIPMENT || STATS || LEAVE\n");
                string choice = Console.ReadLine();
                if (choice == "ITEM")
                {
                    if (Player.inventory.Count == 0)
                    {
                        Console.WriteLine("You have no items.\n");
                    }
                    else
                    {
                        while (true)
                        {

                            Console.WriteLine("What do you want to do, look at an item's DESCRIPTION || USE items or LEAVE.");
                            string itemChoice = Console.ReadLine();
                            if (itemChoice == "DESCRIPTION")
                            {
                                Item item = Player.player.ChooseItem(Player.inventory);
                                Console.WriteLine($"Description: {item.description}\n");
                                Console.WriteLine($"Sell Price: {item.sellPrice}\n");
                                Console.WriteLine($"Max Amount: {item.maxAmount}\n");
                                if (item is HealthPotionItem castedItem1)
                                {
                                    Console.WriteLine($"Healing Amount: {castedItem1.healAmount} \n");
                                }
                                else if (item is ManaPotionItem castedItem2)
                                {
                                    Console.WriteLine($"Healing Amount: {castedItem2.manaAmount} \n");
                                }
                            }
                            else if (itemChoice == "USE")
                            {
                                Item item = Player.player.ChooseItem(Player.inventory);
                                Entity target = Player.player.ChooseTarget(playerChoice);
                                item.Use(player, target);
                                Player.inventory.Remove(item);
                            }
                            else if (itemChoice == "LEAVE")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You typed something wrong. Try again!");
                            }
                        }
                    }
                }
                else if (choice == "EQUIPMENT")
                {
                    if (Player.equipmentInventory.Count == 0)
                    {
                        Console.WriteLine("You've have no equipments.\n");
                    }
                    else
                    {
                        while (true)
                        {
                            Console.WriteLine("What do you want to do, look at an equipment's DESCRIPTION || EQUIP equipments or LEAVE.");
                            string equipmentChoice = Console.ReadLine();
                            if (equipmentChoice == "DESCRIPTION")
                            {
                                Equipment equipment = Player.ChooseEquipmentDescribe(Player.equipmentInventory);
                                Console.WriteLine($"Description: {equipment.description}\n");
                                Console.WriteLine($"Sell Price: {equipment.sellPrice}\n");
                                if (equipment is Weapon castedWeapon)
                                {
                                    Console.WriteLine($"Damage: {castedWeapon.damage}\n");
                                    if (castedWeapon is ManaWeapon castedWeapon1)
                                    {
                                        Console.WriteLine($"Mana Cost: {castedWeapon1.manaUsed} \n");
                                    }
                                    else if (castedWeapon is RangedWeapon castedWeapon2)
                                    {
                                        Console.WriteLine($"Current Ammo:  {castedWeapon2.currentAmmo}\n");
                                    }
                                    else if (castedWeapon is SpecialWeapon castedWeapon3)
                                    {
                                        if (castedWeapon3.isMagic == true)
                                            Console.WriteLine($"Mana Cost: {castedWeapon3.manaUsed}\n");
                                        if (castedWeapon3.isRanged == true)
                                            Console.WriteLine($"Current Ammo:  {castedWeapon3.currentAmmo}\n");
                                    }
                                }
                                else if (equipment is Armor castedArmor)
                                {
                                    Console.WriteLine($"Defense Given: {castedArmor.defense}\n");
                                }

                            }
                            else if (equipmentChoice == "EQUIP")
                            {
                                Equipment equipment = ChooseEquipmentEquip(Player.equipmentInventory);
                                if (equipment.isEquipped == false)
                                {
                                    equipment.Equip(Player.player);
                                    Console.WriteLine($"You have now equipped {equipment.name}\n");
                                }
                                else if (equipment.isEquipped == true)
                                {
                                    equipment.UnEquip(Player.player);
                                    Console.WriteLine($"You have now unequipped {equipment.name}\n");
                                }
                            }
                            else if (equipmentChoice == "LEAVE")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You typed something wrong. Try again!");
                            }
                        }
                    }
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