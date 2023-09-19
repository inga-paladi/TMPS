using System;
using System.Collections.Generic;
using System.Windows.Input;
using BookstoreInventoryApp.Domain;
using BookstoreInventoryApp.Factory;

namespace BookstoreInventoryApp.Client
{
    public class UserInterface
    {
        private readonly Dictionary<int, ICommand> commands;

        public UserInterface(Dictionary<int, ICommand> commands)
        {
            this.commands = commands;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Bookstore Inventory Management");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. List Books");
                Console.WriteLine("4. Search Books");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (commands.TryGetValue(choice, out ICommand command))
                    {
                        command.Execute();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
        }
    }
}
