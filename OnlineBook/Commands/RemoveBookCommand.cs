using System;
using BookstoreInventoryApp.Domain;

namespace BookstoreInventoryApp.Client.Commands
{
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
}
