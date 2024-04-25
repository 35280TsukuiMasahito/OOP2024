using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    public class InchConverter {

        public static readonly double ratio = 0.0254;    //定数(外部にも公開する場合)

        //メートルからフィートを求める
        public static double FromMeter(double meter) {
            return meter / ratio;
        }
        //フィートからメートルを求める
        public static double ToMeter(double inch) {
            return inch * ratio;
        }
    }
}
