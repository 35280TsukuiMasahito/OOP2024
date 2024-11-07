using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    public class WeightUnit {
        public string Name { get; set; }
        public double Coefficent { get; set; }
        public override string ToString() {
            return this.Name;
        }
    }
}
