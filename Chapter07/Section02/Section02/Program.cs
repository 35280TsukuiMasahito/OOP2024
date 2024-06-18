using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    internal class Program {
        static void Main(string[] args) {
            var dict = new Dictionary<MonthDay, string> {
                { new MonthDay(3, 5), "珊瑚の日" },
                { new MonthDay(8, 4), "箸の日" },
                { new MonthDay(10, 3), "登山の日" },
           };
            var md = new MonthDay(8, 4);
            var s = dict[md];
            Console.WriteLine(s);
        }


        }
    }
