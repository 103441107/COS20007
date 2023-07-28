using System;

namespace Swin_Adventure //nguyen gia huy
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Swin Adventure\n");
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("Describe yourself: ");
            string description = Console.ReadLine();

            Player me = new Player(name, description);
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            Location lake = new Location(new string[] { "location", "lake" }, "Lake", "Frozen blue lake spans across the Sivon Lands");
            Item shovel = new Item(new string[] { "shovel" }, "bronze shovel", "a tool consisting of a wide");
            
            me.Inventory.Put(shovel);
            me.Location = lake;
            lake.Inventory.Put(sword);
           
           

            Bag bag = new Bag(new string[] { "bag", "BAGGGG" }, "Bag", "this yeah woah yeah is a bag");
            Item knife = new Item(new string[] { "knife" }, "sharp knife", "making blood just by a light cut");

            me.Inventory.Put(bag);
            bag.Inventory.Put(knife);

            Look_Command look = new Look_Command();

            string command;
            bool ongoing = true;
            while (ongoing)
            {
                Console.Write("Command: ");
                command = Console.ReadLine();
                if (command.ToLower() != "end")
                {
                    Console.WriteLine(look.Execute(me, command.Split()));
                } else
                {
                    Console.WriteLine("Exiting...");
                    ongoing = false;
                }
            }
        }
    }
}
