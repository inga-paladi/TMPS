using OnlineBook.Domain;

namespace OnlineBook.Factory
{
    public class BookFactory
    {
        public Book CreateBook(string title, string author, string isbn, decimal price, int quantity)
        {
            return new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                Price = price,
                Quantity = quantity
            };
        }
    }
}


