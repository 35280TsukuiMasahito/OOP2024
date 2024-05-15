using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };

            //int count = numbers.Count(n => n % 2 == 0);
            double avg = numbers.Where(n=>n>5).Average();
            int num = numbers.Where(n=>n>5).Sum();
            Console.WriteLine(num);
            Console.WriteLine(avg);
        }
    }
}
