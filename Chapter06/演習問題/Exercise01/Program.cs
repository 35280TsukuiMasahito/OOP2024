using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);
        }

        private static void Exercise1_1(int[] numbers) {
            int max = numbers.Max();
            Console.WriteLine(max);
        }

        private static void Exercise1_2(int[] numbers) {
            var lasttwo = numbers.Skip(numbers.Length - 2).ToList();
            lasttwo.ForEach(x => Console.WriteLine(x));
        }

        private static void Exercise1_3(int[] numbers) {
            foreach (var x in numbers) {
                String str = x.ToString();
                Console.WriteLine(str);
            }

        }

        private static void Exercise1_4(int[] numbers) {
            var sortnum = numbers.OrderBy(x => x).ToList();
            var numlist = sortnum.Take(3).ToList();
            numlist.ForEach(x => Console.WriteLine(x.ToString()));
        }

        private static void Exercise1_5(int[] numbers) {
            var result = numbers.Distinct().ToList();
            var count = result.Where(x => x > 10).Count();
            Console.WriteLine(count);
        }
    }
}
