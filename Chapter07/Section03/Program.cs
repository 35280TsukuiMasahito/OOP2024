using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {
    internal class Program {
        static void Main(string[] args) {
            // ディクショナリの初期化
            var dict = new Dictionary<string, List<string>>() {
             { "PC", new List<string> { "パーソナル コンピュータ", "プログラム カウンタ", } },
             { "CD", new List<string> { "コンパクト ディスク", "キャッシュ ディスペンサー", } },
            };

            // ディクショナリに追加
            var key = "EC";
            var value = "電子商取引";
            if (dict.ContainsKey(key)) {
                dict[key].Add(value);
            } else {
                dict[key] = new List<string> { value };
            }

            // ディクショナリの内容を列挙
            foreach (var item in dict) {
                foreach (var term in item.Value) {
                    Console.WriteLine("{0} : {1}", item.Key, term);
                }
            }
        }
    }
}
