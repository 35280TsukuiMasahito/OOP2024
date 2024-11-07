using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;
using TextNumberSizeChange.Framework;

namespace TextNumberSizeChange {
     class ToHankakuProcessor : ITextFileService{
        Dictionary<char, char> conv = new Dictionary<char, char>() { 
            {'０','0'},{'１','1'},{'２','2'},{'３','3'},{'４','4'},
            {'５','5'},{'６','6'},{'７','7'},{'８','8'},{'９','9'},
        };
        private int _count;
        public void Initialize(string fname) {
            _count = 0;
        }

        public void Execute(string line) {
            _count++;
        }

        public void Terminate() {
            Console.WriteLine("{0}行", _count);
        }

        //string _text = "";

        //protected override void Initialize(string fname) {
        //    _text += fname;
        //    _count = 0;
        //}
        //protected override void Execute(string line) {
        //    string numbs = new string
        //        (line.Select(n => conv.ContainsKey(n) ? conv[n]:n).ToArray());
        //    Console.WriteLine(numbs);
        //}
        //protected override void Terminate() {
        //    Console.WriteLine("{0}",_count);
        //    Console.WriteLine(_text);
    }
    
}
