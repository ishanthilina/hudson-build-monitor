namespace hudson_build_monitor
{
    partial class MainWindow
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
            this.cbEnableAlarm.Location = new System.Drawing.Point(125, 16);
            this.cbEnableAlarm.Name = "cbEnableAlarm";
            this.cbEnableAlarm.Size = new System.Drawing.Size(88, 17);
            this.cbEnableAlarm.TabIndex = 1;
            this.cbEnableAlarm.Text = "Enable Alarm";
            this.cbEnableAlarm.UseVisualStyleBackColor = true;
            this.cbEnableAlarm.CheckedChanged += new System.EventHandler(this.cbEnableAlarm_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 322);
            this.Controls.Add(this.cbEnableAlarm);
            this.Controls.Add(this.bStartMon);
            this.Name = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStartMon;
        private System.Windows.Forms.CheckBox cbEnableAlarm;
    }
}
