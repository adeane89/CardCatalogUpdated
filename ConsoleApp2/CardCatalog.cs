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

        public void ListBooks(Book addBook = null)
        {
            if (File.Exists(_filename))
            {
                Stream readStream = new FileStream(_filename, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    Books = (List<Book>)bf.Deserialize(readStream);
                    readStream.Close();
                    readStream.Dispose();
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("Failed to deserialize: {0}", ex.Message);
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
            
            if (addBook != null)
            {
                Books.Add(addBook);
            }

            var alphabetizedBooks = from AllBooks in Books
                                    orderby AllBooks.Title ascending
                                    select AllBooks;

            Books.ForEach(p => Console.WriteLine("{0} written by {1}", p.Title, p.Author));
        }

        public Book AddBook()
        {
            //Book newBook = new Book();

            Console.WriteLine("Please enter a Title: ");
            //newBook.Title = Console.ReadLine();
            string bookTitle = Console.ReadLine();

            Console.WriteLine("Please enter an Author: ");
            //newBook.Author = Console.ReadLine();
            string bookAuthor = Console.ReadLine();

            Console.WriteLine("Please enter a genre: ");
            //newBook.Genre = Console.ReadLine();
            string bookGenre = Console.ReadLine();

            Book newBook = new Book() { Title = bookTitle, Author = bookAuthor, Genre = bookGenre };
            //ListWithAdded(newBook);
            return newBook;
        }
        /*
        static void ListWithAdded(Book newBook)
        {
            Console.WriteLine("{0} written by {1}", newBook.Title, newBook.Author);
        }
        */
        public void Save()
        {
            FileStream stream = new FileStream(_filename, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(stream, Books);
                stream.Close();
                stream.Dispose();
            }

            catch (SerializationException ex)
            {
                Console.WriteLine("Failed to serialize: {0}", ex.Message);
            }
        }
    }
}