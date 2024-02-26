using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Location.waterColorFields.SetNearbyLocations(north: Location.bubbleLand);
            Location.bubbleLand.SetNearbyLocations(north: Location.theArena);
            Location.theArena.SetNearbyLocations(north: Location.theArenaFloor1, east: Location.cavernOfDoors, west: Location.nopeHQ);
            Location.exitPortal.north = Location.bubbleLand;

            Location.theArenaFloor1.north = Location.theArenaFloor2;
            Location.theArenaFloor1.south = Location.exitPortal;
            
            Location.theArenaFloor2.north = Location.theArenaFloor3;
            Location.theArenaFloor2.south = Location.exitPortal;
            
            Location.theArenaFloor3.north = Location.theArenaFloor4;
            Location.theArenaFloor3.south = Location.exitPortal;
            
            Location.theArenaFloor4.north = Location.theArenaFloor5;
            Location.theArenaFloor4.south = Location.exitPortal;
            
            Location.theArenaFloor5.north = Location.theArenaFloor6;
            Location.theArenaFloor5.south = Location.exitPortal;
            
            Location.theArenaFloor6.north = Location.theArenaFloor7;
            Location.theArenaFloor6.south = Location.exitPortal;
            
            Location.theArenaFloor7.north = Location.theArenaFloor8;
            Location.theArenaFloor7.south = Location.exitPortal;
            
            Location.theArenaFloor8.north = Location.theArenaFloor9;
            Location.theArenaFloor8.south = Location.exitPortal;
            
            Location.theArenaFloor9.north = Location.theArenaFloor10;
            Location.theArenaFloor9.south = Location.exitPortal;
            
            Location.theArenaFloor10.south = Location.exitPortal;
            // Location.DoorRoom();

            Player.player.heldWeapon = MeleeWeapon.placeHolderSword;
            Enemy.bubbleArcher.heldWeapon = MeleeWeapon.placeHolderSword;
            Location.theArena.Resolve(new List<Player>() { Player.player });
        }
    }
}
