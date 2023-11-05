using OnlineBook.Domain;

namespace OnlineBook.Client
{
    public class BookServiceBridge : IBookServiceBridge
    {
        private readonly IBookService bookService;

        public BookServiceBridge(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public void AddBook(Book book)
        {
            bookService.AddBook(book);
        }

        public void EditBook(int bookId, Book updatedBook)
        {
            bookService.EditBook(bookId, updatedBook);
        }

        public void RemoveBook(int bookId)
        {
            bookService.RemoveBook(bookId);
        }

        public List<Book> ListBooks()
        {
            return bookService.ListBooks();
        }

        public List<Book> SearchBooks(string searchTerm)
        {
            return bookService.SearchBooks(searchTerm);
        }
    }
}
