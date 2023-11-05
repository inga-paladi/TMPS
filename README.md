## TOPIC : Structural Design Patterns
### Course: Software Design Techniques and Mechanisms
### Author: Paladi Inga, FAF-212

## Theory
Structural design patterns are a category of design patterns that focus on the composition of classes and objects to form larger structures and systems. They provide a way to organize objects and classes in a way that is both flexible and efficient, while allowing for the reuse and modification of existing code. Structural design patterns address common problems encountered in the composition of classes and objects, such as how to create new objects that inherit functionality from existing objects, how to create objects that share functionality without duplicating code, or how to define relationships between objects in a flexible and extensible way.
Some examples of from this category of design patterns are:
* Adapter
* Bridge
* Composite
* Decorator
* Facade
* Flyweight
* Proxy

## Objectives:
* Study and understand the Structural Design Patterns.
* As a continuation of the previous laboratory work, think about the functionalities that your system will need to provide to the user.
* Implement some additional functionalities, or create a new project using structural design patterns.


## Main tasks:
1.  By creating a new project, or extending your last one (Lab work Nr2), implement at least 2 structural design patterns in your project:

* The implemented design pattern should help to perform the tasks involved in your system.
* The object creation mechanisms/patterns can now be buried into the functionalities instead of using them into the client.
There should only be one client for the whole system.
2. Keep your files grouped (into packages/directories) by their responsibilities 


## Implementation description
1. Decorator Pattern
 This pattern allows behavior to be added to an individual object, either statically or dynamically, without affecting the behavior of other objects from the same class. In this code, the `LoggingBookServiceDecorator` decorates the `IBookService` interface to add logging functionality. It intercepts calls to methods like `AddBook`, `EditBook`, and `RemoveBook`, logs the actions, and then delegates the call to the underlying bookService. For example, when a book is added or edited, the decorator logs the action using the provided logger.
```
public class LoggingBookServiceDecorator : IBookService
{
    // ...
    public void AddBook(Book book)
    {
        bookService.AddBook(book);
        logger.Log($"Added book: {book.Title}");
    }
    // ...
}
```
2. Facade Pattern
The `OnlineBookFacade` acts as a facade that provides a simplified and unified interface to interact with the complex system of managing books.
It hides the complexities of creating and using various components like `IBookServiceBridge`, `BookFactory`, and `BookFlyweightFactory`, making it easier for clients to use the system. 
```
public class OnlineBookFacade
{
    // ...
    public void Run()
    {
        // ...
        UserInterface ui = new UserInterface(commands, bookServiceBridge);
        ui.Run();
    }
    // ...
}
```
3. Flyweight Pattern
The Flyweight pattern is used in the `BookFlyweight` and `BookFlyweightFactory` classes. It's designed to minimize memory usage when dealing with a large number of similar objects. In this case, it's used to create and manage book objects that share common data, such as title, author, and ISBN, in a memory-efficient way. The `BookFlyweightFactory` ensures that only one instance of a book with specific attributes is created and reused.
```
public class BookFlyweightFactory
{
    private Dictionary<string, IBookFlyweight> flyweights = new Dictionary<string, IBookFlyweight>();

    public IBookFlyweight GetBookFlyweight(string title, string author, string isbn)
    {
        string key = $"{title}-{author}-{isbn}";
        if (!flyweights.ContainsKey(key))
        {
            flyweights[key] = new BookFlyweight(title, author, isbn);
        }
        return flyweights[key];
    }
}
```
4. Bridge Pattern
The Bridge pattern is employed in the `BookServiceBridge` class, which acts as an intermediary between the client code and the book service. It allows the client to interact with the book service through an abstract interface (`IBookServiceBridge`). This decouples the client code from the specific book service implementation (`IBookService`) and allows for easy substitution of different book service implementations without affecting the client code.
```
public class BookServiceBridge : IBookServiceBridge
{
    private readonly IBookService bookService;

    public BookServiceBridge(IBookService bookService)
    {
        this.bookService = bookService;
    }

    // Methods here act as a bridge to the actual book service implementation.
}

```
## Conclusion
In this laboratory work, I have explored and applied four essential structural design patterns, namely the Decorator, Facade, Flyweight, and Bridge patterns, to create a well-structured and modular book inventory management system. Each pattern serves a distinct purpose in enhancing the system's functionality and maintainability. These design patterns have not only improved the code's organization and maintainability but also demonstrated their significance in building flexible and scalable software systems.