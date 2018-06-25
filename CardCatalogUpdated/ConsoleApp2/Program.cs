using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CardCatalogUpdated
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a file name: ");
            string file = Console.ReadLine();
            CardCatalogUpdated cardCat = new CardCatalogUpdated(file);
            //file needed to be filename

            bool exiting = false;
            while (!exiting)
            {
                Console.Clear();
                Console.WriteLine("Please hit 1, 2, or 3 then enter: ");
                // that "\t1.\t" adds a tab space to the line
                Console.WriteLine("\t1.\tList All Books");
                Console.WriteLine("\t2.\tAdd a book");
                Console.WriteLine("\t3.\tSave and Exit");
                string choice = Console.ReadLine();
                int choiceAsInt = 0;
                int.TryParse(choice, out choiceAsInt);
                    switch (choiceAsInt)
                    {
                        case 1:
                            //change just the cardCat.link to these:
                            Console.Clear();
                            foreach (var book in cardCat.ListBooks())
                            {
                                Console.WriteLine("\t\t{0}\t\t{1}\t\t{2}", book.Title, book.Author, book.Genre);
                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter a title");
                            string title = Console.ReadLine();

                            Console.WriteLine("Enter an author");
                            string author = Console.ReadLine();

                            Console.WriteLine("Enter a genre");
                            string genre = Console.ReadLine();
                            Console.Clear();
                            cardCat.AddBook(new Book
                            {
                                Title = title,
                                Author = author,
                                Genre = genre
                            });
                            Console.WriteLine("Book added. Press any key to continue");
                            Console.ReadKey();
                            break;
                        case 3:
                            exiting = true;
                            cardCat.Save();
                            break;
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid choice. Press any key to continue");
                                Console.ReadKey();
                                break;
                            }
                    }
            } 
        }
    }
}
