using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            var today = DateTime.Now;
            tbDisp.Text = today.ToString() + "\r\n";
            tbDisp.Text += today.ToString("yyyy”NMMŒdd“ú HHmm•ªss•b") + "\r\n";

            CultureInfo Japanese = new CultureInfo("ja-JP");
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            string wareki_date = today.ToString("ggyy”NMŒd“ú(dddd)", Japanese);
            tbDisp.Text += wareki_date;
        }

        private void btEx8_2_Click(object sender, EventArgs e) {

            var datetime = DateTime.Today;
            var dayOfWeekJapanese = new Dictionary<DayOfWeek, string> {
                { DayOfWeek.Sunday,   "“ú—j“ú" },
                { DayOfWeek.Monday,   "Œ—j“ú" },
                { DayOfWeek.Tuesday,  "‰Î—j“ú" },
                { DayOfWeek.Wednesday,"…—j“ú" },
                { DayOfWeek.Thursday, "–Ø—j“ú" },
                { DayOfWeek.Friday,   "‹à—j“ú" },
                { DayOfWeek.Saturday, "“y—j“ú" }
            };
            foreach(var dayofweek in Enum.GetValues(typeof(DayOfWeek))){
                var nextDate = NextWeek(datetime, (DayOfWeek)dayofweek);
                var str = string.Format("{0:yy/MM/dd}‚ÌŸT‚Ì{1}‚Í{2:yy/MM/dd}", datetime, dayOfWeekJapanese[(DayOfWeek)dayofweek], nextDate);
                tbDisp.Text += str + "\r\n";
             }

        //    var today = DateTime.Now;
        //    DayOfWeek dayOfWeek = DayOfWeek.Friday;
        //    var days = (int)dayOfWeek - (int)(today.DayOfWeek);
        //    if (days <= 7)
        //        days += 7;
        //    var nextdayweek = today.AddDays(days);
        //    tbDisp.Text = today.ToString("yyyy/MM/dd") + "‚ÌŸT‚Ì‹à—j“ú‚Í" + nextdayweek.ToString("yyyy/MM/dd/(ddd)");
              }

        public static DateTime NextWeek(DateTime date,DayOfWeek dayofweek) {
            var days = (int)dayofweek - (int)(date.DayOfWeek);
            if (days <= 7)
                days += 7;
            return date.AddDays(days);
        }

        private void btEx8_3_Click(object sender, EventArgs e) {
            var tw = new TimeWatch();
            tw.Start();
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            var str = "ˆ—ŠÔ‚Í"+duration.TotalMilliseconds +"ƒ~ƒŠ•b‚Å‚µ‚½";
            tbDisp.Text += str + "\r\n";
        }
        class TimeWatch {
           private DateTime _time;

            public void Start() {
                _time = DateTime.Now;

            }
            public TimeSpan Stop() {
                return DateTime.Now - _time;
            }


        }
    }
}
