using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Location
    {
        public static Location doorRoom = new Location("Door Room", "Will you make the right choice.");
        public static Location bubbleLand = new Location("Bubble Land", "Porcupines not welcome.");
        public static Location waterColorFields = new Location("Watercolor Field", "Melt in the art. \n");
        public static Location cavernOfDoors = new Location("Cavern Of Doors", "I swear if I see one more door.");
        public static Location doorCultLair = new Location("Lair of the Door Cult", "ALL HAIL THE HINDGES FROM ABOVE", unlockedByDefault: false);
        public static Location nopeHQ = new Location("Nope Squad HQ", "Nope", unlockedByDefault: false);
        public static Location exitPortal = new Location("Exit Portal", "Get outtaaa here");
        public static Location theArena = new Location("THE BUBBLE ARENA!!!", "Fight...FiGhT...FIGHTTTTT!!!!");
        public static Location theArenaFloor1 = new Location("Floor 1", "Its a battling time.", new Battle(new List<Enemy>() { Enemy.bubbleFighter, Enemy.bubbleFighter, Enemy.bubbleArcher}), true);
        public static Location theArenaFloor2 = new Location("Floor 2", "Boy these battles are soapy.", new Battle(new List<Enemy>() { Enemy.bubbleArcher, Enemy.bubbleArcher, Enemy.bubbleArcher }), true);
        public static Location theArenaFloor3 = new Location("Floor 3", "Don't slip.", new Battle(new List<Enemy>() { Enemy.bubbleArcher, Enemy.bubbleArcher, Enemy.bubbleArcher }), true);
        public static Location theArenaFloor4 = new Location("Floor 4", "How do bubbles wear armor anyway.", new Battle(new List<Enemy>() { Enemy.armoredBubble, Enemy.armoredBubble }), true);
        public static Location theArenaFloor5 = new Location("Floor 5", "These are some touch bubbles? Are they made with glycerin.", new Battle(new List<Enemy>() { Enemy.armoredBubble, Enemy.bubbleGladiator, Enemy.armoredBubble }), true);
        public static Location theArenaFloor6 = new Location("Floor 6", "This is... not sparta.", new Battle(new List<Enemy>() { Enemy.bubbleGladiator, Enemy.bubbleGladiator, Enemy.bubbleGladiator }), true);
        public static Location theArenaFloor7 = new Location("Floor 7", "We might get copyrighted for this one.", new Battle(new List<Enemy>() { Enemy.theDirtyBubble}), true);
        public static Location theArenaFloor8 = new Location("Floor 8", "The Champion is near.", new Battle(new List<Enemy>() { Enemy.bubbleSorcerer, Enemy.summonedBubble, Enemy.summonedBubble, Enemy.summonedBubble, Enemy.summonedBubble, Enemy.summonedBubble }), true);
        public static Location theArenaFloor9 = new Location("Floor 9", "The Champion is waiting.", new Battle(new List<Enemy>() { Enemy.bubbleBehemoth, Enemy.bubbleFighter, Enemy.bubbleFighter}), true);
        public static Location theArenaFloor10 = new Location("Floor 10: Champion's Room", "You are now the champion", new Battle(new List<Enemy>() { Enemy.arenaChampion }), true);
        public static Location theFinalDoor = new Location("The Final Door", "One last door to open.", unlockedByDefault: false);
        public static Location narratorRoom = new Location("???", "How did you get here?", unlockedByDefault: false);

        public string name;
        public string description;
        public Battle battle;
        public bool unlockedByDefault;

        public Location north, east, south, west;

        public Location(string name, string description, Battle battle = null, bool unlockedByDefault = true)
        {
            this.name = name;
            this.description = description;
            this.battle = battle;
            this.unlockedByDefault = unlockedByDefault;
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
                Console.WriteLine("You open the door and are immediately hit with immense heat, the door melting around you. \n");
                Thread.Sleep(1000);
                Console.WriteLine("You attempt to make your way around the room but collapse due to the heat. \n");
                Thread.Sleep(1000);
                Console.WriteLine("You..... Die \n");
                Thread.Sleep(1000);
                Console.WriteLine("Try again Yes || No \n");
                string choice = Console.ReadLine();
                if (choice == "Yes")
                {
                    Console.WriteLine("Goodluck :) \n");
                    DoorRoom();
                }
                else if (choice == "No")
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
                Console.WriteLine("You open the door and are in a beautiful landscape of bubbles and water color. \n");
                Thread.Sleep(1000);
                waterColorFields.Resolve(new List<Player>() {Player.player});
            }
            else if (doorChoice == "GREEN")
            {
                Console.WriteLine("You find yourself dangling over a pit of acid. \n");
                Thread.Sleep(1000);
                Console.WriteLine("A steriotypical mad scientist, Dr. Evilston, is cackling as you are slowly being dipped into the acid. \n");
                Thread.Sleep(1000);
                Console.WriteLine("'MUHAHAHAHAHA MY EVIL SCHEME IS GOING PERFECTLY AS PLANNED' *insert goofy villain laugh* \n");
                Thread.Sleep(1000);
                Console.WriteLine("'Dr. Evilston?' \n");
                Thread.Sleep(1000);
                Console.WriteLine("''Yes my less evil, probably in love with me, henchmen Markors what is it.'' \n");
                Thread.Sleep(1000);
                Console.WriteLine("'Who is this person you are putting in acid?' \n");
                Thread.Sleep(1000);
                Console.WriteLine("''Oh just some rando who popped out of a magic door from the sky.'' \n");
                Thread.Sleep(1000);
                Console.WriteLine("'Ahhhh so just a normal Tuesday.' \n");
                Thread.Sleep(1000);
                Console.WriteLine("''Yeah just a normal Tuesday... ANYWAY MUHAHAHAHA HAVE FUN MELTING'' \n");
                Thread.Sleep(1000);
                Console.WriteLine("In all honestly despite your skin and flesh melting off it is actually a pretty fun experience. \n");
                Thread.Sleep(1000);
                Console.WriteLine("You die... entertained... but still dead. \n");
                Thread.Sleep(1000);
                Console.WriteLine("Try again Yes || No \n");
                string choice = Console.ReadLine();
                if (choice == "Yes")
                {
                    Console.WriteLine("Goodluck :) \n");
                    DoorRoom();
                }
                else if (choice == "No")
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
                Console.WriteLine("Oops you said something wrong... try again. \n");
                this.Resolve(players);
                }
                nextLocation.Resolve(players);
            }
            else
            {
                Console.WriteLine("Hmmm this place seems to be locked... maybe you can get a key somewhere?\n");
                this.Resolve(players);
            }
           
            

            
        }
    }
}
