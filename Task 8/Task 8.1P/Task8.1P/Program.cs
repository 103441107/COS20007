using System;

namespace Task8._1P
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library("Library");

            Book sach1 = new Book("Toi tai gioi ban cung the", "Nguyen Dang Khoa", "1122");
            Book sach2 = new Book("Truyen Kieu", "Nguyen Du", "1212");
            
            Game trochoi1 = new Game("CSGO", "Steam", "M");
            Game trochoi2 = new Game("Free Fire", "Garena", "R");
            sach1.OnLoan = true;
            trochoi1.OnLoan = true;

            library.AddResource(sach1);
            library.AddResource(sach2);
            library.AddResource(trochoi1);
            library.AddResource(trochoi2);

           
            Console.WriteLine("Truyen Kieu is not on loan? " + library.HasResource("Truyen Kieu"));
            Console.WriteLine("CSGO is not on loan? " + library.HasResource("CSGO"));
            Console.WriteLine("Free Fire is not on loan? " + library.HasResource("Free Fire"));
            Console.WriteLine("Toi tai gioi ban cung the is not on loan? " + library.HasResource("Toi tai gioi ban cung the"));
            

        }
    }
}
