using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

#if false

            var novel = new Novel {
                Author = "ジェイムズ・P・ホーガン",
                Title = "星を継ぐもの",
                Published = 1977,
            };

            var settings = new XmlWriterSettings {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                IndentChars = " ",
            };

            using(var writer = XmlWriter.Create("Novel.xml",settings)) {
                var serializer = new DataContractSerializer(novel.GetType());
                serializer.WriteObject(writer, novel);
            }

#else
            using (var reader = XmlReader.Create("novel.xml")) {
                var serializer = new DataContractSerializer(typeof(Novel));
                var novel =serializer.ReadObject(reader) as Novel;
                Console.WriteLine(novel);
            }
#endif 

        }
    }
}
