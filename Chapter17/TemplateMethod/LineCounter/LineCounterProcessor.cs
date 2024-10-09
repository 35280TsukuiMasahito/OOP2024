using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
     class LineCounterProcessor : TextProcessor{
        private int _count;
        string _text = "";

        protected override void Initialize(string fname) {
            _text += fname;
            _count = 0;
        }
        protected override void Execute(string line) {
            _count++;
        }
        protected override void Terminate() {
            Console.WriteLine("{0}",_count);
            Console.WriteLine(_text);
        }
    }
}
