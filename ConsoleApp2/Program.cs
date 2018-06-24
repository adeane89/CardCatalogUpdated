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

            string promptAnswer = "";
            do
            {
                string[] lines = {"Please hit 1, 2, or 3 then enter: ",
                "1. List All books",
                "2. Add A Book",
                "3. Save and Exit"};
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                try
                {
                    promptAnswer = Console.ReadLine();
                    switch (promptAnswer)
                    {
                        case "1":
                            cardCat.ListBooks();
                            break;
                        case "2":
                            cardCat.AddBook();
                            break;
                        case "3":
                            cardCat.Save();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            } while (promptAnswer != "3");
        }
    }
}
