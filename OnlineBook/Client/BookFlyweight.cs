using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBook.Client
{
    public class BookFlyweight : IBookFlyweight
    {
        private string title;
        private string author;
        private string isbn;

        public BookFlyweight(string title, string author, string isbn)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
        }

        public void Display()
        {
            Console.WriteLine($"Title: {title}, Author: {author}, ISBN: {isbn}");
        }
    }
}
