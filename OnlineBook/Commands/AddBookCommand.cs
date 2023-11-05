using System;
using OnlineBook.Domain;
using OnlineBook.Factory;

namespace OnlineBook.Client.Commands
{
    public class AddBookCommand : ICommand
    {
        private readonly IBookServiceBridge bookServiceBridge;
        private readonly BookFactory bookFactory;
        private readonly BookBuilder bookBuilder;
        private readonly BookPrototype bookPrototype;

        public AddBookCommand(IBookServiceBridge bookServiceBridge, BookFactory bookFactory)
        {
            this.bookServiceBridge = bookServiceBridge;
            this.bookFactory = bookFactory;
            this.bookBuilder = bookBuilder;
            this.bookPrototype = bookPrototype;
        }

        public void Execute()
        {
            Console.WriteLine("Add Book");

            Console.WriteLine("Choose how to create a new book:");
            Console.WriteLine("1. Using Factory Method");
            Console.WriteLine("2. Using Builder Pattern");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 1)
                {
                    // Use the Factory Method to create a new book
                    Book book = bookFactory.CreateBook("Title", "Author", "ISBN", 29.99m, 10);
                    bookServiceBridge.AddBook(book);
                    Console.WriteLine("Book added successfully using Factory Method.");
                }
                else if (choice == 2)
                {
                    // Use the Builder Pattern to construct a new book
                    Book book = CreateBookWithBuilder();
                    bookServiceBridge.AddBook(book);
                    Console.WriteLine("Book added successfully using Builder Pattern.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        private Book CreateBookWithBuilder()
        {
            // Use the BookBuilder to construct a new book step by step
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Price: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.Write("Quantity: ");

                if (int.TryParse(Console.ReadLine(), out int quantity))
                {
                    Book book = bookFactory.CreateBook(title, author, isbn, price, quantity);
                    bookServiceBridge.AddBook(book);
                    Console.WriteLine("Book added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid quantity. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
            }

            return null;
        }
    }
}
