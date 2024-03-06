using System;
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
                        Item item = ChooseItem(this.items);
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
                        Equipment equipment = ChooseEquipment(this.equipments);
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
                        Item item = ChooseItem(Player.inventory);
                        Player.player.doorKnobCount += item.sellPrice;
                        Player.inventory.Remove(item);
                        Console.WriteLine($"You just sold a {item.name}! I hope you don't regret that.\n");
                    }
                    if (sellChoice == "EQUIPMENTS")
                    {
                        Item equipment = ChooseEquipment(Player.equipmentInventory);
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
                                Item item = ChooseItem(this.items);
                                Player.inventory.Add(item);
                                this.items.Remove(item);
                                Console.WriteLine($"You just stole a {item.name}! You are a horrible person.\n");
                            }
                            if (stealOption == "EQUIPMENT")
                            {
                                Equipment equipment = ChooseEquipment(this.equipments);
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
                        Console.WriteLine("You stole everything from the shop with out the shopkeeper realising.\n");
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
                    Console.WriteLine($"Go buy something\n");
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
        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Type in the number of the item you want to buy/sell/steal:\n");
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
                return ChooseItem(choices);
            }

        }
        public static Equipment ChooseEquipment(List<Equipment> choices)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Type in the number of the item you want to buy/sell/steal:\n");
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
                return ChooseEquipment(choices);
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

