using System;
using System.Collections.Generic;
using BookstoreInventoryApp.Domain;

namespace BookstoreInventoryApp.Client.Commands
{
    public class SearchBooksCommand : ICommand
    {
        private readonly IBookService bookService;

        public SearchBooksCommand(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public void Execute()
        {
            Console.WriteLine("Search Books");
            Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine();
            List<Book> books = bookService.SearchBooks(searchTerm);
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
