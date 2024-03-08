using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Console_RPG
{
    class Battle : LocationFeature
    {
        public bool battleAgain;
        public List<Enemy> enemies; 



        public Battle(List<Enemy> enemies, bool battleAgain = false) :base(false)
        {
            this.enemies = enemies;
            this.battleAgain = battleAgain;
        }

        public override void Resolve(List<Player> players)
        {
            if (isResolved == true)
            {
                return;
            }
            bool didWinBattle = false;

            while (true)
            {
                // Run this code on each of the players
                foreach (var player in players)
                {
                    if (player.currentHP > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"It's {player.name}'s turn.\n");
                        player.DoTurn(players, enemies);
                    }
                }

                // Run this code on each of the enemies
                foreach (var enemy in enemies)
                {
                    if (enemy.currentHP > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"It's {enemy.name}'s turn\n");
                        enemy.DoTurn(players, enemies);
                    }
                }

                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.WriteLine("Oh... dang you died. Well there goes my entertainment... a woe is me.\n");
                    foreach (var player in players)
                    {
                        player.doorKnobCount = player.doorKnobCount / 2;
                    }
                    Console.WriteLine($"Also you lost some doorknobs. You know have {Player.player.doorKnobCount} doorknobs. \n");
                    break;
                }

                if (enemies.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    didWinBattle = true;
                    Console.ForegroundColor= ConsoleColor.Yellow; 
                    Console.WriteLine($"You did it!! Congrats you now have blood on your hands :) \n");
                    Console.WriteLine($"Those enemies were holding Doorknobs! And you stole them from their corpses... you are horrible \n");
                    // Doorknob add 
                    foreach (var enemy in enemies)
                    {
                        Player.player.doorKnobCount += enemy.doorknobsDroppedOnDefeated; 
                    }
                    Console.WriteLine($"You now have {Player.player.doorKnobCount} doorknobs... buy yourself something nice.\n");
                    // Level Up
                    foreach (var enemy in enemies)
                    {
                        Player.player.currentExperience += enemy.experiencePointsDropped;
                        Player.player.LevelUp();
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan; 

                    
                    break;
                }
            }
            if (didWinBattle == false)
            {
                foreach (var player in players) 
                {
                    player.currentHP = player.stats.maxHP;
                    player.currentMana = player.stats.maxMana;
                }
                foreach (var enemy in enemies) 
                { 
                    enemy.currentHP = enemy.stats.maxHP;   
                    enemy.currentMana = enemy.stats.maxMana;
                }
                Location.checkpoint.Resolve(players);
            }
            if (didWinBattle == true)
            {
                foreach (var player in players)
                {
                    player.currentHP = player.stats.maxHP;
                    player.currentMana = player.stats.maxMana;
                }
                if (battleAgain == true)
                {
                    foreach (var enemy in enemies)
                    {
                        enemy.currentHP = enemy.stats.maxHP;
                        enemy.currentMana = enemy.stats.maxMana;
                    }
                    isResolved = false;
                }
                else if (battleAgain == false)
                {
                    isResolved = true;
                }
            }
        }
    }
}