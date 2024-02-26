using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_RPG
{
    class Enemy : Entity
    {
        public static BossEnemy narrator = new BossEnemy("Narrator", hp: 99999999, mana: 99999999, new Stats(strength: 9999999, defense: 99999999, hp: 99999999, mana: 99999999), doorknobDropCount: 1, expDropCount: 42, maxMana: 99999999, attackCost: 1);
        public static BossEnemy doorkeeper = new BossEnemy("The DoorKeeper", hp: 50000, mana: 10000, new Stats(strength: 50, defense: 50, hp: 50000, mana: 10000), doorknobDropCount: 10000, expDropCount: 5000, maxMana: 10000, attackCost: 100);

        // bosses
        public static BossEnemy mysteryNecromancer = new BossEnemy("Mysterious Necromancer", hp: 10000, mana: 1000, new Stats(strength: 5, defense: 5, hp: 10000, mana: 1000000), doorknobDropCount: 550, expDropCount: 10000, maxMana: 1000, attackCost: 250);

        // Cavern Of Doors Enemies
        public static NormalEnemy mimic = new NormalEnemy("Mimic", hp: 150, mana: 0, new Stats(strength: 5, defense: 5, hp: 150, mana: 0), doorknobDropCount: 250, expDropCount: 50);
        public static NormalEnemy itsyBitsySpider = new NormalEnemy("Itsy-Bitsy-Spider", hp: 5, mana: 0, new Stats(strength: 99999999, defense: 0, hp: 0, mana: 0), doorknobDropCount: 5, expDropCount: 5);
        public static NormalEnemy bigSpidur = new NormalEnemy("Big Spidur", hp: 900, mana: 0, new Stats(strength: 10, defense: 3, hp: 150, mana: 0), doorknobDropCount: 450, expDropCount: 100);
        //Bubble Arena Enemies
        public static BossEnemy arenaChampion = new BossEnemy("The Champion", hp: 10000, mana: 1000, new Stats(strength: 25, defense: 15, hp: 5000, mana: 1000), doorknobDropCount: 10000, expDropCount: 2500, maxMana: 1000, attackCost: 500);
        public static NormalEnemy bubbleBehemoth = new NormalEnemy("Bubble Behemoth", hp: 5000, mana: 10, new Stats(strength: 10, defense: 5, hp: 5000, mana: 10), doorknobDropCount: 250, expDropCount: 500);
        public static MagicEnemy bubbleSorcerer = new MagicEnemy("Bubble Sorcerer", hp: 250, mana: 100, new Stats(strength: 2, defense: 2, hp: 600, mana: 100), doorknobDropCount: 100, expDropCount: 250, maxMana: 100, attackCost: 25);
        public static NormalEnemy summonedBubble = new NormalEnemy("Summoned Bubble", hp: 10, mana: 0, new Stats(strength: 5, defense: 0, hp: 10, mana: 100), doorknobDropCount: 10, expDropCount: 10);
        public static NormalEnemy theDirtyBubble = new NormalEnemy("The Dirty Bubble", hp: 500, mana: 10, new Stats(strength: 8, defense: 0, hp: 500, mana: 10), doorknobDropCount: 50, expDropCount: 45);
        public static NormalEnemy bubbleGladiator = new NormalEnemy("Bubble Gladiator", hp: 150, mana: 10, new Stats(strength: 6, defense: 0, hp: 150, mana: 10), doorknobDropCount: 50, expDropCount: 100);
        public static NormalEnemy armoredBubble = new NormalEnemy("Armored Bubble", hp: 150, mana: 10, new Stats(strength: 4, defense: 5, hp: 150, mana: 10), doorknobDropCount: 25, expDropCount: 50);
        public static NormalEnemy bubbleFighter = new NormalEnemy("Bubble Fighter", hp: 50, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 25);
        public static NormalEnemy bubbleArcher = new NormalEnemy("Bubble Archer", hp: 45, mana: 10, new Stats(strength: 5, defense: 0, hp: 50, mana: 10), doorknobDropCount: 10, expDropCount: 25);

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
                Console.WriteLine($"{target.name}'s hp is now:{target.currentHP}\n");
            }
            if (this.currentHP < 0)
            {
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
                    Console.WriteLine($"{target.name}'s hp is now:{target.currentHP}");
                }
                if (this.currentMana == 0)
                {
                    int calculatedDamage = this.stats.strength * 10;
                    this.currentHP -= calculatedDamage;
                    Console.WriteLine($"The enemy is out of mana... it hit itself for {calculatedDamage} damage.... idiot");
                    this.currentMana += this.maxMana / 2;
                }
            }
            if (this.currentHP < 0)
            {
                Console.WriteLine("This enemy is dead you should attack the other ones now!\n");
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
                    Console.WriteLine($"{target.name}'s hp is now:{target.currentHP}");
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
                    Console.WriteLine($"{target.name}'s hp is now:{target.currentHP}");
                }
            }
                if (this.currentHP < 0)
                {
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
