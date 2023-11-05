using OnlineBook.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBook.Factory
{
    public class BookFlyweightFactory
    {
        private Dictionary<string, IBookFlyweight> flyweights = new Dictionary<string, IBookFlyweight>();

        public IBookFlyweight GetBookFlyweight(string title, string author, string isbn)
        {
            string key = $"{title}-{author}-{isbn}";
            if (!flyweights.ContainsKey(key))
            {
                flyweights[key] = new BookFlyweight(title, author, isbn);
            }
            return flyweights[key];
        }
    }
}
