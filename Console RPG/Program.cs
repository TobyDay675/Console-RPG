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
            Location.theArena.SetNearbyLocations(east: Location.theArenaFloor1, north: Location.cavernOfDoors, west: Location.nopeHQ);
            Location.cavernOfDoors.SetNearbyLocations(north: Location.mimicRoom1, east: Location.spiderRoom, west: Location.spookyRoom1);
            Location.spookyRoom1.SetNearbyLocations(west: Location.spiderRoom2);
            Location.spiderRoom2.SetNearbyLocations(north: Location.mimicRoom2);
            Location.mimicRoom2.SetNearbyLocations(north: Location.demagargenRoom);
            Location.demagargenRoom.SetNearbyLocations(north: Location.mineRoom3);
            Location.mineRoom3.SetNearbyLocations(east: Location.cavernMasterRoom, west: Location.starNosedPoleTunnel1);
            Location.starNosedPoleTunnel1.SetNearbyLocations(Location.starNosedPoleTunnel2);
            Location.starNosedPoleTunnel2.SetNearbyLocations(Location.superHardDrillFight);
            Location.superHardDrillFight.SetNearbyLocations(Location.nopeStash);
            Location.mimicRoom1.SetNearbyLocations(north: Location.spookyRoom2, east: Location.mineRoom1);
            Location.spookyRoom2.SetNearbyLocations(north: Location.mimicRoom4);
            Location.mimicRoom4.SetNearbyLocations(north: Location.randomRoom1, west: Location.cavernMasterRoom);
            Location.cavernMasterRoom.SetNearbyLocations(west: Location.mineRoom3);
            Location.spiderRoom.SetNearbyLocations(north: Location.mineRoom1, east: Location.spookyRoom3);
            Location.spookyRoom3.SetNearbyLocations(north: Location.mineRoom2);
            Location.mineRoom2.SetNearbyLocations(north: Location.quarryRoom);
            Location.quarryRoom.SetNearbyLocations(north: Location.chickenFightRoom);
            Location.chickenFightRoom.SetNearbyLocations(east: Location.chickenRewardRoom, west: Location.randomRoom2);
            Location.randomRoom2.SetNearbyLocations(north: Location.randomRoom3, west: Location.randomRoom1);
            Location.randomRoom1.SetNearbyLocations(north: Location.wizardShop);
            Location.randomRoom3.SetNearbyLocations(west: Location.wizardShop);
            Location.wizardShop.SetNearbyLocations(north: Location.randomRoom5, west: Location.sockPuppetRoom);
            Location.sockPuppetRoom.SetNearbyLocations(south: Location.sockPuppetLootRoom);
            Location.randomRoom5.SetNearbyLocations(north: Location.randomRoom4);
            Location.randomRoom4.SetNearbyLocations(east: Location.theFinalDoor, west: Location.necromancyRoom);
            Location.necromancyRoom.SetNearbyLocations(north: Location.necromancyLootRoom);
            Location.theFinalDoor.SetNearbyLocations(east: Location.FinalBattleRoom);
            Location.FinalBattleRoom.SetNearbyLocations(east: Location.exit);

            Player.player.heldWeapon = null;
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
            Location.DoorRoom();

            
            
        }
    }
}
