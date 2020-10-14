using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_03_Rafael.Library
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string NumOfPages { get; set; }

        private int score;

        public int Score
        {
            get { return score; }
            set
            {
                if (value < 0) score = 0;
                else if (value > 10) score = 10;
                else score = value;
            }
        }

        public Book(string title, string author, int score, string numerOfPages)
        {
            Title = title;
            Author = author;
            Score = score;
            NumOfPages = numerOfPages;
        }

        public override string ToString()
        {
            return string.Format("Titulo: {0}\nAutor: "
                +"{1}\nNúmero de páginas: {2}\nCalificación: {3}", Title, Author, NumOfPages, Score);
        }
    }
}
