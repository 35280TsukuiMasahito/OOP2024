using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_p38 {
    public class Student:Person {
        public int Grade { get; set; }
        public int ClassNumber { get; set; }

        public Student(String Name, int Grade, int ClassNumber) {
            this.Name = Name;
            this.Grade = Grade;
            this.ClassNumber = ClassNumber;
        }

    }
}
