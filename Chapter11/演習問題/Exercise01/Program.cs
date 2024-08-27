using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);
        }

        public static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            var xelements = xdoc.Root.Elements("ballsport");

            foreach (var x in xelements) {
                var xname = x.Element("name").Attribute("kanji").Value;
                var xint = x.Element("teammembers").Value;
                Console.WriteLine($"競技名: {xname}, 人数: {xint}");
            }
        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var xelements = xdoc.Root.Elements("ballsport")
                .OrderBy(x => (int)x.Element("firstplayed"))
                .ToList();

            foreach (var x in xelements) {
                var xname = x.Element("name").Attribute("kanji").Value;
                var xfirstplayed = x.Element("firstplayed").Value;
                Console.WriteLine($"競技名: {xname}, 初めてプレイされた年: {xfirstplayed}");
            }
        }

        private static void Exercise1_3(string file) {
            // メンバー人数が最も多い競技を出力
            var xdoc = XDocument.Load(file);
            var xelements = xdoc.Root.Elements("ballsport");

            var max = xelements
                .OrderByDescending(x => (int)x.Element("teammembers"))
                .First();
            var xname = max.Element("name").Value;
            var xteammembers = max.Element("teammembers").Value;
            Console.WriteLine($"メンバー人数が最も多い競技: {xname}, 人数: {xteammembers}");
        }

        private static void Exercise1_4(string file, string newfile) {
            var xdoc = XDocument.Load(file);
            AddSoccer(xdoc, newfile);

            Console.WriteLine();
            AddSportFromInput(file, newfile);
            xdoc.Save(newfile);
        }

        public static void AddSoccer(XDocument xdoc, string newfile) {
            var soccer = new XElement("ballsport",
                new XElement("name", "サッカー", new XAttribute("kanji", "蹴球")),
                new XElement("teammembers", "11"),
                new XElement("firstplayed", "1863")
            );
            foreach (var x in xdoc.Root.Elements("ballsport")) {
                var xname = x.Element("name").Value;
                var xint = x.Element("teammembers").Value;
                Console.WriteLine($"競技名: {xname}, 人数: {xint}");
            }
            xdoc.Save(newfile);
        }

        public static void AddSportFromInput(String file, string newfile) {
            List<XElement> xElements = new List<XElement>();

            var xdoc = XDocument.Load(file);
            string name, kanji, teammembers, firstplayed;
            int nextFlag;
            while (true) {
                //入力処理
                Console.Write("名称："); name = Console.ReadLine();
                Console.Write("漢字："); kanji = Console.ReadLine();
                Console.Write("人数："); teammembers = Console.ReadLine();
                Console.Write("起源："); firstplayed = Console.ReadLine();
                //1件分の要素作成
                var element = new XElement("ballsport",
                     new XElement("name", name, new XAttribute("kanji", kanji)),
                     new XElement("teammembers", teammembers),
                     new XElement("firstplayed", firstplayed)
                );
                xElements.Add(element); //リストへ要素を追加

                Console.WriteLine();    //改行
                Console.Write("追加【1】保存【２】");
                Console.Write(">");
                nextFlag = int.Parse(Console.ReadLine());
                if (nextFlag == 2) break;  //無限ループを抜ける
                Console.WriteLine();    //改行
            }
            xdoc.Root.Add(xElements);
            xdoc.Save(newfile); //保存
        }
    }
}
