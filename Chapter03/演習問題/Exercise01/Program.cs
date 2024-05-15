using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            // 3.1.1
            Exercise1_1(numbers);
            Console.WriteLine("-----");
            // 3.1.2
            Exercise1_2(numbers);
            Console.WriteLine("-----");
            // 3.1.3
            Exercise1_3(numbers);
            Console.WriteLine("-----");

            // 3.1.4
            Exercise1_4(numbers);

        }


        public static void Exercise1_1(List<int> numbers) {
            var exists = numbers.Exists(s => s % 8 == 0 || s % 9 == 0);
            Console.WriteLine(exists);
        }


        private static void Exercise1_2(List<int> numbers) {
            numbers.ForEach(s => Console.Write(s/2+""));
            Console.WriteLine("");
        }

        private static void Exercise1_3(List<int> numbers) {
            var number = numbers.Where(n => n > 49);
            foreach(var n in number) Console.Write(n+",");
            Console.WriteLine("");
        }

        private static void Exercise1_4(List<int> numbers) {
            var list = numbers.Select(n => n * 2).ToList();
            foreach (var n in list) Console.Write(n+",");
        }
    }
}
