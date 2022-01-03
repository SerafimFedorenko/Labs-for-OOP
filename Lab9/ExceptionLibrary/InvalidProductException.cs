using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLibrary
{
    [Serializable]
    public class InvalidProductException : Exception
    {
        public double Price;
        public InvalidProductException(string message)
            : base(message) { }

        public InvalidProductException(string message, double price)
            : base(message) 
        {
            Price = price;
        }
    }
}
