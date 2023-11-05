## TOPIC : Behavioral Design Patterns
### Course: Software Design Techniques and Mechanisms
### Author: Paladi Inga, FAF-212

## Theory
Behavioral design patterns are a category of design patterns that focus on the interaction and communication between objects and classes. They provide a way to organize the behavior of objects in a way that is both flexible and reusable, while separating the responsibilities of objects from the specific implementation details. Behavioral design patterns address common problems encountered in object behavior, such as how to define interactions between objects, how to control the flow of messages between objects, or how to define algorithms and policies that can be reused across different objects and classes.
 Some examples from this category of design patterns are :
* Chain of Responsibility
* Command
* Interpreter
* Iterator
* Mediator
* Observer
* Strategy

## Objectives:
* Study and understand the Behavioral Design Patterns.
* As a continuation of the previous laboratory work, think about what communication between software entities might be involed in your system.
* Create a new Project or add some additional functionalities using behavioral design patterns.


## Main tasks:
1.  Creating a new project or extending your last one project, implement at least 1 behavioral design pattern in your project::

* The implemented design pattern should help to perform the tasks involved in your system.
* The behavioral DPs can be integrated into you functionalities alongside the structural ones.
* There should only be one client for the whole system.
2. Keep your files grouped (into packages/directories) by their responsibilities 


## Implementation description
1. Observer Pattern
The Observer Pattern is used to implement a one-to-many dependency between objects, so when one object (the subject) changes its state, all its dependents (observers) are notified and updated automatically. In the provided code, the Observer Pattern is used to notify observers when a new book is added to the book inventory.
```
// IBookAddedObserver interface
public interface IBookAddedObserver
{
    void BookAdded(Book book);
}

// BookService class
public class BookService : IBookService
{
    private readonly List<IBookAddedObserver> observers = new List<IBookAddedObserver>();

    public void AddBook(Book book)
    {
        // ...
        foreach (var observer in observers)
        {
            observer.BookAdded(book);
        }
    }

    // ...
}
```
In this code, the `IBookAddedObserver` interface defines the contract for objects that want to be notified when a book is added. The `BookService `class maintains a list of observers and notifies them when a book is added using the `BookAdded` method.
2. Strategy Pattern
The Strategy Pattern is used to define a family of algorithms, encapsulate each one, and make them interchangeable. It allows you to select an algorithm's implementation at runtime. In the code, the Strategy Pattern is used to define different strategies for sorting a list of books.
```
// IBookSortStrategy interface
public interface IBookSortStrategy
{
    List<Book> SortBooks(List<Book> books);
}

// SortByTitleStrategy class
public class SortByTitleStrategy : IBookSortStrategy
{
    public List<Book> SortBooks(List<Book> books)
    {
        return books.OrderBy(b => b.Title).ToList();
    }
}

// SortByPriceStrategy class
public class SortByPriceStrategy : IBookSortStrategy
{
    public List<Book> SortBooks(List<Book> books)
    {
        return books.OrderBy(b => b.Price).ToList();
    }
}
```
In this code, the `IBookSortStrategy` interface defines the contract for sorting strategies. The `SortByTitleStrategy` and `SortByPriceStrategy` classes implement the sorting strategies for sorting books by title and price, respectively.
3. Command Pattern
The Command Pattern is used to encapsulate a request as an object, thereby allowing for parameterization of clients with requests, queuing of requests, and logging of the requests. In the code, the Command Pattern is used to encapsulate different user commands as objects, making it easy to execute them.
```
// ICommand interface
public interface ICommand
{
    void Execute();
}

// AddBookCommand class
public class AddBookCommand : ICommand
{
    private readonly IBookServiceBridge bookServiceBridge;
    private readonly BookFactory bookFactory;

    public AddBookCommand(IBookServiceBridge bookServiceBridge, BookFactory bookFactory)
    {
        this.bookServiceBridge = bookServiceBridge;
        this.bookFactory = bookFactory;
    }

    public void Execute()
    {
        // Implementation to add a book
    }
}

```
In this code, the `ICommand` interface defines the contract for command objects. The `AddBookCommand` class is an example of a command that encapsulates the logic for adding a book to the book inventory. These commands can be easily executed by the user interface, allowing for the decoupling of user actions from the code that performs the actions.
## Conclusion
In this laboratory work, I have explored and applied three essential behavioral design patterns: Observer, Strategy, and Command. These patterns have played a crucial role in enhancing the structure and functionality of the provided codebase. The Observer Pattern has enabled the implementation of a robust event notification system, ensuring that various components can react to changes in the book inventory seamlessly.

The Strategy Pattern has allowed for the dynamic selection of sorting algorithms, making it easy to adapt and extend the codebase with new sorting strategies as needed. Lastly, the Command Pattern has provided a well-organized approach to encapsulate and execute user commands, promoting code reusability and maintainability.