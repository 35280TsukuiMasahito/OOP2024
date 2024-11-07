using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    public class MetricUnit : DistanceUnit {
        private static List<MetricUnit> units = new List<MetricUnit> {
            new MetricUnit { Name = "mm", Coefficent = 1, },
            new MetricUnit { Name = "cm", Coefficent = 10, },
            new MetricUnit { Name = "m", Coefficent = 10 * 100, },
            new MetricUnit { Name = "km", Coefficent = 10 * 100 * 1000, },
        };
        public static ICollection<MetricUnit> Units { get { return units; } }

        /// <summary>
        /// ヤード単位からメートル単位に変換
        /// </summary>
        /// <param name="unit">ヤード単位</param>
        /// <param name="value">値</param>
        /// <returns></returns>
        public double FromImperialUnit(ImperialUnit unit,double value) {
            return (value * unit.Coefficent) * 25.4/this.Coefficent;
        }
    }
}
