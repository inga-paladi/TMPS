using System;
using System.Collections.Generic;
using BookstoreInventoryApp.Domain;

namespace BookstoreInventoryApp.Client.Commands
{
    public class ListBooksCommand : ICommand
    {
        private readonly IBookService bookService;

        public ListBooksCommand(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public void Execute()
        {
            Console.WriteLine("List of Books");
            List<Book> books = bookService.ListBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Price: {book.Price:C}, Quantity: {book.Quantity}");
            }
        }
    }
}
