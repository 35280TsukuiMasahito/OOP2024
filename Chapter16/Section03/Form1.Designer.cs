namespace Section03 {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.bt_16_6 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bt_16_7 = new System.Windows.Forms.Button();
            this.bt_16_8 = new System.Windows.Forms.Button();
            this.bt_16_9 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_16_6
            // 
            this.bt_16_6.Location = new System.Drawing.Point(69, 28);
            this.bt_16_6.Name = "bt_16_6";
            this.bt_16_6.Size = new System.Drawing.Size(231, 23);
            this.bt_16_6.TabIndex = 0;
            this.bt_16_6.Text = "イベントハンドラを非同期にする(1)";
            this.bt_16_6.UseVisualStyleBackColor = true;
            this.bt_16_6.Click += new System.EventHandler(this.bt_16_6_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // bt_16_7
            // 
            this.bt_16_7.Location = new System.Drawing.Point(69, 94);
            this.bt_16_7.Name = "bt_16_7";
            this.bt_16_7.Size = new System.Drawing.Size(231, 23);
            this.bt_16_7.TabIndex = 2;
            this.bt_16_7.Text = "イベントハンドラを非同期にする(2)";
            this.bt_16_7.UseVisualStyleBackColor = true;
            this.bt_16_7.Click += new System.EventHandler(this.bt_16_7_Click);
            // 
            // bt_16_8
            // 
            this.bt_16_8.Location = new System.Drawing.Point(69, 169);
            this.bt_16_8.Name = "bt_16_8";
            this.bt_16_8.Size = new System.Drawing.Size(231, 23);
            this.bt_16_8.TabIndex = 2;
            this.bt_16_8.Text = "非同期のメソッドの定義(戻り値のない場合)";
            this.bt_16_8.UseVisualStyleBackColor = true;
            this.bt_16_8.Click += new System.EventHandler(this.bt_16_8_Click);
            // 
            // bt_16_9
            // 
            this.bt_16_9.Location = new System.Drawing.Point(69, 242);
            this.bt_16_9.Name = "bt_16_9";
            this.bt_16_9.Size = new System.Drawing.Size(231, 23);
            this.bt_16_9.TabIndex = 2;
            this.bt_16_9.Text = "非同期のメソッドの定義(戻り値のある場合)";
            this.bt_16_9.UseVisualStyleBackColor = true;
            this.bt_16_9.Click += new System.EventHandler(this.bt_16_9_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bt_16_9);
            this.Controls.Add(this.bt_16_8);
            this.Controls.Add(this.bt_16_7);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.bt_16_6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_16_6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button bt_16_7;
        private System.Windows.Forms.Button bt_16_8;
        private System.Windows.Forms.Button bt_16_9;
    }
}

