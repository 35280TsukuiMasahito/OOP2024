namespace CarReportSystem {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dtpDate = new DateTimePicker();
            cbAuther = new ComboBox();
            cbCarName = new ComboBox();
            tbReport = new TextBox();
            label6 = new Label();
            btPicOpen = new Button();
            btPicDelete = new Button();
            pbPicture = new PictureBox();
            btAddReport = new Button();
            btModifyReport = new Button();
            btDeleteReport = new Button();
            label7 = new Label();
            dgvCarReport = new DataGridView();
            btReportOpen = new Button();
            btReportSave = new Button();
            rbToyota = new RadioButton();
            rbNissan = new RadioButton();
            rbHonda = new RadioButton();
            rbSubaru = new RadioButton();
            rbImport = new RadioButton();
            rbOther = new RadioButton();
            MakerBox = new GroupBox();
            ofdPicFileOpen = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarReport).BeginInit();
            MakerBox.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(55, 25);
            label1.Name = "label1";
            label1.Size = new Size(50, 25);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(36, 92);
            label2.Name = "label2";
            label2.Size = new Size(69, 25);
            label2.TabIndex = 0;
            label2.Text = "記録者";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(42, 162);
            label3.Name = "label3";
            label3.Size = new Size(63, 25);
            label3.TabIndex = 0;
            label3.Text = "メーカー";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(55, 228);
            label4.Name = "label4";
            label4.Size = new Size(50, 25);
            label4.TabIndex = 0;
            label4.Text = "車名";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.Location = new Point(38, 299);
            label5.Name = "label5";
            label5.Size = new Size(67, 25);
            label5.TabIndex = 0;
            label5.Text = "レポート";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(111, 19);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 33);
            dtpDate.TabIndex = 1;
            // 
            // cbAuther
            // 
            cbAuther.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbAuther.FormattingEnabled = true;
            cbAuther.Location = new Point(113, 89);
            cbAuther.Name = "cbAuther";
            cbAuther.Size = new Size(200, 33);
            cbAuther.TabIndex = 2;
            // 
            // cbCarName
            // 
            cbCarName.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbCarName.FormattingEnabled = true;
            cbCarName.Location = new Point(113, 225);
            cbCarName.Name = "cbCarName";
            cbCarName.Size = new Size(200, 33);
            cbCarName.TabIndex = 2;
            // 
            // tbReport
            // 
            tbReport.Location = new Point(111, 299);
            tbReport.Multiline = true;
            tbReport.Name = "tbReport";
            tbReport.Size = new Size(355, 107);
            tbReport.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.Location = new Point(611, 55);
            label6.Name = "label6";
            label6.Size = new Size(50, 25);
            label6.TabIndex = 0;
            label6.Text = "画像";
            // 
            // btPicOpen
            // 
            btPicOpen.Location = new Point(718, 54);
            btPicOpen.Name = "btPicOpen";
            btPicOpen.Size = new Size(81, 32);
            btPicOpen.TabIndex = 5;
            btPicOpen.Text = "開く...";
            btPicOpen.UseVisualStyleBackColor = true;
            btPicOpen.Click += btPicOpen_Click;
            // 
            // btPicDelete
            // 
            btPicDelete.Location = new Point(824, 54);
            btPicDelete.Name = "btPicDelete";
            btPicDelete.Size = new Size(83, 32);
            btPicDelete.TabIndex = 5;
            btPicDelete.Text = "削除";
            btPicDelete.UseVisualStyleBackColor = true;
            btPicDelete.Click += btPicDelete_Click;
            // 
            // pbPicture
            // 
            pbPicture.BackColor = Color.Silver;
            pbPicture.Location = new Point(611, 92);
            pbPicture.Name = "pbPicture";
            pbPicture.Size = new Size(296, 193);
            pbPicture.SizeMode = PictureBoxSizeMode.Zoom;
            pbPicture.TabIndex = 6;
            pbPicture.TabStop = false;
            // 
            // btAddReport
            // 
            btAddReport.Location = new Point(611, 298);
            btAddReport.Name = "btAddReport";
            btAddReport.Size = new Size(81, 32);
            btAddReport.TabIndex = 5;
            btAddReport.Text = "追加";
            btAddReport.UseVisualStyleBackColor = true;
            btAddReport.Click += btAddReport_Click;
            // 
            // btModifyReport
            // 
            btModifyReport.Location = new Point(718, 298);
            btModifyReport.Name = "btModifyReport";
            btModifyReport.Size = new Size(81, 32);
            btModifyReport.TabIndex = 5;
            btModifyReport.Text = "修正";
            btModifyReport.UseVisualStyleBackColor = true;
            btModifyReport.Click += btModifyReport_Click;
            // 
            // btDeleteReport
            // 
            btDeleteReport.Location = new Point(826, 298);
            btDeleteReport.Name = "btDeleteReport";
            btDeleteReport.Size = new Size(81, 32);
            btDeleteReport.TabIndex = 5;
            btDeleteReport.Text = "削除";
            btDeleteReport.UseVisualStyleBackColor = true;
            btDeleteReport.Click += btDeleteReport_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label7.Location = new Point(55, 426);
            label7.Name = "label7";
            label7.Size = new Size(50, 25);
            label7.TabIndex = 0;
            label7.Text = "一覧";
            // 
            // dgvCarReport
            // 
            dgvCarReport.AllowUserToAddRows = false;
            dgvCarReport.AllowUserToDeleteRows = false;
            dgvCarReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarReport.Location = new Point(111, 432);
            dgvCarReport.MultiSelect = false;
            dgvCarReport.Name = "dgvCarReport";
            dgvCarReport.ReadOnly = true;
            dgvCarReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarReport.Size = new Size(796, 150);
            dgvCarReport.TabIndex = 7;
            dgvCarReport.Click += dgvCarReport_Click;
            // 
            // btReportOpen
            // 
            btReportOpen.Location = new Point(24, 510);
            btReportOpen.Name = "btReportOpen";
            btReportOpen.Size = new Size(81, 32);
            btReportOpen.TabIndex = 5;
            btReportOpen.Text = "開く...";
            btReportOpen.UseVisualStyleBackColor = true;
            // 
            // btReportSave
            // 
            btReportSave.Location = new Point(24, 550);
            btReportSave.Name = "btReportSave";
            btReportSave.Size = new Size(81, 32);
            btReportSave.TabIndex = 5;
            btReportSave.Text = "保存...";
            btReportSave.UseVisualStyleBackColor = true;
            // 
            // rbToyota
            // 
            rbToyota.AutoSize = true;
            rbToyota.Location = new Point(0, 39);
            rbToyota.Name = "rbToyota";
            rbToyota.Size = new Size(50, 19);
            rbToyota.TabIndex = 0;
            rbToyota.TabStop = true;
            rbToyota.Text = "トヨタ";
            rbToyota.UseVisualStyleBackColor = true;
            // 
            // rbNissan
            // 
            rbNissan.AutoSize = true;
            rbNissan.Location = new Point(56, 39);
            rbNissan.Name = "rbNissan";
            rbNissan.Size = new Size(49, 19);
            rbNissan.TabIndex = 0;
            rbNissan.TabStop = true;
            rbNissan.Text = "日産";
            rbNissan.UseVisualStyleBackColor = true;
            // 
            // rbHonda
            // 
            rbHonda.AutoSize = true;
            rbHonda.Location = new Point(111, 39);
            rbHonda.Name = "rbHonda";
            rbHonda.Size = new Size(53, 19);
            rbHonda.TabIndex = 0;
            rbHonda.TabStop = true;
            rbHonda.Text = "ホンダ";
            rbHonda.UseVisualStyleBackColor = true;
            // 
            // rbSubaru
            // 
            rbSubaru.AutoSize = true;
            rbSubaru.Location = new Point(170, 39);
            rbSubaru.Name = "rbSubaru";
            rbSubaru.Size = new Size(54, 19);
            rbSubaru.TabIndex = 0;
            rbSubaru.TabStop = true;
            rbSubaru.Text = "スバル";
            rbSubaru.UseVisualStyleBackColor = true;
            // 
            // rbImport
            // 
            rbImport.AutoSize = true;
            rbImport.Location = new Point(230, 39);
            rbImport.Name = "rbImport";
            rbImport.Size = new Size(61, 19);
            rbImport.TabIndex = 0;
            rbImport.TabStop = true;
            rbImport.Text = "輸入車";
            rbImport.UseVisualStyleBackColor = true;
            // 
            // rbOther
            // 
            rbOther.AutoSize = true;
            rbOther.Location = new Point(297, 39);
            rbOther.Name = "rbOther";
            rbOther.Size = new Size(56, 19);
            rbOther.TabIndex = 0;
            rbOther.TabStop = true;
            rbOther.Text = "その他";
            rbOther.UseVisualStyleBackColor = true;
            // 
            // MakerBox
            // 
            MakerBox.Controls.Add(rbOther);
            MakerBox.Controls.Add(rbImport);
            MakerBox.Controls.Add(rbSubaru);
            MakerBox.Controls.Add(rbHonda);
            MakerBox.Controls.Add(rbNissan);
            MakerBox.Controls.Add(rbToyota);
            MakerBox.Location = new Point(113, 128);
            MakerBox.Name = "MakerBox";
            MakerBox.Size = new Size(365, 72);
            MakerBox.TabIndex = 3;
            MakerBox.TabStop = false;
            // 
            // ofdPicFileOpen
            // 
            ofdPicFileOpen.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 614);
            Controls.Add(dgvCarReport);
            Controls.Add(pbPicture);
            Controls.Add(btPicDelete);
            Controls.Add(btDeleteReport);
            Controls.Add(btModifyReport);
            Controls.Add(btReportSave);
            Controls.Add(btReportOpen);
            Controls.Add(btAddReport);
            Controls.Add(btPicOpen);
            Controls.Add(tbReport);
            Controls.Add(MakerBox);
            Controls.Add(cbCarName);
            Controls.Add(cbAuther);
            Controls.Add(dtpDate);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label1);
            Name = "Form1";
            Text = "試乗レポート管理システム";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarReport).EndInit();
            MakerBox.ResumeLayout(false);
            MakerBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpDate;
        private ComboBox cbAuther;
        private ComboBox cbCarName;
        private TextBox tbReport;
        private Label label6;
        private Button btPicOpen;
        private Button btPicDelete;
        private PictureBox pbPicture;
        private Button btAddReport;
        private Button btModifyReport;
        private Button btDeleteReport;
        private Label label7;
        private DataGridView dgvCarReport;
        private Button btReportOpen;
        private Button btReportSave;
        private RadioButton rbToyota;
        private RadioButton rbNissan;
        private RadioButton rbHonda;
        private RadioButton rbSubaru;
        private RadioButton rbImport;
        private RadioButton rbOther;
        private GroupBox MakerBox;
        private OpenFileDialog ofdPicFileOpen;
    }
}
