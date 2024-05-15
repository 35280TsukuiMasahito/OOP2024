using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            var quary = names.Where(s => s.Length <= 5).ToList();
            foreach (var item in quary) {
                Console.WriteLine(item);
            }
           
            Console.WriteLine("------------");

            names[0] = "Osaka";
            foreach (var item in quary) {
                Console.WriteLine(item);
            }
        }
    }
}
