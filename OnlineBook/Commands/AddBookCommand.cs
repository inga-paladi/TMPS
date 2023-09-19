using System;
using BookstoreInventoryApp.Domain;
using BookstoreInventoryApp.Factory;

namespace BookstoreInventoryApp.Client.Commands
{
    public class AddBookCommand : ICommand
    {
        private readonly IBookService bookService;
        private readonly BookFactory bookFactory;

        public AddBookCommand(IBookService bookService, BookFactory bookFactory)
        {
            this.bookService = bookService;
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
                    bookService.AddBook(book);
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
