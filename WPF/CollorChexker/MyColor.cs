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
            // 名前が設定されている場合はその名前を返す
            if (!string.IsNullOrEmpty(Name)) {
                return Name;
            }
            // 名前が設定されていない場合は RGB 値を文字列として返す
            return $"R: {Color.R}, G: {Color.G}, B: {Color.B}";
        }
    }
}