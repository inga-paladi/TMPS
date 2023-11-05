using System;
using System.Collections.Generic;
using OnlineBook.Domain;

namespace OnlineBook.Client.Commands
{
    public class ListBooksCommand : ICommand
    {
        private readonly IBookServiceBridge bookServiceBridge;
        private readonly IBookSortStrategy sortStrategy;

        public ListBooksCommand(IBookServiceBridge bookServiceBridge, IBookSortStrategy sortStrategy)
        {
            this.bookServiceBridge = bookServiceBridge;
            this.sortStrategy = sortStrategy;
        }

        public void Execute()
        {
            Console.WriteLine("List of Books");
            List<Book> books = bookServiceBridge.ListBooks();
            books = sortStrategy.SortBooks(books);
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Price: {book.Price:C}, Quantity: {book.Quantity}");
            }
        }
    }
}
