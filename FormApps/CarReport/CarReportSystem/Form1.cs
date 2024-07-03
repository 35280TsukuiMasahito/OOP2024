using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace CarReportSystem {
    public partial class Form1 : Form {

        BindingList<CarReport> listCarReports = new BindingList<CarReport>();
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        private void btAddReport_Click(object sender, EventArgs e) {

            if (cbAuther.Text == "" || cbCarName.Text == "") {
                tssb.Text = "記録者と車名を入力してください";
                //MessageBox.Show("記録者と車名を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CarReport carReport = new CarReport() {
                Date = dtpDate.Value,
                Auther = cbAuther.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };

            tssb.Text = "";
            listCarReports.Add(carReport);

            setCbAuther(carReport.Auther);
            setCbCarName(carReport.CarName);

            Clear();

            dgvCarReport.ClearSelection();
        }

        private void Clear() {
            cbAuther.Text = "";
            cbCarName.Text = "";
            NotRadioButtonMaker();
            tbReport.Text = "";
            pbPicture.Image = null;
        }

        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked) {
                return CarReport.MakerGroup.トヨタ;
            } else if (rbNissan.Checked) {
                return CarReport.MakerGroup.日産;
            } else if (rbHonda.Checked) {
                return CarReport.MakerGroup.ホンダ;
            } else if (rbSubaru.Checked) {
                return CarReport.MakerGroup.スバル;
            } else if (rbImport.Checked) {
                return CarReport.MakerGroup.輸入車;
            } else {
                return CarReport.MakerGroup.その他;
            }
        }

        private void NotRadioButtonMaker() {
            rbToyota.Checked = false;
            rbNissan.Checked = false;
            rbHonda.Checked = false;
            rbSubaru.Checked = false;
            rbImport.Checked = false;
            rbOther.Checked = false;
        }

        //記録者の履歴をコンボボックスへ登録(重複なし)
        private void setCbAuther(String auther) {
            if (!cbAuther.Items.Contains(auther)) {
                cbAuther.Items.Add(auther);
            }
        }

        //車名の履歴をコンボボックスへ登録(重複なし)
        private void setCbCarName(String carName) {
            if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false;
        }

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK)
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
        }

        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void dgvCarReport_Click(object sender, EventArgs e) {
            if (dgvCarReport.Rows.Count == 0) return;
            dtpDate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
            cbAuther.Text = (string)dgvCarReport.CurrentRow.Cells["Auther"].Value;
            setRadioRuttonMaker((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvCarReport.CurrentRow.Cells["Picture"].Value;
        }
        private void setRadioRuttonMaker(CarReport.MakerGroup makerGroup) {
            switch (makerGroup) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;
            }
        }

        private void btDeleteReport_Click(object sender, EventArgs e) { //データグリッドビューを消す
            if (dgvCarReport.CurrentRow == null) {
                tssb.Text = "削除するデータがありません";
                return;
            }
            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            tssb.Text = "";
        }

        private void btModifyReport_Click(object sender, EventArgs e) { //データグリッドビューの修正

            if (dgvCarReport.CurrentRow == null) {
                tssb.Text = "修正するデータがありません";
                return;
            }

            //CarReport selectedReport = listCarReports[dgvCarReport.CurrentRow.Index];
            //selectedReport.Date = dtpDate.Value;
            //selectedReport.Auther = cbAuther.Text;
            //selectedReport.Maker = GetRadioButtonMaker();
            //selectedReport.CarName = cbCarName.Text;
            //selectedReport.Report = tbReport.Text;
            //selectedReport.Picture = pbPicture.Image;

            listCarReports[dgvCarReport.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvCarReport.CurrentRow.Index].Auther = cbAuther.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvCarReport.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Picture = pbPicture.Image;
            tssb.Text = "";

            setCbAuther(listCarReports[dgvCarReport.CurrentRow.Index].Auther);
            setCbCarName(listCarReports[dgvCarReport.CurrentRow.Index].CarName);

            dgvCarReport.Refresh();       //データグリッドビューの更新
        }
    }
}
