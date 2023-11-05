using OnlineBook.Client.Commands;
using OnlineBook.Client;
using OnlineBook.Domain;
using OnlineBook.Factory;
static void Main(string[] args)
{
    ILogger logger = new Logger();
    IBookService bookService = new LoggingBookServiceDecorator(new BookService(logger), logger);
    BookFactory bookFactory = new BookFactory();
    IBookServiceBridge bookServiceBridge = new BookServiceBridge(bookService);
    BookFlyweightFactory flyweightFactory = new BookFlyweightFactory();

    OnlineBookFacade facade = new OnlineBookFacade(bookServiceBridge, bookFactory, flyweightFactory );
    facade.Run();
    Console.ReadLine();
}

