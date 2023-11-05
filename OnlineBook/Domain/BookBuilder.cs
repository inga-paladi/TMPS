using BookstoreInventoryApp.Domain;

namespace OnlineBook.Domain
{
    public class BookBuilder
    {
        private string title;
        private string author;
        private string isbn;
        private decimal price;
        private int quantity;

        public BookBuilder WithTitle(string title)
        {
            this.title = title;
            return this;
        }

        public BookBuilder WithAuthor(string author)
        {
            this.author = author;
            return this;
        }

        public BookBuilder WithISBN(string isbn)
        {
            this.isbn = isbn;
            return this;
        }

        public BookBuilder WithPrice(decimal price)
        {
            this.price = price;
            return this;
        }

        public BookBuilder WithQuantity(int quantity)
        {
            this.quantity = quantity;
            return this;
        }

        public Book Build()
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
