using OnlineBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBook.Client
{
    public interface IBookServiceBridge
    {
        void AddBook(Book book);
        void EditBook(int bookId, Book updatedBook);
        void RemoveBook(int bookId);
        List<Book> ListBooks();
        List<Book> SearchBooks(string searchTerm);
    }
}
