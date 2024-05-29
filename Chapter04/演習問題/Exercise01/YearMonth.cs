using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public class YearMonth {
        //4.1.1
        public int year {  get; private set; }
        public int month {  get; private set; }

        //コンストラクタ
        public YearMonth(int year,int month) {
            this.year = year;
            this.month = month;
        }
        
        public bool Is21Century {
            get {
                return (this.year >= 2001) && (this.year <= 2100);
            }
        }
        public YearMonth AddOneMonth() {
            if(month==12) {
                return new YearMonth(year+1,1);
            } else {
                return new YearMonth(year,month +1);
            }
            
        }
        public override string ToString() {
            return year + "年" + month + "月";
        }
    }
}
