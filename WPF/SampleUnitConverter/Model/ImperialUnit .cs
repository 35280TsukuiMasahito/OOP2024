using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    //ヤード単位を表すクラス
    public class ImperialUnit : DistanceUnit {
        private static List<ImperialUnit> units = new List<ImperialUnit> {
            new ImperialUnit { Name = "in", Coefficent = 1, },
            new ImperialUnit { Name = "ft", Coefficent = 12, },
            new ImperialUnit { Name = "yd", Coefficent = 12 * 3, },
            new ImperialUnit { Name = "ml", Coefficent = 12 * 3 * 1760, },
        };
        public static ICollection<ImperialUnit> Units { get { return units; } }

        /// <summary>
        /// ヤード単位からメートル単位に変換
        /// </summary>
        /// <param name="unit">ヤード単位</param>
        /// <param name="value">値</param>
        /// <returns></returns>
        public double FromMetricUnit(MetricUnit unit,double value) {
            return (value * unit.Coefficent) / 25.4/this.Coefficent;
        }

    }
}
