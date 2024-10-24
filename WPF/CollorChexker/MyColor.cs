using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CollorChexker {
    public class MyColor {
        public Color Color { get; set; }
        public string Name { get; set; } = string.Empty;
        public override string ToString() {
            return !string.IsNullOrEmpty(Name) ? Name : string.Format("R: {0}, G: {1}, B: {2}", Color.R, Color.G, Color.B);
        }
    }
}
