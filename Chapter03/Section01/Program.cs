using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var list = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            IEnumerable<string> quary = list.Where(s => s.Contains(' ')).Select(s => s.ToUpper());
                                       

            foreach (String s in quary)
               Console.WriteLine(s);
        }
    }
}
