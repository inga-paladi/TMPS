## TOPIC : Creational Design Patterns
### Course: Software Design Techniques and Mechanisms
### Author: Paladi Inga, FAF-212

## Theory
 Creational design patterns are a category of design patterns that focus on the process of object creation. They provide a way to create objects in a flexible and controlled manner, while decoupling the client code from the specifics of object creation. Creational design patterns address common problems encountered in object creation, such as how to create objects with different initialization parameters, how to create objects based on certain conditions, or how to ensure that only a single instance of an object is created. There are several creational design patterns that have their own strengths and weaknesses. Each of it is best suited for solving specific problems related to object creation. By using creational design patterns, developers can improve the flexibility, maintainability, and scalability of their code.
- Singleton
- Builder
- Prototype
- Object Pooling
- Factory Method
- Abstract Factory


## Objectives:
* Study and understand the Creational Design Patterns.
* Choose a domain, define its main classes/models/entities and choose the appropriate instantiation mechanisms.
* Use some creational design patterns for object instantiation in a sample project.
## Main tasks:
* Choose an OO programming language and a suitable IDE or Editor (No frameworks/libs/engines allowed).
* Select a domain area for the sample project.
* Define the main involved classes and think about what instantiation mechanisms are needed.
* Based on the previous point, implement at least 2 creational design patterns in your project.



## Implementation description
1. Factory Method
The Factory Method Pattern is used to create objects without specifying the exact class  of object that will be created 
The `BookFactory` class serves as a factory for creating `Book` objects
```
namespace BookstoreInventoryApp.Factory
{
    public class BookFactory
    {
        public Book CreateBook(string title, string author, string isbn, decimal price, int quantity)
        {
            return new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                Price = price,
                Quantity = quantity
            };
        }
    }
}
``` 
The `CreateBook` method in the BookFactory class creates instances of the `Book` class, encapsulating the object creation logic and providing a way to create `Book` objects with specific attributes.
2. Builder Pattern
The Builder Patter is used to construct complex object step by step. The `BookBuilder` class demonstrates this.
```
public class BookBuilder
{
    // ... (methods to set individual properties)

    public Book Build()
    {
        return new Book
        {
            Title = title,
            Author = author,
            ISBN = isbn,
            Price = price,
            Quantity = quantity
        };
    }
}
```
We can use `BookBuilder`to set various properties of a `Book` object using a interface and then call the `Build` method to create the `Book` object with the specified properties.
3. Prototype Pattern
The Prototype Pattern is used to create new objects by copying an existing object, known as a prototype. In this code, the  `Bookprototype`  class demonstrates this pattern.
```
public class BookPrototype
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Book Clone()
    {
        return new Book
        {
            Title = this.Title,
            Author = this.Author,
            ISBN = this.ISBN,
            Price = this.Price,
            Quantity = this.Quantity
        };
    }
}
```
We can create a new `Book` object by calling the `Clone` method on a `BockPrototype`object, which copies the properties from the prototype and returns a new `Book` object.
4. Singleton Pattern
The Singleton Pattern ensures that a class has only one instance and provides a global point of access to that instance. In this code, the `Logger`class demonstrates this pattern.
```public class Logger : ILogger
{
    private static Logger instance;

    private Logger() { }

    public static Logger GetInstance()
    {
        if (instance == null)
        {
            instance = new Logger();
        }
        return instance;
    }

    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
    }
}
```
The `Logger `class has a private constructor and a static `GetInstance `method, which ensures that only one instance of `Logger `is created and returned throughout the application. This provides a centralized logging mechanism.

## Conclusion
In this laboratory work, we had to demonstrated how the application can use various creational design patterns. By implementing these creational design patterns, the 'Bookstore Inventory Management' application achieves several benefits, including separation of object creation logic, improved code maintainability, flexibility to create different types of objects, and efficient object creation processes. These patterns contribute to a more organized and scalable codebase, making it easier to extend and enhance the application in the future.