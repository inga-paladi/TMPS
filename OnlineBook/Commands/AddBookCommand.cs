using System;
using BookstoreInventoryApp.Domain;
using BookstoreInventoryApp.Factory;
using OnlineBook.Domain;

namespace BookstoreInventoryApp.Client.Commands
{
    public class AddBookCommand : ICommand
    {
        private readonly IBookService bookService;
        private readonly BookFactory bookFactory;
        private readonly BookBuilder bookBuilder;
        private readonly BookPrototype bookPrototype;

        public AddBookCommand(IBookService bookService, BookFactory bookFactory, BookBuilder bookBuilder, BookPrototype bookPrototype)
        {
            this.bookService = bookService;
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
                    bookService.AddBook(book);
                    Console.WriteLine("Book added successfully using Factory Method.");
                }
                else if (choice == 2)
                {
                    // Use the Builder Pattern to construct a new book
                    Book book = CreateBookWithBuilder();
                    bookService.AddBook(book);
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
                    return bookBuilder
                        .WithTitle(title)
                        .WithAuthor(author)
                        .WithISBN(isbn)
                        .WithPrice(price)
                        .WithQuantity(quantity)
                        .Build();
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
