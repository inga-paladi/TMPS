using BookstoreInventoryApp.Client.Commands;
using BookstoreInventoryApp.Client;
using BookstoreInventoryApp.Domain;
using BookstoreInventoryApp.Factory;
static void Main(string[] args)
{
    ILogger logger = new Logger();
    IBookService bookService = new BookService(logger);
    BookFactory bookFactory = new BookFactory();

    Dictionary<int, ICommand> commands = new Dictionary<int, ICommand>
    {
        { 1, new AddBookCommand(bookService, bookFactory) },
        { 2, new RemoveBookCommand(bookService) },
        { 3, new ListBooksCommand(bookService) },
        { 4, new SearchBooksCommand(bookService) }
    };

    UserInterface ui = new UserInterface(commands);
    ui.Run();
}
