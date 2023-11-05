using OnlineBook.Domain;

namespace OnlineBook.Domain
{
    public class BookPrototype
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Book Clone()
        {
            return new Book
            {
                Title = this.Title,
                Author = this.Author,
                ISBN = this.ISBN,
                Price = this.Price,
                Quantity = this.Quantity
            };
        }
    }

}
