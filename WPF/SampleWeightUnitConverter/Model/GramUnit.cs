using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    //ヤード単位を表すクラス
    public class GramUnit : WeightUnit {
        private static List<GramUnit> units = new List<GramUnit> {
            new GramUnit { Name = "g", Coefficent = 1, },
            new GramUnit { Name = "kg", Coefficent = 1000, },
        };
        public static ICollection<GramUnit> Units { get { return units; } }

        /// <summary>
        /// ヤード単位からメートル単位に変換
        /// </summary>
        /// <param name="unit">ヤード単位</param>
        /// <param name="value">値</param>
        /// <returns></returns>
        public double FromPoundUnit(PoundUnit unit, double value) {
            return (value * unit.Coefficent) * 28.34952 / this.Coefficent;
        }

    }
}