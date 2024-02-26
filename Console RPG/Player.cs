using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Console_RPG
{
    class Player : Entity
    {
        public static Player player = new Player("Player", hp: 50, mana: 25, new Stats(strength: 15, defense: 0, hp: 50, mana: 25), level: 1, exp: 0, doorknob: 0);
        
        public int level; 
        public int currentExperience;
        public int doorKnobCount;

        public Stats levelUpIncrease = new Stats(10, 5, 10, 10);

        public Player(string name, int hp, int mana, Stats stats, int level, int exp, int doorknob) : base(name, hp, mana, stats)
        {
            this.level = level;
            this.currentExperience = exp;
            this.doorKnobCount = doorknob;
        }

        public override Entity ChooseTarget(List<Entity> choices)
        {
            Console.WriteLine("Type in the number of the entity you want to target:\n");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name}");
            }

            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }

        public override void Attack(Entity target, Entity user)
        {
            int calculatedDamage = (heldWeapon.damage + user.stats.strength) - target.stats.defense;
            if (heldWeapon is ManaWeapon)
            {
                heldWeapon.Use(user, target);
                Console.WriteLine($"{this.name} attacked {target.name} for {heldWeapon.damage} damage!\n");
                Console.WriteLine($"{target.name}'s hp is now:{target.currentHP}"); 
            }
            if (heldWeapon is RangedWeapon)
            {
                heldWeapon.Use(user, target);
                Console.WriteLine($"{this.name} attacked {target.name} for {calculatedDamage} damage!\n");
                Console.WriteLine($"{target.name}'s hp is now:{target.currentHP}");
            }
            if (heldWeapon is MeleeWeapon)
            {
                target.currentHP -= calculatedDamage;
                Console.WriteLine($"{this.name} attacked {target.name} for {calculatedDamage} damage!\n");
                Console.WriteLine($"{target.name}'s hp is now:{target.currentHP}");
            }
        }
        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
            Attack(target, this);
        }
        
        public void LevelUp()
        {
            int levelUpCeiling = 100;
            if (this.currentExperience > levelUpCeiling) 
            {
                this.level++;
                this.stats.maxHP += levelUpIncrease.maxHP;
                this.currentExperience = levelUpCeiling - this.currentExperience;
                levelUpCeiling += levelUpCeiling;
                Console.WriteLine($"You leveled up!! Your level is now {this.level}. Keep on keeping on!\n");


            }
        }

    }


}
