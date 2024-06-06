using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {

        static void Main(string[] args) {

            var kenchodict = new Dictionary<String, String>();
            for (int i = 0; i < 5; i++) {
                Console.Write("都道府県:");
                var Key = Console.ReadLine();
                Console.Write("県庁所在地:");
                var Value = Console.ReadLine();
                kenchodict.Add(Key, Value);
            }

            //foreach (var n in kenchodict) {
            //    Console.WriteLine(n.Key + "の県庁所在地は" + n.Value + "です");
            //}

            String getnum;
            int num;

            do {
                Console.WriteLine("*メニュー*");
                Console.WriteLine("1:一覧表示");
                Console.WriteLine("2:検索");
                Console.WriteLine("9:終了");
                Console.Write("数値を入力:");
                getnum = Console.ReadLine();
                num = int.Parse(getnum);
                if (num == 1) {
                    foreach (var n in kenchodict) {
                        Console.WriteLine(n.Key + "の県庁所在地は" + n.Value + "です");
                    }
                } else if (num == 2) {
                    Console.Write("検索する都道府県:");
                    String s = Console.ReadLine();
                    if (kenchodict.ContainsKey(s)) {
                        foreach (var n in kenchodict) {
                            if (n.Key == s) {
                                Console.WriteLine(n.Key + "の県庁所在地は" + n.Value + "です");
                            }
                        }
                    } else {
                        Console.WriteLine("見つかりません");
                    }

                }
            } while (num != 9);
                Console.WriteLine("処理を終了します");
                return;
            }


                //var employeeDict = new Dictionary<int, Employee> {
                //   { 100, new Employee(100, "清水遼久") },
                //   { 112, new Employee(112, "芹沢洋和") },
                //   { 125, new Employee(125, "岩瀬奈央子") },
                //};

                //var flowerDict = new Dictionary<string, int>() {
                //      { "sunflower", 400 },
                //      { "pansy", 300 },
                //      { "tulip", 350 },
                //      { "rose", 500 },
                //      { "dahlia", 450 },
                //};
                ////Console.WriteLine(flowerDict["sunflower"]);
                ////Console.WriteLine(flowerDict["dahlia"]);

                //employeeDict.Add(126, new Employee(126, "茂木愼")); //追加

                //var name = employeeDict.Where(e => e.Value.Name.Contains("和"));

                //foreach(var item  in employeeDict.Values) {
                //    Console.WriteLine($"{item.Id} {item.Name}");
                //}

                //var emp0 = employeeDict[100];
                //Console.WriteLine($"{emp0.Id} {emp0.Name}"); //取り出し
                //var emp1 = employeeDict[112];
                //Console.WriteLine($"{emp1.Id} {emp1.Name}");
                //var emp2 = employeeDict[125];
                //Console.WriteLine($"{emp2.Id} {emp2.Name}");
                //var emp3 = employeeDict[125];
                //Console.WriteLine($"{emp3.Id} {emp3.Name}");

                //var result = employeeDict.Remove(126); //消去

          
    }
}
