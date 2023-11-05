using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBook.Domain
{
    public class SortByPriceStrategy : IBookSortStrategy
    {
        public List<Book> SortBooks(List<Book> books)
        {
            return books.OrderBy(b => b.Price).ToList();
        }
    }
}
