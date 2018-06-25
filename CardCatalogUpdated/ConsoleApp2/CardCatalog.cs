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
    public class CardCatalogUpdated
    {
        private string _filename;
        private List<Book> books;

        public CardCatalogUpdated(string fileName)
        {
            _filename = fileName;
            
            if (File.Exists(_filename))
            {
                this.books = new List<Book>();
                try
                {
                    Stream readStream = new FileStream(_filename, FileMode.Create);
                    BinaryFormatter bf = new BinaryFormatter();
                    books = (List<Book>)bf.Deserialize(readStream);
                    readStream.Close();
                    readStream.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            this.books = new List<Book>();
        }
        
        public Book[] ListBooks()
        {
            return this.books.ToArray();
        }

        public void AddBook(Book newBook)
        {
            this.books.Add(newBook);
        }

        public void Save()
        {
            FileStream stream = new FileStream(_filename, FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, books);
            stream.Close();
            stream.Dispose();
        }
    }
}