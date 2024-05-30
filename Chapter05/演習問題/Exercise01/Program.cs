using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("文字を入力");
            String s1 = Console.ReadLine();
            String s2 = Console.ReadLine();

            if (String.Compare(s1, s2, true) == 0) {
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }
        }
    }
}
