using BookstoreInventoryApp.Client.Commands;
using BookstoreInventoryApp.Client;
using BookstoreInventoryApp.Domain;
using BookstoreInventoryApp.Factory;
using OnlineBook.Domain;

static void Main(string[] args)
{
    ILogger logger = Logger.GetInstance();
    IBookService bookService = new BookService(logger);
    BookFactory bookFactory = new BookFactory();
    BookBuilder bookBuilder = new BookBuilder();
    BookPrototype bookPrototype = new BookPrototype();

    Dictionary<int, ICommand> commands = new Dictionary<int, ICommand>
    {
        { 1, new AddBookCommand(bookService,bookFactory, bookBuilder, bookPrototype) },
        { 2, new RemoveBookCommand(bookService) },
        { 3, new ListBooksCommand(bookService) },
        { 4, new SearchBooksCommand(bookService) }
    };

    UserInterface ui = new UserInterface(commands);
    ui.Run();
}
