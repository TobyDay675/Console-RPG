using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Location
    {
        //Misc Areas
        public static Location doorRoom = new Location("Door Room", "Will you make the right choice. \n");
        public static Location bubbleLand = new Location("Bubble Land", "Porcupines not welcome. \n", new Shop("Soapy Saloon", new List<Item>() { HealthPotionItem.smallHealthPotion, HealthPotionItem.regularHealthPotion, HealthPotionItem.largeHealthPotion}, new List<Equipment>() { MeleeWeapon.dagger, MeleeWeapon.theSword, MeleeWeapon.bubblePopper }));
        public static Location waterColorFields = new Location("Watercolor Field", "Melt in the art. \n");
        public static Location exitPortal = new Location("Exit Portal", "Get outtaaa here. \n");
        //Cavern of Doors
        public static Location cavernOfDoors = new Location("Cavern Of Doors", "I swear if I see one more door. \n");
        public static Location randomRoom1 = new Location("Yellow Door", "Sunflowerrs.\n");
        public static Location randomRoom2 = new Location("Pink Door", "Hearts and Valentines blehhhhh.\n");
        public static Location randomRoom3 = new Location("Black Door", "It's pitch black in here!!\n");
        public static Location randomRoom4 = new Location("Orange Door", "Orange you glad it wasn't the banana door.\n");
        public static Location randomRoom5 = new Location("Banana Door", "This is crazy.\n");
        public static Location spiderRoom = new Location("Web Door", "AHHH SPIDERS!!!!!\n");
        public static Location spiderRoom2 = new Location("Glass Door", "Ok though they are kind of cute.\n");
        public static Location chickenFightRoom = new Location("Chicken Door", "You defeated the great Chicken Guardian.\n");
        public static Location chickenRewardRoom = new Location("Chicken Treasure Room", "Bawk Bawk.\n");
        public static Location mimicRoom1 = new Location("Wooden Door", "I thought it was a normal chest.\n");
        public static Location mimicRoom2 = new Location("Steel Door", "The more the merrier I guess.\n");
        public static Location mimicRoom3 = new Location("Coal Door", "How does a chest mine?\n");
        public static Location mimicRoom4 = new Location("Gold Door", "SO MUCH MONEYYY!!! \n");
        public static Location spookyRoom1 = new Location("Ghost Door", "I'm shivering in my timbers.\n");
        public static Location spookyRoom2 = new Location("Astral Door", "I do believe in spooks I do I do.\n");
        public static Location spookyRoom3 = new Location("Blood Door", "How does one weld with a scythe?\n");
        public static Location mineRoom1 = new Location("Ore Door", "Mininnnng awaaaay.\n");
        public static Location mineRoom2 = new Location("Pickaxe Door", "I wonder what they are mining for.\n");
        public static Location mineRoom3 = new Location("Minecart Door", "HOW IS THAT PICKAXE ALIVE.\n");
        public static Location quarryRoom = new Location("Water Door", "You really spent all that time fighting rocks... wow\n");
        public static Location starNosedPoleTunnel1 = new Location("Barber Door", "The Star-Nosed-Pole is near.\n");
        public static Location starNosedPoleTunnel2 = new Location("Tunnel", "The elusive Star-Nosed-Pole is dead.\n");
        public static Location cavernMasterRoom = new Location("Fancy Door", "He has been here for centuries.\n");
        public static Location demagargenRoom = new Location("Strange Door", "There have been stranger things seen.\n");
        public static Location necromancyRoom = new Location("Life and Love Door", "You felled the great Necromancer!!\n");
        public static Location necromancyLootRoom = new Location("Necromancers Loot Chest", "You can now steal his shtufff.\n");
        public static Location sockPuppetRoom = new Location("Cloth Door", "That ends this puppet show.\n");
        public static Location sockPuppetLootRoom = new Location("Behind The Curtain", "Oooooooo some a free sock puppet.\n");
        public static Location wizardShop = new Location("Purple Door", "This is one magical place.\n");
        public static Location theFinalDoor = new Location("The Final Door", "One last door to open. \n", unlockedByDefault: false);
        public static Location FinalBattleRoom = new Location("Final Room", "You defeated the door master now you can leave this prison.\n");
        public static Location exit = new Location("Exit", "Finally Escape.\n");
        //ARENA
        public static Location theArena = new Location("THE BUBBLE ARENA!!!", "Fight...FiGhT...FIGHTTTTT!!!! \n", isCheckpoint: true);
        public static Location theArenaFloor1 = new Location("Floor 1", "Its a battling time. \n", new Battle(new List<Enemy>() { Enemy.bubbleFighterA, Enemy.bubbleFighterB, Enemy.bubbleArcherA}), true);
        public static Location theArenaFloor2 = new Location("Floor 2", "Boy these battles are soapy.", new Battle(new List<Enemy>() { Enemy.bubbleArcherB, Enemy.bubbleArcherC, Enemy.bubbleArcherD }), true);
        public static Location theArenaFloor3 = new Location("Floor 3", "Don't slip. \n", new Battle(new List<Enemy>() { Enemy.armoredBubbleE, Enemy.bubbleArcherF, Enemy.bubbleFighterE }), true);
        public static Location theArenaFloor4 = new Location("Floor 4", "How do bubbles wear armor anyway. \n", new Battle(new List<Enemy>() { Enemy.armoredBubbleA, Enemy.armoredBubbleB }), true);
        public static Location theArenaFloor5 = new Location("Floor 5", "These are some touch bubbles? Are they made with glycerin. \n", new Battle(new List<Enemy>() { Enemy.armoredBubbleC, Enemy.bubbleGladiatorA, Enemy.armoredBubbleD }), true);
        public static Location theArenaFloor6 = new Location("Floor 6", "This is... not Sparta. \n", new Battle(new List<Enemy>() { Enemy.bubbleGladiatorB, Enemy.bubbleGladiatorC, Enemy.bubbleGladiatorD }), true);
        public static Location theArenaFloor7 = new Location("Floor 7", "We might get copyrighted for this one. \n", new Battle(new List<Enemy>() { Enemy.theDirtyBubble}), true);
        public static Location theArenaFloor8 = new Location("Floor 8", "The Champion is near. \n", new Battle(new List<Enemy>() { Enemy.bubbleSorcerer, Enemy.summonedBubbleA, Enemy.summonedBubbleB, Enemy.summonedBubbleC, Enemy.summonedBubbleD, Enemy.summonedBubbleE }), true);
        public static Location theArenaFloor9 = new Location("Floor 9", "The Champion is waiting. \n", new Battle(new List<Enemy>() { Enemy.bubbleBehemoth, Enemy.bubbleFighterC, Enemy.bubbleFighterD}), true);
        public static Location theArenaFloor10 = new Location("Floor 10: Champion's Room", "You are now the champion. \n", new Battle(new List<Enemy>() { Enemy.arenaChampion }), true);
        
        //Locked forever for now
        public static Location nopeHQ = new Location("Nope Squad HQ", "Nope. \n", unlockedByDefault: false);
        public static Location narratorRoom = new Location("???", "How did you get here? \n", unlockedByDefault: false);

        public string name;
        public string description;
        public LocationFeature interaction;
        public bool unlockedByDefault;
        public bool isCheckpoint;

        public Location north, east, south, west;

        public static Location checkpoint;

        public Location(string name, string description, LocationFeature interaction = null, bool unlockedByDefault = true, bool isCheckpoint = false)
        {
            this.name = name;
            this.description = description;
            this.interaction = interaction;
            this.unlockedByDefault = unlockedByDefault;
            this.isCheckpoint = isCheckpoint;   
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        { 
            if (!(north is null))
            {
                this.north = north;
                north.south = this;
                
            }
                
            if (!(east is null))
            {
                this.east = east;
                east.west = this;
                
            }

            if (!(south is null))
            {
                this.south = south;
                south.north = this;
                
            }

            if (!(west is null))
            {
                this.west = west;
                west.east = this;
                
            }
        }

        public static void DoorRoom()
        {
            Console.ForegroundColor = ConsoleColor.Gray;    
            Console.WriteLine("You find your self in a dark cloudy room. \n");
            Thread.Sleep(1000);
            Console.WriteLine("In front of you is a, Red Door, Blue Door, and a Green Door. \n");
            Thread.Sleep(1000);
            Console.WriteLine("Which door will you go through? \n");
            Thread.Sleep(1000);
            Console.WriteLine("RED || BLUE || GREEN ");

            string doorChoice = Console.ReadLine();
            if (doorChoice == "RED")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You open the door and are immediately hit with immense heat, the door melting around you. \n");
                Thread.Sleep(1000);
                Console.WriteLine("You attempt to make your way around the room but collapse due to the heat. \n");
                Thread.Sleep(1000);
                Console.WriteLine("You..... Die \n");
                Thread.Sleep(1000);
                Console.WriteLine("Try again YES || NO \n");
                string choice = Console.ReadLine();
                if (choice == "YES")
                {
                    Console.WriteLine("Goodluck :) \n");
                    DoorRoom();
                }
                else if (choice == "NO")
                {
                    Console.WriteLine("Fine be like that! I didn't want to see you die again anyway!! \n");
                    System.Environment.Exit(0);
                }
                else
                    Console.WriteLine("Actually try.. to answer correctly... butterfingers over here \n");
                    DoorRoom();
            }
            else if (doorChoice == "BLUE")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("You open the door and are in a beautiful landscape of bubbles and water color. \n");
                Thread.Sleep(1000);
                waterColorFields.Resolve(new List<Player>() {Player.player});
            }
            else if (doorChoice == "GREEN")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You find yourself dangling over a pit of acid. \n");
                Thread.Sleep(1000);
                Console.WriteLine("A steriotypical mad scientist, Dr. Evilston, is cackling as you are slowly being dipped into the acid. \n");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("'MUHAHAHAHAHA MY EVIL SCHEME IS GOING PERFECTLY AS PLANNED' *insert goofy villain laugh* \n");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("'Dr. Evilston?' \n");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("''Yes my less evil, probably in love with me, henchmen Markors what is it.'' \n");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("'Who is this person you are putting in acid?' \n");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("''Oh I have no clue!! They popped out of a magic door from the sky.'' \n");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("'Ahhhh so just a normal Tuesday.' \n");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("''Yeah just a normal Tuesday... ANYWAY MUHAHAHAHA HAVE FUN MELTING'' \n");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("In all honestly despite your skin and flesh melting off it is actually a pretty fun experience. \n");
                Thread.Sleep(1000);
                Console.WriteLine("You die... entertained... but still dead. \n");
                Thread.Sleep(1000);
                Console.WriteLine("Try again YES || NO \n");
                string choice = Console.ReadLine();
                if (choice == "YES")
                {
                    Console.WriteLine("Goodluck :) \n");
                    DoorRoom();
                }
                else if (choice == "NO")
                {
                    Console.WriteLine("Fine be like that! I didn't want to see you die again anyway!! \n");
                    System.Environment.Exit(0);
                }
                else
                    Console.WriteLine("Actually try.. to answer correctly... butterfingers over here \n");
            }
            else
            {
                Console.WriteLine("Fine then don't go into any door....\n");
                Thread.Sleep(1000);
                Console.WriteLine("We'll just sit here for an enternity I guess....... \n");
                Thread.Sleep(1000);
                Console.WriteLine("Fine just try again \n");
                DoorRoom();
            }
                
        }
        public void Resolve(List<Player> players)
        {
            // Only resolve a battle if there is a battle to resolve. Null checking.
            interaction?.Resolve(players);

            if (this.unlockedByDefault == true)
            {
                Console.WriteLine("You find yourself in " + this.name + ". \n");
                Console.WriteLine(this.description);
                if (this.isCheckpoint == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;   
                    Console.WriteLine("*Checkpoint added* \n");
                    Console.ForegroundColor= ConsoleColor.Cyan;    
                    checkpoint = this; 
                }
               

                if (!(north is null))
                Console.WriteLine($"NORTH: {this.north.name}\n");

                if (!(east is null))
                Console.WriteLine($"EAST: {this.east.name}\n");

                if (!(south is null))
                Console.WriteLine($"SOUTH: {this.south.name}\n");

                if (!(west is null))
                {
                    Console.WriteLine($"WEST: {this.west.name}\n");
                }
                Console.WriteLine("If you want to access your inventory, type | INVENTORY");
                

                string choice = Console.ReadLine();
                Location nextLocation = null;

                if (choice == "NORTH")
                    nextLocation = this.north;
                else if (choice == "EAST")
                    nextLocation = this.east;
                else if (choice == "SOUTH")
                    nextLocation = this.south;
                else if (choice == "WEST")
                    nextLocation = this.west;
                else if (choice == "INVENTORY")
                {
                    Inventory(Player.player);
                    this.Resolve(players);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Oops you said something wrong... try again. \n");
                    Console.ForegroundColor= ConsoleColor.Cyan;
                    this.Resolve(players);
                }

                nextLocation.Resolve(players);
            }
            else
            {
                Console.WriteLine("Hmmm this place seems to be locked... maybe you can get a key somewhere?\n");
                Console.WriteLine("I'll bring you back to your last checkpoint. \n");
                checkpoint.Resolve(players);
            }  
        }

        public static void Inventory(Player player)
        {
            List<Entity> playerChoice = new List<Entity>() {player};
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What do you want to do?\n");
                Console.WriteLine("USE ITEM || SWITCH EQUIP || STATS || LEAVE\n");
                string choice = Console.ReadLine();
                if (choice == "USE ITEM")
                {   if (Player.inventory.Count == 0)
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
                            Console.WriteLine($"You have now unequipped {equipment.name}\n");
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
    }
}
