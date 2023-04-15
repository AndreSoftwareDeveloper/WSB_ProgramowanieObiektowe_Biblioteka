using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Modul2
{
    public class EqualOrLessThanZeroException : Exception { }
    class Book
    {
        private int i_CatalogNumber;
        private uint uint_ISBN;
        private string s_Author;
        private string s_PremiereDate;
        private string s_BookCode;
        private bool b_Borrowed;
        private bool b_Reserved;
        private static int i_ObjectCounter = 0;

        public bool b_borrowed
        {
            get => b_Borrowed;
            set => b_Borrowed = value;
        }
        public bool b_borrowed_withFileWriting
        {
            get => b_Borrowed;
            set
            {
                b_Borrowed = value;
                StreamWriter sw_NewFile = new StreamWriter(i_CatalogNumber + ".txt");
                sw_NewFile.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}",
                this.i_CatalogNumber, this.uint_ISBN, this.s_Author, this.s_PremiereDate, this.s_BookCode, this.b_Borrowed, this.b_Reserved);
            }
        }

        public void EnterData()
        {
            Console.WriteLine("Enter book's catalog number:");
            this.i_CatalogNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter book's ISBN number:");
            this.uint_ISBN = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine("Enter code of this book:");
            this.s_BookCode = Convert.ToString(Console.ReadLine());

            if (this.i_CatalogNumber <= 0 || this.uint_ISBN <= 0 || this.s_BookCode == "0")
                throw new EqualOrLessThanZeroException();

            Console.WriteLine("Enter who's author of this book:");
            this.s_Author = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter when was the premiere of this book:");
            this.s_PremiereDate = Convert.ToString(Console.ReadLine());

        InsertData1:
            Console.WriteLine("Is this book on loan? Y/N");
            char answer = Convert.ToChar(Console.ReadLine());
            switch (answer)
            {
                case 'Y':
                    this.b_Borrowed = true;
                    break;
                case 'N':
                    this.b_Borrowed = false;
                    break;
                default:
                    Console.WriteLine("Incorrect data was entered!");
                    goto InsertData1;
                    break;
            }

        InsertData2:
            Console.WriteLine("Is this book reserved? Y/N");
            answer = Convert.ToChar(Console.ReadLine());
            switch (answer)
            {
                case 'Y':
                    this.b_Reserved = true;
                    break;
                case 'N':
                    this.b_Reserved = false;
                    break;
                default:
                    Console.WriteLine("Incorrect data was entered!");
                    goto InsertData2;
                    break;
            }
        }

        public Book()
        {
            this.i_CatalogNumber = 9999;
            this.uint_ISBN = 9999;
            this.s_Author = "Unknown artist";
            this.s_PremiereDate = "01-01-1900";
            this.s_BookCode = "WRONG_CODE";
            this.b_Borrowed = false;
            this.b_Reserved = false;
            i_ObjectCounter++;
            Console.WriteLine("To ja, kontruktor domyślny!");
        }

        public Book(int i_CatalogNumber, uint uint_ISBN,
        string s_Author, string s_PremiereDate, string s_BookCode,
        bool b_Borrowed = false, bool b_Reserved = false)
        {
            this.i_CatalogNumber = i_CatalogNumber;
            this.uint_ISBN = uint_ISBN;
            this.s_Author = s_Author;
            this.s_PremiereDate = s_PremiereDate;
            this.s_BookCode = s_BookCode;
            this.b_Borrowed = b_Borrowed;
            this.b_Reserved = b_Reserved;
            i_ObjectCounter++;
        }

        public Book(string s_Author)
        {
            this.InitializeData();
            this.s_Author = s_Author;
            i_ObjectCounter++;
        }

        public Book(string s_Author, string s_BookCode = "WRONG_CODE",
            string s_PremiereDate = "03-03-2013")
        {
            this.i_CatalogNumber = 9999;
            this.uint_ISBN = 9999;
            this.b_Borrowed = false;
            this.b_Reserved = false;

            this.s_Author = s_Author;
            this.s_BookCode = s_BookCode;
            this.s_PremiereDate = s_PremiereDate;
            i_ObjectCounter++;
        }
        ~Book()
        {
            i_ObjectCounter--;
            Console.WriteLine("To ja, destruktor!");
        }
        public static void readAmountOfObjects()
        {
            Console.WriteLine("Ilość książek: {0}", i_ObjectCounter);
        }

        public void InitializeData()
        {
            this.i_CatalogNumber = 8888;
            this.uint_ISBN = 8888;
            this.s_Author = "Unknown writer";
            this.s_PremiereDate = "02-02-2010";
            this.s_BookCode = "WRONG_CODE";
            this.b_Borrowed = true;
            this.b_Reserved = true;
        }

        public void ShowAllData()
        {

            Console.WriteLine("Numer katalogowy ksiazki wynosi: {0}\nNumerISBN jest równy: {1}\nAutorem jest: {2}\nKsiążkę wydano: {3}\n" +
                "Kod książki wynosi: {4}\nWypozyczona: {5}\nZarezerwowana: {6}",
                this.i_CatalogNumber, this.uint_ISBN, this.s_Author, this.s_PremiereDate, this.s_BookCode, this.b_Borrowed, this.b_Reserved);
        }

        public void ShowBorrowingStatus()
        {
            if (this.b_Borrowed)
                Console.WriteLine("Książka jest wypożyczona.");
            else
                Console.WriteLine("Książka nie jest wypożyczona.");
        }

        public bool isBorrowed() => b_borrowed;

        public void ModifyBorrowingStatus(bool b_Borrowed)
        {
            this.b_Borrowed = b_Borrowed;
        }

        public static string Help()
        {
            string s_Answer = "qwerty";
            Console.WriteLine("What do you want to know?\n1 - How to create object of this class" +
            "\n2 - How to show all data");
            int x = Convert.ToInt16(Console.ReadLine());
            switch (x)
            {
                case 1:
                    s_Answer = "\"new\" operator";
                    Console.WriteLine("Simply create an object using \"new\" operator. To modify default values use EnterData() method.");
                    return s_Answer;
                    break;
                case 2:
                    Console.WriteLine("Simply use \"ShowAllData()\" method, or look into txt file if created.");
                    s_Answer = "\"ShowAllData()\" method or look into txt file.";
                    return s_Answer;
                    break;
                default:
                    return s_Answer;
                    break;
            }
        }

        private void CheckDate()
        {
            string s_DayAsString = Convert.ToString(this.s_PremiereDate[0]) + Convert.ToString(this.s_PremiereDate[1]);
            int i_Day = Convert.ToInt32(s_DayAsString);
            Console.WriteLine(i_Day);
            if (i_Day < 1 || i_Day > 31)
                Console.WriteLine("Enter correct premiere day info!");

            string s_MonthAsString = Convert.ToString(this.s_PremiereDate[3]) + Convert.ToString(this.s_PremiereDate[4]);
            int i_Month = Convert.ToInt32(s_MonthAsString);
            if (i_Month < 1 || i_Month > 12)
                Console.WriteLine("Enter correct premiere month info!");

            string s_YearAsString = Convert.ToString(this.s_PremiereDate[6]) + this.s_PremiereDate[7] + this.s_PremiereDate[8] + this.s_PremiereDate[9];
            int i_Year = Convert.ToInt32(s_YearAsString);
            if (i_Year < 1900)
                Console.WriteLine("What an old book");
            else if (i_Year > 2022)
                Console.WriteLine("Back to the future?");

            if (this.s_PremiereDate[2] != '-' || this.s_PremiereDate[5] != '-')
                Console.WriteLine("Enter data in correct format!");
        }

        public void ValidData()
        {
            CheckDate();
            if (this.s_BookCode == "WRONG_CODE")
                Console.WriteLine("Enter correct book code!");
        }

        Book CloneObject()
        {
            Book Book_Clone = new Book();
            Book_Clone.i_CatalogNumber = i_CatalogNumber;
            Book_Clone.uint_ISBN = uint_ISBN;
            Book_Clone.s_Author = s_Author;
            Book_Clone.s_PremiereDate = s_PremiereDate;
            Book_Clone.s_BookCode = s_BookCode;
            Book_Clone.b_Borrowed = b_Borrowed;
            Book_Clone.b_Reserved = b_Reserved;
            return Book_Clone;
        }
    }
}
