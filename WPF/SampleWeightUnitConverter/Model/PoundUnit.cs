using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    public class PoundUnit : WeightUnit {
        private static List<PoundUnit> units = new List<PoundUnit> {
            new PoundUnit { Name = "oz", Coefficent = 1, },
            new PoundUnit { Name = "lb", Coefficent = 16, },
            new PoundUnit { Name = "stone", Coefficent = 224, },
        };
        public static ICollection<PoundUnit> Units { get { return units; } }

        /// <summary>
        /// ヤード単位からメートル単位に変換
        /// </summary>
        /// <param name="unit">ヤード単位</param>
        /// <param name="value">値</param>
        /// <returns></returns>
        public double FromGramUnit(GramUnit unit, double value) {
            return (value * unit.Coefficent) / 28.34952 / this.Coefficent;
        }
    }
}
