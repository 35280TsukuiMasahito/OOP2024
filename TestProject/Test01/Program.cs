using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Test01 {
    class Program {
        static void Main(string[] args) {
            var score = new ScoreCounter("StudentScore.csv");
            var TotalBySubject = score.GetPerStudentScore();
            foreach (var obj in TotalBySubject) {
                Console.WriteLine("{0} {1}", obj.Key, obj.Value);
            }
        }
    }
}
