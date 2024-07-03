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
                tssb.Text = "�L�^�҂ƎԖ�����͂��Ă�������";
                //MessageBox.Show("�L�^�҂ƎԖ�����͂��Ă��������B", "���̓G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                return CarReport.MakerGroup.�g���^;
            } else if (rbNissan.Checked) {
                return CarReport.MakerGroup.���Y;
            } else if (rbHonda.Checked) {
                return CarReport.MakerGroup.�z���_;
            } else if (rbSubaru.Checked) {
                return CarReport.MakerGroup.�X�o��;
            } else if (rbImport.Checked) {
                return CarReport.MakerGroup.�A����;
            } else {
                return CarReport.MakerGroup.���̑�;
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

        //�L�^�҂̗������R���{�{�b�N�X�֓o�^(�d���Ȃ�)
        private void setCbAuther(String auther) {
            if (!cbAuther.Items.Contains(auther)) {
                cbAuther.Items.Add(auther);
            }
        }

        //�Ԗ��̗������R���{�{�b�N�X�֓o�^(�d���Ȃ�)
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
                case CarReport.MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.�z���_:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.�A����:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;
            }
        }

        private void btDeleteReport_Click(object sender, EventArgs e) { //�f�[�^�O���b�h�r���[������
            if (dgvCarReport.CurrentRow == null) {
                tssb.Text = "�폜����f�[�^������܂���";
                return;
            }
            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            tssb.Text = "";
        }

        private void btModifyReport_Click(object sender, EventArgs e) { //�f�[�^�O���b�h�r���[�̏C��

            if (dgvCarReport.CurrentRow == null) {
                tssb.Text = "�C������f�[�^������܂���";
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

            dgvCarReport.Refresh();       //�f�[�^�O���b�h�r���[�̍X�V
        }
    }
}
