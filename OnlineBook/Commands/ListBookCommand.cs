using System;
using System.Collections.Generic;
using OnlineBook.Domain;

namespace OnlineBook.Client.Commands
{
    public class ListBooksCommand : ICommand
    {
        private readonly IBookServiceBridge bookServiceBridge;

        public ListBooksCommand(IBookServiceBridge bookServiceBridge)
        {
            this.bookServiceBridge = bookServiceBridge;
        }

        public void Execute()
        {
            Console.WriteLine("List of Books");
            List<Book> books = bookServiceBridge.ListBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Price: {book.Price:C}, Quantity: {book.Quantity}");
            }
        }
    }
}
