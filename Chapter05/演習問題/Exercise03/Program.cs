using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
        }

        private static void Exercise3_1(string text) {
            int count = text.Count(c=>c==' ');
            Console.WriteLine("空白:"+count);
        }

        private static void Exercise3_2(string text) {
            String str = text.Replace("big", "small");
            Console.WriteLine(str);
        }

        private static void Exercise3_3(string text) {
            int cnt = text.Split(' ').Length;
            Console.WriteLine(cnt);
        }

        private static void Exercise3_4(string text) {
            String[] word = text.Split(' ');
            foreach(var w in word) {
                if(w.Length<=4)Console.WriteLine(w);
            }
        }

        private static void Exercise3_5(string text) {
            String[] word = text.Split(' ');
            StringBuilder sb = new StringBuilder();
            foreach(var w in word) {
                sb.Append(w+" ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
