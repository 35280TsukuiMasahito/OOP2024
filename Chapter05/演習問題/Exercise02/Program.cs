using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("数値を入力");
            String inputNum = Console.ReadLine();

            int num;
            if (int.TryParse(inputNum, out num)) {
                Console.WriteLine($"{num:#,#}");
            } else {
                Console.WriteLine("数字文字列ではない");
            }

            //if (int.TryParse(inputNum, out int num)) {
            //    String format = num.ToString("N0");
            //    Console.WriteLine(format);
            //}

        }
    }
}
