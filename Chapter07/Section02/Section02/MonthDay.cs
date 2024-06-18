using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    internal class MonthDay {
        public int Day { get; private set; }
        public int Month { get; private set; }

        public MonthDay(int month, int day) {
            this.Month = month;
            this.Day = day;
        }

        //MonthDayｄ同士の比較をする
        public override bool Equals(object obj) {
            var other = obj as MonthDay;
            if (other == null) {
                throw new ArgumentException();
            }
            return this.Month == other.Month && this.Day == other.Day;
        }

        //ハッシュコードを求める
        public override int GetHashCode() {
            return Month.GetHashCode() * 31 + Day.GetHashCode();
        }
    }
}
