using BookstoreInventoryApp.Domain;

public interface IBookService
{
    void AddBook(Book book);
    void EditBook(int bookId, Book updatedBook);
    void RemoveBook(int bookId);
    List<Book> ListBooks();
    List<Book> SearchBooks(string searchTerm);
}
