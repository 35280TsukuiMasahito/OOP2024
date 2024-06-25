namespace DateTimeApp {
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
            dtpDate = new DateTimePicker();
            btDateCount = new Button();
            tbDisp = new TextBox();
            nud = new NumericUpDown();
            btDayBefore = new Button();
            beDayAfter = new Button();
            btAge = new Button();
            ((System.ComponentModel.ISupportInitialize)nud).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("メイリオ", 18F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.Location = new Point(61, 34);
            label1.Name = "label1";
            label1.Size = new Size(63, 36);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(170, 41);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(160, 23);
            dtpDate.TabIndex = 1;
            // 
            // btDateCount
            // 
            btDateCount.Location = new Point(226, 96);
            btDateCount.Name = "btDateCount";
            btDateCount.Size = new Size(104, 47);
            btDateCount.TabIndex = 2;
            btDateCount.Text = "今日までの日数";
            btDateCount.UseVisualStyleBackColor = true;
            btDateCount.Click += btDateCount_Click;
            // 
            // tbDisp
            // 
            tbDisp.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbDisp.Location = new Point(33, 303);
            tbDisp.Name = "tbDisp";
            tbDisp.Size = new Size(297, 39);
            tbDisp.TabIndex = 3;
            // 
            // nud
            // 
            nud.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nud.Location = new Point(33, 189);
            nud.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nud.Name = "nud";
            nud.Size = new Size(120, 46);
            nud.TabIndex = 4;
            // 
            // btDayBefore
            // 
            btDayBefore.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDayBefore.Location = new Point(226, 162);
            btDayBefore.Name = "btDayBefore";
            btDayBefore.Size = new Size(104, 46);
            btDayBefore.TabIndex = 5;
            btDayBefore.Text = "日前";
            btDayBefore.UseVisualStyleBackColor = true;
            btDayBefore.Click += btDayBefore_Click;
            // 
            // beDayAfter
            // 
            beDayAfter.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            beDayAfter.Location = new Point(354, 162);
            beDayAfter.Name = "beDayAfter";
            beDayAfter.Size = new Size(104, 46);
            beDayAfter.TabIndex = 5;
            beDayAfter.Text = "日後";
            beDayAfter.UseVisualStyleBackColor = true;
            beDayAfter.Click += beDayAfter_Click;
            // 
            // btAge
            // 
            btAge.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btAge.Location = new Point(226, 233);
            btAge.Name = "btAge";
            btAge.Size = new Size(104, 42);
            btAge.TabIndex = 6;
            btAge.Text = "年齢";
            btAge.UseVisualStyleBackColor = true;
            btAge.Click += btAge_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 528);
            Controls.Add(btAge);
            Controls.Add(beDayAfter);
            Controls.Add(btDayBefore);
            Controls.Add(nud);
            Controls.Add(tbDisp);
            Controls.Add(btDateCount);
            Controls.Add(dtpDate);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nud).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpDate;
        private Button btDateCount;
        private TextBox tbDisp;
        private NumericUpDown nud;
        private Button btDayBefore;
        private Button beDayAfter;
        private Button btAge;
    }
}
