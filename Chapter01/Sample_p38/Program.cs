using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_p38 {
    internal class Program {
        static void Main(string[] args) {
            Employee employee = new Employee {
                ID = 100,
                Name = "山田太郎",
                Birthday = new DateTime(1992, 4, 5),
                DivisionName = "第一営業所",
            };
            Console.WriteLine("{0}({1})は、{2}に属しています。",
                employee.Name, employee.GetAge(), employee.DivisionName);

            Student student = new Student("佐藤広", 5, 2) {};
            Console.WriteLine("{0}{1}年{2}組",
                student.Name,student.Grade,student.ClassNumber);

            Person person = student;
            if (person is Student)
                Console.WriteLine("persom is Student");

            object obj = student;
            if (obj is Student)
                Console.WriteLine("obj is Student");
                
        }
    }
}
