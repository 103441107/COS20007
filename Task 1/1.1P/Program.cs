using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Message myMessage = new Message("Hello World - welcome to the first laboratory");
            myMessage.Print();

            Message[] messages = new Message[4];
            messages[0] = new Message("A lovely guy!");
            messages[1] = new Message("The New Ronaldinho");
            messages[2] = new Message("Greatest fooball player ever");
            messages[3] = new Message("That is a silly name");

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            if (name.ToLower() == "huynguyen")
            {
                messages[0].Print();
            } else if (name.ToLower() == "lingardinho")
            {
                messages[1].Print();
            } else if (name.ToLower() == "braithwaite")
            {
                messages[2].Print();
            } else
            {
                messages[3].Print();
            }
            Console.ReadKey();
        }
    }
}
