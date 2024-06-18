using System;
using System.Collections.Generic;
using System.Linq;

namespace Test02 {
    
    class Person {
        public string Name { get; set; }  //名前
        public int Age { get; set; }      //年齢
        public int Height { get; set; }   //身長
        public int Weight { get; set; }   //体重
    }

    class Program {
        static void Main(string[] args) {
            var numbers = new List<int> {
                    12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48
                };

            var persons = new List<Person> {
                new Person{Name = "山田隆司",Age = 38, Height=170,Weight=68},
                new Person{Name = "沖田宏一",Age = 28, Height=168,Weight=59},
                new Person{Name = "池中裕次",Age = 21, Height=184,Weight=82},
                new Person{Name = "片桐鉄也",Age = 29, Height=173,Weight=74},
                new Person{Name = "片山伸介",Age = 35, Height=176,Weight=65},
            };
            #region テスト用ドライバ
            Console.WriteLine("問題１：合計値");
            Exercise01(numbers);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題２：偶数の最大値");
            Exercise02(numbers);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題３：奇数の降順");
            Exercise03(numbers);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題４：10 以上 50 以下のみ");
            Exercise04(numbers);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題５：平均年齢");
            Exercise05(persons);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題６：身長170cm以上の体重平均");
            Exercise06(persons);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題７：体重70kg以下の人を体重の昇順で全て表示（名前と体重を出力）");
            Exercise07(persons);
            Console.WriteLine("\n-----");
            
            Console.WriteLine("問題８：名前に「山」の漢字が含まれている人全て表示（名前のみ出力）");
            Exercise08(persons);
            Console.WriteLine("\n-----");
            #endregion
        }

        //---------------------------------------
        // 以下の問題に書かれている内容を満たすようにプログラムを作成せよ。
        // 必要であればラムダ式とLINQを使用すること
        //---------------------------------------

        //問題１　合計値を表示
        //　　　　出力結果【618】
        private static void Exercise01(List<int> numbers) {



        }

        //問題２　偶数の最大値を表示
        //　　　　出力結果【94】
        private static void Exercise02(List<int> numbers) {



        }
        //問題３　奇数のみを降順に並べて表示（遅延実行とする）
        //　　　　出力結果【91 87 53 35 31 17】
        private static void Exercise03(List<int> numbers) {



        }

        //問題４　10以上50以下の数字のみを表示（即時実行でも可とする）
        //　　　　出力結果【12 14 20 40 35 31 17 48】
        private static void Exercise04(List<int> numbers) {



        }

        //問題５　平均年齢を表示
        //　　　　出力結果【30.2才】
        private static void Exercise05(List<Person> persons) {
            


        }

        //問題６　身長170cm以上の体重平均を表示
        //　　　　出力結果【72.25kg】
        private static void Exercise06(List<Person> persons) {



        }

        //問題７　体重70Kg以下の人を全て表示（名前と体重）
        //　　　　出力結果【山田隆司 68kg
        //　　　　　　　　　沖田宏一 59kg
        //　　　　　　　　　片山伸介 65kg】
        private static void Exercise07(List<Person> persons) {
        
        
        
        }

        //問題８　名前に「山」の漢字が含まれている人全て表示
        //　　　　出力結果【山田隆司
        //　　　　　　　　　片山伸介】
        private static void Exercise08(List<Person> persons) {



        }
    }
}
