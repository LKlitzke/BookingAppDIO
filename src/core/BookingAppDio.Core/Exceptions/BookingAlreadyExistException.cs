using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAppDio.Core.Exceptions
{
    public class BookingAlreadyExistException : Exception
    {
        public BookingAlreadyExistException(int? code = default)
        {
        }
    }
}
