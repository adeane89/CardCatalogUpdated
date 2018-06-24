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
    public class CardCatalogUpdated : Book
    {
        private string _filename { get; set; }
        private List<Book> Books = new List<Book>();

        public CardCatalogUpdated(string fileName)
        {
            _filename = fileName;
        }
        
        public void ListBooks()
        {
            if (File.Exists(_filename))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Stream readStream = new FileStream(_filename, FileMode.Open);
                    Books = (List<Book>)bf.Deserialize(readStream);
                    readStream.Close();
                    readStream.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            Books = new List<Book>()
            {
                new Book{Title = "Rosemary's Baby", Author = "Ira Levin", Genre = "Horror" },
                new Book{Title = "50 Shades of Grey", Author = "E.L.Green", Genre = "Erotica"},
                new Book{Title = "Harry Potter", Author = "J.K. Rowling", Genre = "Young Adult"},
                new Book{Title = "Salem's Lot", Author = "Stephen King", Genre = "Horror"},
                new Book{Title = "Percy Jackson", Author = "Rick Riordan", Genre = "Young Adult" },
            };

            var alphabetizedBooks = from AllBooks in Books
                                    orderby AllBooks.Title ascending
                                    select AllBooks;

            //replaced the forEach loop with this lambda expression
            Books.ForEach(p => Console.WriteLine("{0} written by {1}", p.Title, p.Author));

        }

        public void AddBook()
        {
            Console.WriteLine("Please enter a Title: ");
            string bookTitle = Console.ReadLine();

            Console.WriteLine("Please enter an Author: ");
            string bookAuthor = Console.ReadLine();

            Console.WriteLine("Please enter a genre: ");
            string bookGenre = Console.ReadLine();
            
            Book bookAddition = new Book() { Title = bookTitle, Author = bookAuthor, Genre = bookGenre };
            Books.Add(bookAddition);
        }

        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_filename, FileMode.Create);
            formatter.Serialize(stream, Books);
            stream.Close();
            stream.Dispose();
        }
    }
}