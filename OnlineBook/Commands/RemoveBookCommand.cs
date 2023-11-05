using System;
using OnlineBook.Domain;

namespace OnlineBook.Client.Commands
{
    public class RemoveBookCommand : ICommand
    {
        private readonly IBookServiceBridge bookServiceBridge;

        public RemoveBookCommand(IBookServiceBridge bookServiceBridge)
        {
            this.bookServiceBridge = bookServiceBridge;
        }

        public void Execute()
        {
            Console.WriteLine("Remove Book");
            Console.Write("Enter the book ID to remove: ");

            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                bookServiceBridge.RemoveBook(bookId);
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid book ID. Please enter a valid number.");
            }
        }
    }
}
