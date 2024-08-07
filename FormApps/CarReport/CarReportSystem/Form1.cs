using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {

        BindingList<CarReport> listCarReports = new BindingList<CarReport>();
        Settings settings = Settings.GetInstance();

        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;


        }

        //設定インスタンス
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
            dtpDate.Text = DateTime.Now.ToString();
            cbAuther.Text = "";
            setRadioRuttonMaker(CarReport.MakerGroup.なし);
            cbCarName.Text = "";
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

            //交互に色を設定(データグリッドビュー)
            dgvCarReport.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCarReport.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;

            DeserializeSettings();
        }

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK)
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
        }

        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void dgvCarReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.Rows.Count == 0) || (!dgvCarReport.CurrentRow.Selected)) return;
            dtpDate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
            cbAuther.Text = (string)dgvCarReport.CurrentRow.Cells["Auther"].Value;
            setRadioRuttonMaker((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvCarReport.CurrentRow.Cells["Picture"].Value;
        }
        private void setRadioRuttonMaker(CarReport.MakerGroup makerGroup) {
            switch (makerGroup) {
                case CarReport.MakerGroup.なし:
                    NotRadioButtonMaker();
                    break;
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
            if ((dgvCarReport.Rows.Count == 0) || (!dgvCarReport.CurrentRow.Selected)) {
                tssb.Text = "削除するデータがありません";
                return;
            }
            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            tssb.Text = "";
            dgvCarReport.ClearSelection();
            Clear();
        }

        private void btModifyReport_Click(object sender, EventArgs e) { //データグリッドビューの修正

            if (dgvCarReport.CurrentRow == null) {
                tssb.Text = "修正するデータがありません";
                return;
            }
            if (cbAuther.Text == "" || cbCarName.Text == "") {
                tssb.Text = "記録者と車名を入力してください";
                //MessageBox.Show("記録者と車名を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            dgvCarReport.ClearSelection();

            dgvCarReport.Refresh();       //データグリッドビューの更新
        }

        private void cbAuther_TextChanged(object sender, EventArgs e) {
            tssb.Text = "";
        }

        private void cbCarName_TextChanged(object sender, EventArgs e) {
            tssb.Text = "";
        }
        //保存ボタン
        private void btReportSave_Click(object sender, EventArgs e) {
            ReportSaveFile();
        }

        private void ReportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(
                                        sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);

                    }

                }
                catch (Exception) {
                    tssb.Text = "書き込みエラー";
                }
            }
        }

        //開くボタンイベント
        private void btReportOpen_Click(object sender, EventArgs e) {
            ReportOpenFile();
        }

        private void ReportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvCarReport.DataSource = listCarReports;

                        if (listCarReports.Count > 0) {
                            var firstReport = listCarReports[0];
                            dtpDate.Value = firstReport.Date;
                            cbAuther.Text = firstReport.Auther;
                            setRadioRuttonMaker(firstReport.Maker);
                            cbCarName.Text = firstReport.CarName;
                            tbReport.Text = firstReport.Report;
                            pbPicture.Image = firstReport.Picture;

                            foreach (var report in listCarReports) {
                                setCbAuther(report.Auther);
                                setCbCarName(report.CarName);
                            }

                            dgvCarReport.ClearSelection();
                        }
                    }
                }
                catch (Exception) {
                    tssb.Text = "ファイル形式が違います";
                }
            }
        }

        private void btClear_Click(object sender, EventArgs e) {
            Clear();
            dgvCarReport.ClearSelection();
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportSaveFile();//ファイルセーブ処理
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportOpenFile();//ファイルオープン処理
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            // 確認メッセージを表示
            if (MessageBox.Show("アプリケーションを終了しますか？", "確認", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }



        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            // ダイアログの結果を確認
            if (cdColor.ShowDialog() == DialogResult.OK) {
                // 選択された色を背景色に設定
                BackColor = cdColor.Color;
                settings.MainFormColor = BackColor.ToArgb();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            SerializeSettings();
        }

        private void SerializeSettings() {
            try {
                using (var writer = XmlWriter.Create("setting.xml")) {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void DeserializeSettings() {
            try {
                if (File.Exists("setting.xml")) {
                    using (var reader = new StreamReader("setting.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        settings = serializer.Deserialize(reader) as Settings;

                        // Apply loaded settings
                        BackColor = Color.FromArgb(settings.MainFormColor);
                        settings.MainFormColor = BackColor.ToArgb();
                    }
                } else {
                    tssb.Text = "色情報ファイルがありません";
                }
            }
            catch (Exception ex) {

            }
        }


        private void このアプリについてToolStripMenuItem_Click(object sender, EventArgs e) {
            var fmversion = new fmVersion();
           // fmversion.ShowDialog();
            fmversion.ShowDialog();
        }
    }
}