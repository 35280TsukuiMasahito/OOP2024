using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var max = Library.Books.Max(x=>x.Price);
            Console.WriteLine(max);
        }

        private static void Exercise1_3() { 
            var quary = Library.Books
                .GroupBy(b=>b.PublishedYear)
                .Select(x=>new {Publisher =})
        }

        private static void Exercise1_4() {
            throw new NotImplementedException();
        }

        private static void Exercise1_5() {
            throw new NotImplementedException();
        }

        private static void Exercise1_6() {
            throw new NotImplementedException();
        }

        private static void Exercise1_7() {
            throw new NotImplementedException();
        }

        private static void Exercise1_8() {
            throw new NotImplementedException();
        }
    }
}
