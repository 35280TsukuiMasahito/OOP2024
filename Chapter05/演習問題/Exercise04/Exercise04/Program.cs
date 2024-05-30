using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var list = "Novelist=谷崎潤一郎;BestWork=春琴砂;Born=1886";

            string str = list.Replace("Novelist=", "作家:").Replace("BestWork=", "代表作:").Replace("Born=", "誕生日:");
            String[] words = str.Split(';');
            foreach (string word in words) {
                Console.WriteLine(word);
            }
        }
    }
}
