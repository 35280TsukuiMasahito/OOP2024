namespace CarReportSystem {
    partial class fmVersion {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btVersionOK = new Button();
            label1 = new Label();
            version = new Label();
            create = new Label();
            compan = new Label();
            SuspendLayout();
            // 
            // btVersionOK
            // 
            btVersionOK.Location = new Point(234, 161);
            btVersionOK.Name = "btVersionOK";
            btVersionOK.Size = new Size(75, 23);
            btVersionOK.TabIndex = 0;
            btVersionOK.Text = "OK";
            btVersionOK.UseVisualStyleBackColor = true;
            btVersionOK.Click += btVersionOK_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("メイリオ", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 128);
            label1.Location = new Point(28, 14);
            label1.Name = "label1";
            label1.Size = new Size(208, 31);
            label1.TabIndex = 1;
            label1.Text = "CarReportSystem";
            // 
            // version
            // 
            version.AutoSize = true;
            version.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            version.Location = new Point(49, 45);
            version.Name = "version";
            version.Size = new Size(67, 21);
            version.TabIndex = 2;
            version.Text = "ver.0.0.1";
            // 
            // create
            // 
            create.AutoSize = true;
            create.Location = new Point(53, 74);
            create.Name = "create";
            create.Size = new Size(46, 15);
            create.TabIndex = 3;
            create.Text = "作者名:";
            // 
            // compan
            // 
            compan.AutoSize = true;
            compan.Location = new Point(53, 104);
            compan.Name = "compan";
            compan.Size = new Size(58, 15);
            compan.TabIndex = 4;
            compan.Text = "kaisyamei";
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 194);
            Controls.Add(compan);
            Controls.Add(create);
            Controls.Add(version);
            Controls.Add(label1);
            Controls.Add(btVersionOK);
            MaximizeBox = false;
            Name = "fmVersion";
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btVersionOK;
        private Label label1;
        private Label version;
        private Label create;
        private Label compan;
    }
}