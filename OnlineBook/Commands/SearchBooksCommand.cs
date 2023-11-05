using System;
using System.Collections.Generic;
using OnlineBook.Domain;

namespace OnlineBook.Client.Commands
{
    public class SearchBooksCommand : ICommand
    {
        private readonly IBookServiceBridge bookServiceBridge;

        public SearchBooksCommand(IBookServiceBridge bookServiceBridge)
        {
            this.bookServiceBridge = bookServiceBridge;
        }

        public void Execute()
        {
            Console.WriteLine("Search Books");
            Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine();
            List<Book> books = bookServiceBridge.SearchBooks(searchTerm);
            if (books.Count == 0)
            {
                Console.WriteLine("No matching books found.");
            }
            else
            {
                Console.WriteLine("Matching Books:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Price: {book.Price:C}, Quantity: {book.Quantity}");
                }
            }
        }
    }
}
