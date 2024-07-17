using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Novelist {
        public string name {  get; set; }
        public string kanaName { get; set; }
        public DateTime Birth {  get; set; }
        public DateTime Death { get; set;}
        public string Description { get; set; }
        public List<string> Masterpieces { get; set; }
    }
}
