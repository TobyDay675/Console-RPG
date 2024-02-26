using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Console_RPG
{
    class Battle
    {
        public bool isResolved;
        public bool battleAgain;
        public List<Enemy> enemies; 



        public Battle(List<Enemy> enemies, bool battleAgain = false)
        {
            this.isResolved = false;
            this.enemies = enemies;
            this.battleAgain = battleAgain;
        }

        public void Resolve(List<Player> players)
        {
            while (true)
            {
                // Run this code on each of the players
                foreach (var player in players)
                {
                    Console.WriteLine($"It's {player.name}'s turn.\n");
                    player.DoTurn(players, enemies);
                }

                // Run this code on each of the enemies
                foreach (var enemy in enemies)
                {
                    Console.WriteLine($"It's {enemy.name}'s turn\n");
                    enemy.DoTurn(players, enemies);
                }

                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.WriteLine("Oh... dang you died. Well there goes my entertainment... a woe is me.\n");
                        break;
                }

                if (players.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    // Doorknob add 
                    foreach (var enemy in enemies)
                    {
                        Player.player.doorKnobCount += enemy.doorknobsDroppedOnDefeated;
                        Console.WriteLine($"Those enemies were holding Doorknobs! And you stole them from their corpses... you are horrible \n");
                        Console.WriteLine($"You now have {Player.player.doorKnobCount} doorknobs... buy yourself something nice.\n");
                    }
                    // Level Up
                    foreach (var enemy in enemies)
                    {
                        Player.player.currentExperience += enemy.experiencePointsDropped;
                        Player.player.LevelUp();
                    }
                    if (battleAgain == true)
                    {
                        isResolved = false;
                    }
                    else if (battleAgain == false) 
                    {
                        isResolved = true;
                    }

                    Console.WriteLine($"You did it!! Congrats you now have blood on your hands :) \n");
                    break;
                }
            }
        }
    }
}