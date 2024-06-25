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
            tbDisp.Text += today.ToString("yyyy年MM月dd日 HH時mm分ss秒") + "\r\n";

            CultureInfo Japanese = new CultureInfo("ja-JP");
            Japanese.DateTimeFormat.Calendar = new JapaneseCalendar();
            string wareki_date = today.ToString("ggyy年M月d日(dddd)", Japanese);
            tbDisp.Text += wareki_date;
        }

        private void btEx8_2_Click(object sender, EventArgs e) {
            var today = DateTime.Now;
            DayOfWeek dayOfWeek = DayOfWeek.Friday;
            var days = (int)dayOfWeek - (int)(today.DayOfWeek);
            if (days <= 7)
                days += 7;
            var nextdayweek = today.AddDays(days);
            tbDisp.Text = today.ToString("yyyy/MM/dd") + "の次週の金曜日は" + nextdayweek.ToString("yyyy/MM/dd/(ddd)");
        }

        private void btEx8_3_Click(object sender, EventArgs e) {
            var tw = new System.Diagnostics.Stopwatch();
            tw.Start();
            int sum = 1 + 1 + 1;
            tw.Stop();
            TimeSpan duration = tw.Elapsed;
            tbDisp.Text = "処理時間は"+duration.TotalMilliseconds +"ミリ秒でした";
        }
    }
}
