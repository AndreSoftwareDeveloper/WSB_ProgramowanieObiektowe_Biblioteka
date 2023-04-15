using System;
using System.Collections.Generic;
using System.IO;

namespace Modul2
{
    class Program
    {
        static Book CreateObject()
        {
            Book Book_ExampleBook = new Book();
            return Book_ExampleBook;
        }
        static void Main()
        {
            Book Diuna = new Book();
            //Diuna.InitializeData();
            //Diuna.ShowAllData();
            //Diuna.ShowBorrowingStatus();
            //Diuna.ValidData();
            //Book.Help();

            Book TheWitcher = new Book();
            Book.readAmountOfObjects();
            TheWitcher.InitializeData();
            TheWitcher.ShowAllData();
            Console.Write("\n");

            Book LordOfTheRings = new Book();
           /* Book.czytajIloscObiektow();
            LordOfTheRings.ShowAllData();
            try
            {
                LordOfTheRings.EnterData();
            }
            catch(EqualOrLessThanZeroException)
            {
                Console.WriteLine("ISBN number should be greater than zero! Book code should be different than zero!");
            }

            Book UserManual = new Book("Jan Nowak");
            Book.czytajIloscObiektow();
            UserManual.ShowAllData();
            Pomocnik p_Helper = new Pomocnik();*/

            Book k2,k1= new Book();
            /*k1.EnterData();
            k2 = k1;
            k2.ShowAllData();
            Book.czytajIloscObiektow();
            Console.Write("\n");
            k1.EnterData();A
            k2.ShowAllData();*/

            /*CreateObject();
            Console.ReadKey();A
            System.GC.Collect();*/

            List<Book> ListOfFourObjects = new List<Book>();
            ListOfFourObjects.Add(Diuna);
            ListOfFourObjects.Add(TheWitcher);
            ListOfFourObjects.Add(k1);
            ListOfFourObjects.Add(LordOfTheRings);
            ListOfFourObjects.RemoveAt(3);
            ListOfFourObjects.RemoveAt(2);
            ListOfFourObjects.RemoveAt(1);
            ListOfFourObjects.RemoveAt(0);
            System.GC.Collect();
        }
    }    
}
