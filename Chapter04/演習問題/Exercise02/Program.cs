using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            // 4.2.1
            var ymCollection = new YearMonth[] {
            new YearMonth(1980, 1),
            new YearMonth(1990, 4),
            new YearMonth(2000, 7),
            new YearMonth(2010, 9),
            new YearMonth(2020, 12),
            };

            // 4.2.2
            Console.WriteLine("\n- 4.2.2 ---");
            Exercise2_2(ymCollection);


            Console.WriteLine("\n- 4.2.4 ---");

            // 4.2.4
            Exercise2_4(ymCollection);
            Console.WriteLine("\n- 4.2.5 ---");


            // 4.2.5
            Exercise2_5(ymCollection);
        }

        private static void Exercise2_2(YearMonth[] ymCollection) {
            foreach(var y in ymCollection) { 
                Console.WriteLine(y.year+","+y.month);
            }
        }

        private static YearMonth FindFirst21C(YearMonth[] ymCollection) {
            foreach (var y in ymCollection) {
                if (y.Is21Century) {
                    return y;
                } 
            }
            return null;
        }

        private static void Exercise2_4(YearMonth[] ymCollection) {
            YearMonth y = FindFirst21C (ymCollection);
            if (y == null) {
                Console.WriteLine("21世紀のデータはありません");
            } else {
                Console.WriteLine(y);
            }

            
        }

        private static void Exercise2_5(YearMonth[] ymCollection) {
            var array = ymCollection.Select(y => y.AddOneMonth()).ToArray();
            foreach (var y in array) {
                Console.WriteLine(y);
            }
           
        }
    }
}
