namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDateCount_Click(object sender, EventArgs e) {
            var today = DateTime.Now;
            TimeSpan diff = today - dtpDate.Value;
            tbDisp.Text = diff.Days.ToString() + "“ú–Ú";
        }

        private void btDayBefore_Click(object sender, EventArgs e) {
            //tbDisp.Text = nud.Value.ToString();
            var past = dtpDate.Value.AddDays((double)-nud.Value);
            tbDisp.Text = past.ToString("d");

        }

        private void beDayAfter_Click(object sender, EventArgs e) {
            var future = dtpDate.Value.AddDays((double)nud.Value);
            tbDisp.Text = future.ToString("d");
        }



        public static int get_age(DateTime birthday, DateTime targetday) {
            var age = targetday.Year - birthday.Year;
            if (targetday < birthday.AddYears(age)) {
                age--;
            }
            return age;
            //TimeSpan diff = today - dtpDate.Value;
            //var age = diff.Days / 365;
            //tbDisp.Text = age.ToString();
        }

        private void btAge_Click(object sender, EventArgs e) {
            var birthday = dtpDate.Value;
            var today = DateTime.Now;
            int age = get_age(birthday, today);
            tbDisp.Text = age.ToString("D")+"Î";
        }
    }
}
