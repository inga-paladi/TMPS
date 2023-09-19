using BookstoreInventoryApp.Domain;

public class BookService : IBookService
{
    private readonly List<Book> books;
    private readonly ILogger logger;

    public BookService(ILogger logger)
    {
        this.books = new List<Book>();
        this.logger = logger;
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        logger.Log($"Added book: {book.Title}");
    }

    public void EditBook(int bookId, Book updatedBook)
    {
        var existingBook = books.FirstOrDefault(b => b.Id == bookId);
        if (existingBook != null)
        {
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.ISBN = updatedBook.ISBN;
            existingBook.Price = updatedBook.Price;
            existingBook.Quantity = updatedBook.Quantity;
            logger.Log($"Edited book: {updatedBook.Title}");
        }
        else
        {
            logger.Log($"Book with ID {bookId} not found.");
        }
    }

    public void RemoveBook(int bookId)
    {
        var bookToRemove = books.FirstOrDefault(b => b.Id == bookId);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            logger.Log($"Removed book: {bookToRemove.Title}");
        }
        else
        {
            logger.Log($"Book with ID {bookId} not found.");
        }
    }

    public List<Book> ListBooks()
    {
        return books;
    }

    public List<Book> SearchBooks(string searchTerm)
    {
        return books.Where(book =>
            book.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            book.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            book.ISBN.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }
}

