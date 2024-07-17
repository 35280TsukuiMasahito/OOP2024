using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
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
                .FirstOrDefault();
            var xname = max.Element("name").Value;
            var xteammembers = max.Element("teammembers").Value;
            Console.WriteLine($"メンバー人数が最も多い競技: {xname}, 人数: {xteammembers}");
        }

        private static void Exercise1_4(string file, string newfile) {

        }
    }
}
