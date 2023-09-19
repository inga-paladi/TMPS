## TOPIC : SOLID Principles
### Course: Software Design Techniques and Mechanisms
### Author: Paladi Inga, FAF-212

## Theory
 SOLID is a set of five object-oriented design principles intended to make software designs more maintainable, flexible, and easy to understand. The acronym stands for Single Responsibility Principle, Open-Closed Principle, Liskov Substitution Principle, Interface Segregation Principle, and Dependency Inversion Principle. Each principle addresses a specific aspect of software design, such as the organization of responsibilities, the handling of dependencies, and the design of interfaces. By following these principles, software developers can create more modular, testable, and reusable code that is easier to modify and extend over time. These principles are widely accepted and adopted in the software development community and can be applied to any object-oriented programming language.


## Objectives:
* Study and understand the SOLID Principles.
*  Choose a domain, define its main classes/models/entities and choose the appropriate instantiation mechanisms.
*  Create a sample project that respects SOLID Principles.

## Main tasks:
* Choose an OO programming language and a suitable IDE or Editor (No frameworks/libs/engines allowed).
* Select a domain area for the sample project.
* Define the main involved classes and think about what instantia
tion mechanisms are needed.
*  Respect SOLID Principles in your project.



## Implementation description
1. Single Responsibility Principle (SRP):
Each class in this project has a single responsibility.
For example, the `AddBookCommand` class is responsible for 
adding a book, the `UserInterface` class manages user
interactions, and the `BookService` class handles
book-related operations. These classes do not have
multiple responsibilities.
```
public class UserInterface
    {
        private readonly Dictionary<int, ICommand> commands;

        public UserInterface(Dictionary<int, ICommand> commands)
        {
            this.commands = commands;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Bookstore Inventory Management");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. List Books");
                Console.WriteLine("4. Search Books");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (commands.TryGetValue(choice, out ICommand command))
                    {
                        command.Execute();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
        }
    }
``` 
2. Open/Closed Principle (OCP):
The code is open for extension and closed for 
modification. You can add new commands by creating new 
classes that implement the `ICommand` interface without 
modifying existing code. For example, adding a new command 
for updating a book would not require changes to the existing
classes
```
namespace BookstoreInventoryApp.Client
{
    public interface ICommand
    {
        void Execute();
    }
}

```
3. Liskov Substitution Principle (LSP)
UserInterface class takes a list of ICommand objects, 
and it uses the Execute method on these objects when 
the user selects a command (e.g., "Add Book" or
"Remove Book"). This behavior ensures that different 
command implementations can be seamlessly plugged into 
the user interface without 
changing the core logic of the interface.
    `ICommand` interface, which serves as the base class (or contract) for all command-related operations. This interface ensures that all derived command classes (such as EditBookCommand and RemoveBookCommand) implement the Execute method, allowing them to be used interchangeably
where an ICommand is expected.
```
public class RemoveBookCommand : ICommand
    {
        private readonly IBookService bookService;

        public RemoveBookCommand(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public void Execute()
        {
            Console.WriteLine("Remove Book");
            Console.Write("Enter the book ID to remove: ");

            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                bookService.RemoveBook(bookId);
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid book ID. Please enter a valid number.");
            }
        }
    }
```
4.Interface Segregation Principle (ISP):

The interfaces (`ICommand`, `IBookService`, `ILogger`) are
focused on specific contracts, and classes only implement
the methods that are relevant to their responsibilities. 
For instance, `IBookService` includes methods 
related to book
management, 
while `ILogger` includes only the Log method.
```
public interface ILogger
    {
        void Log(string message);
    }
```
5. Dependency Inversion Principle (DIP):
tates that high-level modules should not depend on low-level modules
The Logger class implements the `ILogger` interface.
This allows the `Logger` class to act as a concrete 
implementation of the logging functionality, but it does so by adhering to an interface.
In this code, the `BookService` class depends on `ILogger`,
which is an abstraction (interface) rather than a specific implementation.
This adherence to the interface (ILogger) follows the DIP principle because high-level modules (e.g., BookService) depend on abstractions 
(ILogger).
```
// ILogger interface
public interface ILogger
{
    void Log(string message);
}

// Logger class implementing ILogger
public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
    }
}

```
Dependency injection is used in the BookService class to inject an ILogger instance.
This means that the BookService class doesn't create or depend on a specific
implementation of the logger;
it relies on whatever implementation is provided through its constructor.
This allows you to change the logging behavior by providing a different 
implementation of ILogger without modifying the BookService class.
```
public class BookService : IBookService
{
    private readonly List<Book> books;
    private readonly ILogger logger;

    public BookService(ILogger logger)
    {
        this.books = new List<Book>();
        this.logger = logger; 
    }

    ...
}
```
## Conclusion
In this laboratory work, we have demonstrated how the application of SOLID principles can lead to code that is not only more straightforward to comprehend but also easier to maintain and expand upon. These guiding principles significantly contribute to the creation of robust and adaptable software systems that are less susceptible to defects and more readily adjustable to evolving requirements.