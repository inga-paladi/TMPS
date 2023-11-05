using System;
using System.Collections.Generic;
using System.Windows.Input;
using OnlineBook.Domain;
using OnlineBook.Factory;

namespace OnlineBook.Client
{
    public class UserInterface
    {
        private readonly Dictionary<int, ICommand> commands;
        private readonly IBookServiceBridge bookServiceBridge;


        public UserInterface(Dictionary<int, ICommand> commands, IBookServiceBridge bookServiceBridge)
        {
            this.commands = commands;
            this.bookServiceBridge = bookServiceBridge;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Bookstore Inventory Management");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Edit Book");
                Console.WriteLine("3. Remove Book");
                Console.WriteLine("4. List Books");
                Console.WriteLine("5. Search Books");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (commands.TryGetValue(choice, out ICommand command))
                    {
                        command.Execute();
                    }
                    else if (choice == 6)
                    {
                        Console.WriteLine("Exiting the application.");
                        break;  // Exit the loop and end the program
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
