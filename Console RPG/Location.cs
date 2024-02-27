using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Location
    {
        public static Location doorRoom = new Location("Door Room", "Will you make the right choice. \n");
        public static Location bubbleLand = new Location("Bubble Land", "Porcupines not welcome. \n");
        public static Location waterColorFields = new Location("Watercolor Field", "Melt in the art. \n");
        public static Location cavernOfDoors = new Location("Cavern Of Doors", "I swear if I see one more door. \n");
        public static Location doorCultLair = new Location("Lair of the Door Cult", "ALL HAIL THE HINDGES FROM ABOVE. \n", unlockedByDefault: false);
        public static Location nopeHQ = new Location("Nope Squad HQ", "Nope. \n", unlockedByDefault: false);
        public static Location exitPortal = new Location("Exit Portal", "Get outtaaa here. \n");
        public static Location theArena = new Location("THE BUBBLE ARENA!!!", "Fight...FiGhT...FIGHTTTTT!!!! \n", isCheckpoint: true);
        public static Location theArenaFloor1 = new Location("Floor 1", "Its a battling time. \n", new Battle(new List<Enemy>() { Enemy.bubbleFighterA, Enemy.bubbleFighterB, Enemy.bubbleArcherA}), true);
        public static Location theArenaFloor2 = new Location("Floor 2", "Boy these battles are soapy.", new Battle(new List<Enemy>() { Enemy.bubbleArcherB, Enemy.bubbleArcherC, Enemy.bubbleArcherD }), true);
        public static Location theArenaFloor3 = new Location("Floor 3", "Don't slip. \n", new Battle(new List<Enemy>() { Enemy.armoredBubbleE, Enemy.bubbleArcherF, Enemy.bubbleFighterE }), true);
        public static Location theArenaFloor4 = new Location("Floor 4", "How do bubbles wear armor anyway. \n", new Battle(new List<Enemy>() { Enemy.armoredBubbleA, Enemy.armoredBubbleB }), true);
        public static Location theArenaFloor5 = new Location("Floor 5", "These are some touch bubbles? Are they made with glycerin. \n", new Battle(new List<Enemy>() { Enemy.armoredBubbleC, Enemy.bubbleGladiatorA, Enemy.armoredBubbleD }), true);
        public static Location theArenaFloor6 = new Location("Floor 6", "This is... not sparta. \n", new Battle(new List<Enemy>() { Enemy.bubbleGladiatorB, Enemy.bubbleGladiatorC, Enemy.bubbleGladiatorD }), true);
        public static Location theArenaFloor7 = new Location("Floor 7", "We might get copyrighted for this one. \n", new Battle(new List<Enemy>() { Enemy.theDirtyBubble}), true);
        public static Location theArenaFloor8 = new Location("Floor 8", "The Champion is near. \n", new Battle(new List<Enemy>() { Enemy.bubbleSorcerer, Enemy.summonedBubbleA, Enemy.summonedBubbleB, Enemy.summonedBubbleC, Enemy.summonedBubbleD, Enemy.summonedBubbleE }), true);
        public static Location theArenaFloor9 = new Location("Floor 9", "The Champion is waiting. \n", new Battle(new List<Enemy>() { Enemy.bubbleBehemoth, Enemy.bubbleFighterC, Enemy.bubbleFighterD}), true);
        public static Location theArenaFloor10 = new Location("Floor 10: Champion's Room", "You are now the champion. \n", new Battle(new List<Enemy>() { Enemy.arenaChampion }), true);
        public static Location theFinalDoor = new Location("The Final Door", "One last door to open. \n", unlockedByDefault: false);
        public static Location narratorRoom = new Location("???", "How did you get here? \n", unlockedByDefault: false);

        public string name;
        public string description;
        public Battle battle;
        public bool unlockedByDefault;
        public bool isCheckpoint;

        public Location north, east, south, west;

        public static Location checkpoint;

        public Location(string name, string description, Battle battle = null, bool unlockedByDefault = true, bool isCheckpoint = false)
        {
            this.name = name;
            this.description = description;
            this.battle = battle;
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
                Console.WriteLine("Fine then don't go into any door....");
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
            battle?.Resolve(players);

            if (this.unlockedByDefault == true)
            {
                Console.WriteLine("You find yourself in " + this.name + ". \n");
                Console.WriteLine(this.description);
                if (this.isCheckpoint == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;   
                    Console.WriteLine("*Checkpoint added* \n");
                    checkpoint = this; 
                }
               

                if (!(north is null))
                Console.WriteLine("NORTH: " + this.north.name);

                if (!(east is null))
                Console.WriteLine("EAST: " + this.east.name);

                if (!(south is null))
                Console.WriteLine("SOUTH: " + this.south.name);

                if (!(west is null))
                Console.WriteLine("WEST: " + this.west.name);

                string direction = Console.ReadLine();
                Location nextLocation = null;

                if (direction == "NORTH")
                    nextLocation = this.north;
                else if (direction == "EAST")
                    nextLocation = this.east;
                else if (direction == "SOUTH")
                    nextLocation = this.south;
                else if (direction == "WEST")
                    nextLocation = this.west;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Oops you said something wrong... try again. \n");
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
    }
}
