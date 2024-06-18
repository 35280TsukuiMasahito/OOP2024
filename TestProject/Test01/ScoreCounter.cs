using System.Collections.Generic;
using System.IO;

namespace Test01 {
    class ScoreCounter {
        public IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }


        //メソッドの概要： 
        public static IEnumerable<Student> ReadScore(string filePath) {
            List<Student> students = new List<Student>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines) {
                string[] items = line.Split(',');
                Student student = new Student {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2]),
                };
                students.Add(student);
            }
            return students;
        }





        //メソッドの概要： 
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach(var s in _score) { 
                if (dict.ContainsKey(s.Subject)) {
                    dict[s.Subject] += s.Score;
                } else {
                    dict[s.Subject] = s.Score;
                }
            }
            return dict;

        }
    }
}
