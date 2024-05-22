using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var names = new List<string> {
     "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
};
           // Exercise2_1(names);
            Console.WriteLine();
            Exercise2_2(names);
            Console.WriteLine();
            Exercise2_3(names);
            Console.WriteLine();
            Exercise2_4(names);
        }

        private static void Exercise2_1(List<string> names) {
            Console.Write("都市を入力:");
            do {
                String city = Console.ReadLine();
                if (string.IsNullOrEmpty(city)) {
                    break;
                }
                int index = names.FindIndex(x => x == city);
                Console.WriteLine(index + "番目");
                Console.Write("都市を入力:");
            } while (true);
        }

        private static void Exercise2_2(List<string> names) {
            var key = "o";
            int cnt = names.Count(n=>n.Contains(key));
              Console.WriteLine(cnt + "個");
        }

        private static void Exercise2_3(List<string> names) {
            var key = "o";
            var name = names.Where(n => n.Contains(key)).ToArray();
            foreach( var n in name) Console.WriteLine(n);
        }

        private static void Exercise2_4(List<string> names) {
            var name = names.Where(n => n[0] == 'B').Select(n=>new { n.Length, n });
            foreach (var obj in name) Console.WriteLine(obj.n + "," +obj.Length);
        }
    }
}
