using System;
using OnlineBook.Domain;
using OnlineBook.Factory;

namespace OnlineBook.Client.Commands
{
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
            Console.WriteLine("Add Book");
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
        }
    }
}
