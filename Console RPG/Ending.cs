using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    internal class Ending : LocationFeature
    {
        public Ending() : base(false)
        {
        }

        public override void Resolve(List<Player> players)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("You walk out into the beautiful open world the sun on your face, the breeze rushing across your fingers.\n");
            Thread.Sleep(2000);
            Console.WriteLine("'It's beautiful you think' you are happy to be out of the hell of splinters, door hinges, and doorknobs.\n");
            Thread.Sleep(2000);
            Console.WriteLine("You turn around and see that the door you left from is now gone.... you are actually free.\n");
            Thread.Sleep(2000);
            Console.WriteLine("With a pep in your step and a shimmer in your eye you start skipping across the grassy hills that surround you.\n");
            Thread.Sleep(2000);
            Console.WriteLine("You missed the feeling of soft and wet grass against your toes as you, laughing in joy lay down on the ground looking up at the beautiful blue sky\n");
            Thread.Sleep(2000);
            Console.WriteLine("You no longer have clunky armor weighing you down. Weapons of mass destruction you once held in your hands, are now replaced by measly sticks you fiddle with as you lay down.\n");
            Thread.Sleep(2000);
            Console.WriteLine("The blood on your hands washes away as the sky starts to sprinkle, comfortable, warm rain.\n");
            Thread.Sleep(2000);
            Console.WriteLine("You close your eyes and try to remember... try to remember what your life was before the doors.\n");
            Console.BackgroundColor= ConsoleColor.Black;
            Thread.Sleep(5000);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Nothing\n");
            Thread.Sleep(5000);
            Console.WriteLine("There is nothing.... you open your eyes and are surrounded by nothing.\n");
            Thread.Sleep(2000);
            Console.WriteLine("All the bit of joy and warmth you felt is all sucked away in the endless nothing.\n");
            Thread.Sleep(2000);
            Console.WriteLine("After sometime floating in the endless cacophony of black and silence you notice something in the distance.\n");
            Thread.Sleep(2000);
            Console.WriteLine("Knowing there is nothing else for you to do so you move towards what you saw.\n");
            Thread.Sleep(2000);
            Console.WriteLine("And to your dismay you recognize what you see.\n");
            Thread.Sleep(2000);
            Console.WriteLine("In front of you are three doors.\n");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Red;    
            Console.WriteLine("A RED DOOR.\n");
            Thread.Sleep(3000);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("A BLUE DOOR.\n");
            Thread.Sleep(5000);
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("AND A GREEN DOOR.\n");
            Thread.Sleep(2000);
            Console.WriteLine("What will you choose.\n");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("THE END\n");
            
        }
    }
}
