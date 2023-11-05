using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBook.Domain
{
    public interface IBookAddedObserver
    {
        void BookAdded(Book book);
    }
}
