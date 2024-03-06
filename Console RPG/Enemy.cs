using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_RPG
{
    class Enemy : Entity
    {
        //Unused
        public static BossEnemy narrator = new BossEnemy("Narrator", hp: 99999999, mana: 99999999, new Stats(strength: 9999999, defense: 99999999, hp: 99999999, mana: 99999999), doorknobDropCount: 1, expDropCount: 42, maxMana: 99999999, attackCost: 1);
        public static BossEnemy doorkeeper = new BossEnemy("The DoorKeeper", hp: 100000, mana: 100000, new Stats(strength: 200, defense: 200, hp: 100000, mana: 100000), doorknobDropCount: 100000000, expDropCount: 50000000, maxMana: 100000, attackCost: 10000);

        // bosses
        public static BossEnemy mysteryNecromancer = new BossEnemy("Mysterious Necromancer", hp: 10000, mana: 1000, new Stats(strength: 5, defense: 5, hp: 10000, mana: 1000000), doorknobDropCount: 5500, expDropCount: 10000, maxMana: 1000, attackCost: 250);
        public static BossEnemy nopeDrill = new BossEnemy("Nope Drill", hp: 55000, mana: 1000, new Stats(strength: 100, defense: 100, hp: 55000, mana: 1000), doorknobDropCount: 55000, expDropCount: 100000, maxMana: 1000, attackCost: 500);
        public static BossEnemy theSockPuppeter = new BossEnemy("The Sock Puppeter", hp: 10000, mana: 500, new Stats(strength: 60, defense: 10, hp: 1000, mana: 500), doorknobDropCount: 11000, expDropCount: 5000, maxMana: 500, attackCost: 100);

        // Cavern Of Doors Enemies
        public static NormalEnemy lostBoy = new NormalEnemy("Lost Boy?", hp: 5, mana: 0, new Stats(strength: 5, defense: 0, hp: 5, mana: 0), doorknobDropCount: 10, expDropCount: 5);
        public static NormalEnemy itsyBitsySpider = new NormalEnemy("Itsy-Bitsy-Spider", hp: 5, mana: 0, new Stats(strength: 99999999, defense: 0, hp: 0, mana: 0), doorknobDropCount: 5, expDropCount: 5);
        static NormalEnemy skelebaton = new NormalEnemy("Skelebaton", hp: 75, mana: 0, new Stats(strength: 15, defense: 5, hp: 75, mana: 0), doorknobDropCount: 100, expDropCount: 175);
        static NormalEnemy doorScout = new NormalEnemy("Door Scout", hp: 100, mana: 0, new Stats(strength: 10, defense: 8, hp: 100, mana: 0), doorknobDropCount: 100, expDropCount: 150);
        public static NormalEnemy mimic = new NormalEnemy("Mimic", hp: 150, mana: 0, new Stats(strength: 5, defense: 5, hp: 150, mana: 0), doorknobDropCount: 250, expDropCount: 50);
        public static NormalEnemy mimicMiner = new NormalEnemy("Mimic Miner", hp: 250, mana: 0, new Stats(strength: 10, defense: 5, hp: 250, mana: 0), doorknobDropCount: 450, expDropCount: 150);
        public static NormalEnemy miner = new NormalEnemy("Miner", hp: 500, mana: 0, new Stats(strength: 18, defense: 10, hp: 500, mana: 0), doorknobDropCount: 250, expDropCount: 400);
        public static NormalEnemy nopeMiner = new NormalEnemy("Nope Miner", hp: 550, mana: 0, new Stats(strength: 20, defense: 10, hp: 550, mana: 0), doorknobDropCount: 275, expDropCount: 475);
        static NormalEnemy scytheWelder = new NormalEnemy("Sycthe Welder", hp: 750, mana: 0, new Stats(strength: 25, defense: 10, hp: 750, mana: 0), doorknobDropCount: 500, expDropCount: 750);
        public static NormalEnemy bigSpidur = new NormalEnemy("Big Spidur", hp: 900, mana: 0, new Stats(strength: 15, defense: 3, hp: 150, mana: 0), doorknobDropCount: 450, expDropCount: 100);
        public static NormalEnemy chickenGaurdian = new NormalEnemy("Chicken Guardian", hp: 1000, mana: 0, new Stats(strength: 25, defense: 10, hp: 1000, mana: 0), doorknobDropCount: 1000, expDropCount: 2000);
        public static MagicEnemy bubbleGhost = new MagicEnemy("Bubble Ghost", hp: 150, mana: 50, new Stats(strength: 5, defense: 10, hp: 150, mana: 50), doorknobDropCount: 250, expDropCount: 200, maxMana: 50, attackCost: 50);
        static MagicEnemy cavernMaster = new MagicEnemy("Cavern Master", hp: 1500, mana: 150, new Stats(strength: 5, defense: 20, hp: 1500, mana: 150), doorknobDropCount: 1000, expDropCount: 2000, maxMana: 150, attackCost: 25);
        public static NormalEnemy demagargen = new NormalEnemy("Demagargen", hp: 2000, mana: 0, new Stats(strength: 30, defense: 25, hp: 2000, mana: 0), doorknobDropCount: 1500, expDropCount: 2500);
        public static NormalEnemy rocks  = new NormalEnemy("Rocks", hp: 4000, mana: 0, new Stats(strength: 10, defense: 50, hp: 4000, mana: 0), doorknobDropCount: 10000, expDropCount: 200);
        public static NormalEnemy starNosedPole = new NormalEnemy("Star Nosed Pole", hp: 5000, mana: 0, new Stats(strength: 35, defense: 30, hp: 5000, mana: 0), doorknobDropCount: 5000, expDropCount: 2000);
        public static NormalEnemy sentientPick = new NormalEnemy("Sentient Pick", hp: 8000, mana: 0, new Stats(strength: 50, defense: 20, hp: 8000, mana: 0), doorknobDropCount: 6000, expDropCount: 3000);
        //Bubble Arena Enemies
        public static BossEnemy arenaChampion = new BossEnemy("The Champion", hp: 10000, mana: 1000, new Stats(strength: 45, defense: 15, hp: 10000, mana: 1000), doorknobDropCount: 10000, expDropCount: 2500, maxMana: 1000, attackCost: 500);
        public static NormalEnemy bubbleBehemoth = new NormalEnemy("Bubble Behemoth", hp: 5000, mana: 10, new Stats(strength: 20, defense: 5, hp: 5000, mana: 10), doorknobDropCount: 250, expDropCount: 500);
        public static MagicEnemy bubbleSorcerer = new MagicEnemy("Bubble Sorcerer", hp: 250, mana: 100, new Stats(strength: 2, defense: 2, hp: 600, mana: 100), doorknobDropCount: 100, expDropCount: 250, maxMana: 100, attackCost: 25);
        public static NormalEnemy summonedBubbleA = new NormalEnemy("Summoned Bubble", hp: 10, mana: 0, new Stats(strength: 5, defense: 0, hp: 10, mana: 100), doorknobDropCount: 10, expDropCount: 25);
        public static NormalEnemy summonedBubbleB = new NormalEnemy("Summoned Bubble", hp: 10, mana: 0, new Stats(strength: 5, defense: 0, hp: 10, mana: 100), doorknobDropCount: 10, expDropCount: 25);
        public static NormalEnemy summonedBubbleC = new NormalEnemy("Summoned Bubble", hp: 10, mana: 0, new Stats(strength: 5, defense: 0, hp: 10, mana: 100), doorknobDropCount: 10, expDropCount: 25);
        public static NormalEnemy summonedBubbleD = new NormalEnemy("Summoned Bubble", hp: 10, mana: 0, new Stats(strength: 5, defense: 0, hp: 10, mana: 100), doorknobDropCount: 10, expDropCount: 25);
        public static NormalEnemy summonedBubbleE = new NormalEnemy("Summoned Bubble", hp: 10, mana: 0, new Stats(strength: 5, defense: 0, hp: 10, mana: 100), doorknobDropCount: 10, expDropCount: 25);
        public static NormalEnemy theDirtyBubble = new NormalEnemy("The Dirty Bubble", hp: 500, mana: 10, new Stats(strength: 8, defense: 0, hp: 500, mana: 10), doorknobDropCount: 50, expDropCount: 200);
        public static NormalEnemy bubbleGladiatorA = new NormalEnemy("Bubble Gladiator", hp: 150, mana: 10, new Stats(strength: 6, defense: 0, hp: 150, mana: 10), doorknobDropCount: 50, expDropCount: 150);
        public static NormalEnemy bubbleGladiatorB = new NormalEnemy("Bubble Gladiator", hp: 150, mana: 10, new Stats(strength: 6, defense: 0, hp: 150, mana: 10), doorknobDropCount: 50, expDropCount: 150);
        public static NormalEnemy bubbleGladiatorC = new NormalEnemy("Bubble Gladiator", hp: 150, mana: 10, new Stats(strength: 6, defense: 0, hp: 150, mana: 10), doorknobDropCount: 50, expDropCount: 150);
        public static NormalEnemy bubbleGladiatorD = new NormalEnemy("Bubble Gladiator", hp: 150, mana: 10, new Stats(strength: 6, defense: 0, hp: 150, mana: 10), doorknobDropCount: 50, expDropCount: 150);
        public static NormalEnemy armoredBubbleA = new NormalEnemy("Armored Bubble", hp: 150, mana: 10, new Stats(strength: 4, defense: 5, hp: 150, mana: 10), doorknobDropCount: 25, expDropCount: 100);
        public static NormalEnemy armoredBubbleB = new NormalEnemy("Armored Bubble", hp: 150, mana: 10, new Stats(strength: 4, defense: 5, hp: 150, mana: 10), doorknobDropCount: 25, expDropCount: 100);
        public static NormalEnemy armoredBubbleC = new NormalEnemy("Armored Bubble", hp: 150, mana: 10, new Stats(strength: 4, defense: 5, hp: 150, mana: 10), doorknobDropCount: 25, expDropCount: 100);
        public static NormalEnemy armoredBubbleD = new NormalEnemy("Armored Bubble", hp: 150, mana: 10, new Stats(strength: 4, defense: 5, hp: 150, mana: 10), doorknobDropCount: 25, expDropCount: 100);
        public static NormalEnemy armoredBubbleE = new NormalEnemy("Armored Bubble", hp: 150, mana: 10, new Stats(strength: 4, defense: 5, hp: 150, mana: 10), doorknobDropCount: 25, expDropCount: 100);
        public static NormalEnemy bubbleArcherA = new NormalEnemy("Bubble Archer", hp: 45, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 50);
        public static NormalEnemy bubbleArcherB = new NormalEnemy("Bubble Archer", hp: 45, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 50);
        public static NormalEnemy bubbleArcherC = new NormalEnemy("Bubble Archer", hp: 45, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 50);
        public static NormalEnemy bubbleArcherD = new NormalEnemy("Bubble Archer", hp: 45, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 50);
        public static NormalEnemy bubbleArcherE = new NormalEnemy("Bubble Archer", hp: 45, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 50);
        public static NormalEnemy bubbleArcherF = new NormalEnemy("Bubble Archer", hp: 45, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 50);
        public static NormalEnemy bubbleArcherG = new NormalEnemy("Bubble Archer", hp: 45, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 50);
        public static NormalEnemy bubbleFighterA = new NormalEnemy("Bubble Fighter", hp: 50, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 50);
        public static NormalEnemy bubbleFighterB = new NormalEnemy("Bubble Fighter", hp: 50, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 50);
        public static NormalEnemy bubbleFighterC = new NormalEnemy("Bubble Fighter", hp: 50, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 50);
        public static NormalEnemy bubbleFighterD = new NormalEnemy("Bubble Fighter", hp: 50, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 50);
        public static NormalEnemy bubbleFighterE = new NormalEnemy("Bubble Fighter", hp: 50, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 50);

        public int doorknobsDroppedOnDefeated;
        public int experiencePointsDropped;

        public Enemy(string name, int hp, int mana, Stats stats, int doorknobDropCount, int expDropCount) : base(name, hp, mana, stats)
        {
            this.doorknobsDroppedOnDefeated = doorknobDropCount;
            this.experiencePointsDropped = expDropCount;
        }
        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }

        public override void Attack(Entity target, Entity user)
        {
        
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target, this);
        }
    }
    class NormalEnemy : Enemy
    {
        public NormalEnemy(string name, int hp, int mana, Stats stats, int doorknobDropCount, int expDropCount) : base(name, hp, mana, stats, doorknobDropCount, expDropCount)
        {
        }
        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }

        public override void Attack(Entity target, Entity user)
        {
            if (this.currentHP > 0)
            {
                int calculatedDamage = this.stats.strength - target.stats.defense;
                target.currentHP -= calculatedDamage;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Your hp is now: {target.currentHP}\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            if (this.currentHP < 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("This enemy is dead you should attack the other ones now!\n");
            }
            
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target, this);
        }
    }
    class MagicEnemy : Enemy
    {
        public int maxMana;
        public int attackCost;
        public MagicEnemy(string name, int hp, int mana, Stats stats, int doorknobDropCount, int expDropCount, int maxMana, int attackCost) : base(name, hp, mana, stats, doorknobDropCount, expDropCount)
        {
            this.maxMana = maxMana;
            this.attackCost = attackCost;
        }
        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }

        public override void Attack(Entity target, Entity user)
        {
            if (this.currentHP > 0)
            { 
                if (this.currentMana > 0)
                {
                    this.currentMana -= attackCost;
                    int calculatedDamage = maxMana / 4;
                    target.currentHP -= calculatedDamage;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Your hp is now: {target.currentHP}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                if (this.currentMana == 0)
                {
                    int calculatedDamage = this.stats.strength * 10;
                    this.currentHP -= calculatedDamage;
                    Console.WriteLine($"The enemy is out of mana... it hit itself for {calculatedDamage} damage.... idiot \n");
                    this.currentMana += this.maxMana / 2;
                }
            }
            if (this.currentHP < 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("DEAD \n");
            }

        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target, this);
        }
    }
    class BossEnemy : Enemy
    {
        public int maxMana;
        public int attackCost;
        public BossEnemy(string name, int hp, int mana, Stats stats, int doorknobDropCount, int expDropCount, int maxMana, int attackCost) : base(name, hp, mana, stats, doorknobDropCount, expDropCount)
        {
            this.maxMana = maxMana;
            this.attackCost = attackCost;
        }
        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }

        public override void Attack(Entity target, Entity user)
        {
            Random random = new Random();
            int attackType = random.Next(1, 7);
            if (this.currentHP > 0)
            {
                if (attackType < 4 || this.currentMana == 0)
                {
                    Console.WriteLine($"ITS A MELEE ATTACK!!!!\n");
                    int calculatedMeleeDamage = this.stats.strength - target.stats.defense;
                    target.currentHP -= calculatedMeleeDamage;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Your hp is now: {target.currentHP}\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (this.currentMana == 0)
                    {
                        this.currentMana += this.maxMana / 2;
                    }
                }
                else if (attackType > 3)
                {
                    Console.WriteLine($"ITS A MAGIC ATTACK!!!!\n");
                    this.currentMana -= attackCost;
                    int calculatedMagicDamage = maxMana / 4;
                    target.currentHP -= calculatedMagicDamage;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Your hp is now: {target.currentHP} \n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            if (this.currentHP < 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("This enemy is dead you should attack the other ones now!\n");
            }
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target, this);
        }
    }
}
