using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_03_Rafael.Library
{
    class BookCase
    {
        public Book[] Books { get; set; }
        public BookCase()
        {
            Books = new Book[5];
        }
    }
}
