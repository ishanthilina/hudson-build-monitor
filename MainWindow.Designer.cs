namespace hudson_build_monitor
{
    partial class Main
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bStartMon = new System.Windows.Forms.Button();
            this.cbEnableAlarm = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nAlarmPauseLength = new System.Windows.Forms.NumericUpDown();
            this.bDiasble = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nAlarmPauseLength)).BeginInit();
            this.SuspendLayout();
            // 
            // bStartMon
            // 
            this.bStartMon.Location = new System.Drawing.Point(12, 12);
            this.bStartMon.Name = "bStartMon";
            this.bStartMon.Size = new System.Drawing.Size(98, 23);
            this.bStartMon.TabIndex = 0;
            this.bStartMon.Text = "Stop Monitoring";
            this.bStartMon.UseVisualStyleBackColor = true;
            this.bStartMon.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbEnableAlarm
            // 
            this.cbEnableAlarm.AutoSize = true;
            this.cbEnableAlarm.Checked = true;
            this.cbEnableAlarm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnableAlarm.Location = new System.Drawing.Point(125, 16);
            this.cbEnableAlarm.Name = "cbEnableAlarm";
            this.cbEnableAlarm.Size = new System.Drawing.Size(94, 17);
            this.cbEnableAlarm.TabIndex = 1;
            this.cbEnableAlarm.Text = "Alarm Enabled";
            this.cbEnableAlarm.UseVisualStyleBackColor = true;
            this.cbEnableAlarm.CheckedChanged += new System.EventHandler(this.cbEnableAlarm_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Disable alarm for";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seconds";
            // 
            // nAlarmPauseLength
            // 
            this.nAlarmPauseLength.Location = new System.Drawing.Point(98, 53);
            this.nAlarmPauseLength.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.nAlarmPauseLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nAlarmPauseLength.Name = "nAlarmPauseLength";
            this.nAlarmPauseLength.Size = new System.Drawing.Size(120, 20);
            this.nAlarmPauseLength.TabIndex = 5;
            this.nAlarmPauseLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bDiasble
            // 
            this.bDiasble.Location = new System.Drawing.Point(275, 50);
            this.bDiasble.Name = "bDiasble";
            this.bDiasble.Size = new System.Drawing.Size(75, 23);
            this.bDiasble.TabIndex = 6;
            this.bDiasble.Text = "Disable";
            this.bDiasble.UseVisualStyleBackColor = true;
            this.bDiasble.Click += new System.EventHandler(this.bDiasble_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 80);
            this.Controls.Add(this.bDiasble);
            this.Controls.Add(this.nAlarmPauseLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEnableAlarm);
            this.Controls.Add(this.bStartMon);
            this.Name = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.nAlarmPauseLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStartMon;
        private System.Windows.Forms.CheckBox cbEnableAlarm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nAlarmPauseLength;
        private System.Windows.Forms.Button bDiasble;
    }
}
