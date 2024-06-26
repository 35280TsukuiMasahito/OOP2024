using System.ComponentModel;

namespace CarReportSystem {
    public partial class Form1 : Form {

        BindingList<CarReport> listCarReport = new BindingList<CarReport>();
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReport;
        }

        private void btAddReport_Click(object sender, EventArgs e) {
            CarReport carReport = new CarReport() {
                Date = dtpDate.Value,
            };
        }
    }
}
