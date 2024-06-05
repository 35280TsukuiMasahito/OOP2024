using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var sortBooks = Books.GetBooks().OrderByDescending(x => x.Price).ToList();
            sortBooks.ForEach(x => Console.WriteLine(x.Title + "  " + x.Price));
        }
    }
}
