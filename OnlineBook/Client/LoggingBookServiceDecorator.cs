using OnlineBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBook.Client
{
    public class LoggingBookServiceDecorator : IBookService
    {
        private readonly IBookService bookService;
        private readonly ILogger logger;

        public LoggingBookServiceDecorator(IBookService bookService, ILogger logger)
        {
            this.bookService = bookService;
            this.logger = logger;
        }

        public void AddBook(Book book)
        {
            bookService.AddBook(book);
            logger.Log($"Added book: {book.Title}");
        }

        public void EditBook(int bookId, Book updatedBook)
        {
            bookService.EditBook(bookId, updatedBook);
            logger.Log($"Updated book: {updatedBook}");
        }

        public List<Book> ListBooks()
        {
            return bookService.ListBooks();
            logger.Log($"List books: {ListBooks()}");
        }

        public void RemoveBook(int bookId)
        {
            bookService.RemoveBook(bookId);
            logger.Log($"Removed book: {bookId}");

        }

        public List<Book> SearchBooks(string searchTerm)
        {
            return bookService.SearchBooks(searchTerm);
            logger.Log($"Search book: {searchTerm}");
        }
    }
}
