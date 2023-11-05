using OnlineBook.Domain;
using OnlineBook.Client.Commands;
using OnlineBook.Factory;
using System;
using System.Collections.Generic;

namespace OnlineBook.Client
{
    public class OnlineBookFacade
    {
        private readonly IBookServiceBridge bookServiceBridge;
        private readonly BookFactory bookFactory;
        private readonly BookFlyweightFactory flyweightFactory;

        public OnlineBookFacade(IBookServiceBridge bookServiceBridge, BookFactory bookFactory, BookFlyweightFactory flyweightFactory)
        {
            this.bookServiceBridge = bookServiceBridge;
            this.bookFactory = bookFactory;
            this.flyweightFactory = flyweightFactory;
        }

        public void Run()
        {
            Dictionary<int, ICommand> commands = new Dictionary<int, ICommand>
            {
                { 1, new AddBookCommand(bookServiceBridge, bookFactory) },
                { 2, new EditBookCommand(bookServiceBridge) },  
                { 3, new RemoveBookCommand(bookServiceBridge) },
                { 4, new ListBooksCommand(bookServiceBridge) },
                { 5, new SearchBooksCommand(bookServiceBridge) },
            };

            UserInterface ui = new UserInterface(commands, bookServiceBridge);
            ui.Run();
        }
        public void DisplaySharedBookFlyweight(string title, string author, string isbn)
        {
            IBookFlyweight flyweight = flyweightFactory.GetBookFlyweight(title, author, isbn);
            flyweight.Display();
        }
    }
}
