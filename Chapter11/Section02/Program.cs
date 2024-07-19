using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section02 {
    internal class Program {
        static void Main(string[] args) {
            AddElement();
        }

        public static void AddElement() {
            var element = new XElement("novelist",
                new XElement("name", "菊池 寛", new XAttribute("kana", "きくち かん")),
                new XElement("birth", "1888-12-26"),
                new XElement("death", "1948-03-06"),
                new XElement("masterpieces",
                  new XElement("title", "恩讐の彼方に"),
                  new XElement("title", "真珠夫人")
                )
              );
            var xdoc = XDocument.Load("novelists.xml");
            xdoc.Root.Add(element);

            // これ以降は確認用のコード 
            foreach (var xnovelist in xdoc.Root.Elements()) {
                var xname = xnovelist.Element("name");
                var birth = (DateTime)xnovelist.Element("birth");
                Console.WriteLine("{0} {1}", xname.Value, birth.ToShortDateString());
            }

            xdoc.Save("newXmlFile.xml");
        }
    }
}
