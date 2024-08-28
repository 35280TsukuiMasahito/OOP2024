using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_1("employee.xml");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employee.xml"));
            Console.WriteLine();

            Exercise1_2("employees.xml");
            Exercise1_3("employees.xml");
            Console.WriteLine();

            Exercise1_4("employees.json");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employees.json"));
        }
        private static void Exercise1_1(string v) {
            var employee = new Employee {
                Id = 810,
                Name = "タチキンTV",
                HireDate = new DateTime(2023, 8, 27)
            };

            var settings = new XmlWriterSettings {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                IndentChars = " ",
            };

            using (var writer = XmlWriter.Create("employee.xml")) {
                var serializer = new DataContractSerializer(typeof(Employee));
                serializer.WriteObject(writer, employee);
            }

            using (var reader = XmlReader.Create("employee.xml")) {
                var serializer = new DataContractSerializer(typeof(Employee));
                var novel = serializer.ReadObject(reader) as Employee;
            }
        }

        private static void Exercise1_2(string filePath) {
            var employees = new Employee[]
            {
                new Employee { Id = 1, Name = "大野卓也", HireDate = new DateTime(2023, 1, 15) },
                new Employee { Id = 2, Name = "大森不運", HireDate = new DateTime(2023, 3, 22) },
                new Employee { Id = 3, Name = "岡島楓花", HireDate = new DateTime(2023, 5, 30) }
            };

            // 配列をXMLファイルにシリアル化
            using (var writer = XmlWriter.Create(filePath)) {
                var serializer = new DataContractSerializer(typeof(Employee[]));
                serializer.WriteObject(writer, employees);
            }


        }

        private static void Exercise1_3(string filePath) {

            // XMLファイルから配列をデシリアル化
            using (var reader = XmlReader.Create(filePath)) {
                var serializer = new DataContractSerializer(typeof(Employee[]));
                var deserializedEmployees = (Employee[])serializer.ReadObject(reader);

                foreach (var employee in deserializedEmployees) {
                    Console.WriteLine($"Id: {employee.Id}");
                    Console.WriteLine($"Name: {employee.Name}");
                    Console.WriteLine($"HireDate: {employee.HireDate}");
                    Console.WriteLine();
                }
            }
        }

        private static void Exercise1_4(string v) {
            var employees = new Employee[]
   {
        new Employee { Id = 1, Name = "沢村勇気", HireDate = new DateTime(2023, 1, 15) },
        new Employee { Id = 2, Name = "重野重蔵", HireDate = new DateTime(2023, 3, 22) },
        new Employee { Id = 3, Name = "館内綾香", HireDate = new DateTime(2023, 5, 30) }
   };

            using (var stream = new FileStream("employees.json", FileMode.Create, FileAccess.Write)) {
                var serializer = new DataContractJsonSerializer(employees.GetType());
                serializer.WriteObject(stream, employees);
            }

            var options = new JsonSerializerOptions {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };

            string jsonString = JsonSerializer.Serialize(employees, options);
            Console.WriteLine(jsonString);
        }
    }
}
