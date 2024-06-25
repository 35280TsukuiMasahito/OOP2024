namespace Exercise01 {
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
            btEx8_1 = new Button();
            tbDisp = new TextBox();
            btEx8_2 = new Button();
            btEx8_3 = new Button();
            SuspendLayout();
            // 
            // btEx8_1
            // 
            btEx8_1.Location = new Point(45, 51);
            btEx8_1.Name = "btEx8_1";
            btEx8_1.Size = new Size(160, 64);
            btEx8_1.TabIndex = 0;
            btEx8_1.Text = "問題8.1";
            btEx8_1.UseVisualStyleBackColor = true;
            btEx8_1.Click += button1_Click;
            // 
            // tbDisp
            // 
            tbDisp.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbDisp.Location = new Point(45, 141);
            tbDisp.Multiline = true;
            tbDisp.Name = "tbDisp";
            tbDisp.Size = new Size(624, 223);
            tbDisp.TabIndex = 1;
            // 
            // btEx8_2
            // 
            btEx8_2.Location = new Point(282, 55);
            btEx8_2.Name = "btEx8_2";
            btEx8_2.Size = new Size(167, 60);
            btEx8_2.TabIndex = 2;
            btEx8_2.Text = "問題8.2";
            btEx8_2.UseVisualStyleBackColor = true;
            btEx8_2.Click += btEx8_2_Click;
            // 
            // btEx8_3
            // 
            btEx8_3.Location = new Point(513, 55);
            btEx8_3.Name = "btEx8_3";
            btEx8_3.Size = new Size(156, 60);
            btEx8_3.TabIndex = 2;
            btEx8_3.Text = "問題8.3";
            btEx8_3.UseVisualStyleBackColor = true;
            btEx8_3.Click += btEx8_3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 522);
            Controls.Add(btEx8_3);
            Controls.Add(btEx8_2);
            Controls.Add(tbDisp);
            Controls.Add(btEx8_1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btEx8_1;
        private TextBox tbDisp;
        private Button btEx8_2;
        private Button btEx8_3;
    }
}
