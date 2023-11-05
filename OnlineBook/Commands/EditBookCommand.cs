using OnlineBook.Domain;

namespace OnlineBook.Client.Commands
{
    public class EditBookCommand : ICommand
    {
        private readonly IBookServiceBridge bookServiceBridge;

        public EditBookCommand(IBookServiceBridge bookServiceBridge)
        {
            this.bookServiceBridge = bookServiceBridge;
        }

        public void Execute()
        {
            Console.WriteLine("Edit Book");
            Console.Write("Enter the book ID to edit: ");

            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                // Fetch the existing book by ID and gather the updated book details from the user
                var existingBook = bookServiceBridge.ListBooks().FirstOrDefault(b => b.Id == bookId);
                if (existingBook != null)
                {
                    Console.Write("New Title: ");
                    string title = Console.ReadLine();
                    Console.Write("New Author: ");
                    string author = Console.ReadLine();
                    Console.Write("New ISBN: ");
                    string isbn = Console.ReadLine();
                    Console.Write("New Price: ");

                    if (decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        Console.Write("New Quantity: ");

                        if (int.TryParse(Console.ReadLine(), out int quantity))
                        {
                            Book updatedBook = new Book
                            {
                                Id = existingBook.Id,
                                Title = title,
                                Author = author,
                                ISBN = isbn,
                                Price = price,
                                Quantity = quantity,
                            };

                            bookServiceBridge.EditBook(bookId, updatedBook);
                            Console.WriteLine("Book edited successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity. Please enter a valid number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid price. Please enter a valid number.");
                    }
                }
                else
                {
                    Console.WriteLine("Book with ID not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid book ID. Please enter a valid number.");
            }
        }
    }
}
