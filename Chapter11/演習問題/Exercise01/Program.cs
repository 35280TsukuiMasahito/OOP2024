using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //メンバー人数が最も多い競技を出力
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
            AddSoccer(xdoc);

            Console.WriteLine();
            AddSportFromInput(xdoc);
        }
        public static void AddSoccer(XDocument xdoc) {
            var soccer = new XElement("ballsport",
                new XElement("name","サッカー", new XAttribute("kanji", "蹴球")),
                new XElement("teammembers", "11"),
                new XElement("firstplayed", "1863")
            );

            xdoc.Root.Add(soccer);

            // 確認用のコード
            foreach (var x in xdoc.Root.Elements("ballsport")) {
                var xname = x.Element("name").Value;
                var xint = x.Element("teammembers").Value;
                Console.WriteLine($"競技名: {xname}, 人数: {xint}");
            }
            xdoc.Save("Ballsports.xml");
        }
        public static void AddSportFromInput(XDocument xdoc) {
            Console.Write("競技名（漢字）を入力してください: ");
            var kanjiName = Console.ReadLine();
            Console.Write("競技名（カタカナ）を入力してください: ");
            var katakanaName = Console.ReadLine();
            Console.Write("チームメンバー数を入力してください: ");
            var teamMembers = Console.ReadLine();
            Console.Write("初めてプレイされた年を入力してください: ");
            var firstPlayed = Console.ReadLine();

            var sport = new XElement("ballsport",
                new XElement("name", katakanaName, new XAttribute("kanji", kanjiName)),
                new XElement("teammembers", teamMembers),
                new XElement("firstplayed", firstPlayed)
            );

            xdoc.Root.Add(sport);

            // 確認用のコード

                var xname = sport.Element("name").Value;
                var xint = sport.Element("teammembers").Value;
                Console.WriteLine($"競技名: {xname}, 人数: {xint}");
            

            // 追加したスポーツ情報を保存
            xdoc.Save("updated_sample.xml");
        }
    }
}