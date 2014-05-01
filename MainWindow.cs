using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace hudson_build_monitor
{
    public partial class Main : Form
    {
        public static Boolean isMonitoring = false;
        Thread workerThread;

        public Main()
        {
            InitializeComponent();
            //start monitoring
            HudsonMonitor.isMonitoringEnabled = true;
            AlarmPlayer.isAlarmEnabled = true;
            workerThread = new Thread(HudsonMonitor.run);
            workerThread.Start();
            isMonitoring = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if already monitoring, stop monitoring
            if (isMonitoring)
            {
                HudsonMonitor.isMonitoringEnabled = false;
                isMonitoring = false;
                bStartMon.Text = "Start Monitoring";
                //disable the disable button
                bDiasble.Enabled = false;
            }
                //if not monitoring, start monitoring
            else
            {
                HudsonMonitor.isMonitoringEnabled = true;
                //start the monitor
                workerThread = new Thread(HudsonMonitor.run);
                workerThread.Start();
                isMonitoring = true;
                //change the label
                bStartMon.Text = "Stop Monitoring";
                //disable the timer too
                AlarmTimer.stop();
                //enable the disable button
                bDiasble.Enabled = true;
            }
            



        }

        private void cbEnableAlarm_CheckedChanged(object sender, EventArgs e)
        {
            //if the check box is enabled, enable the alarm
            if (cbEnableAlarm.Checked)
            {
                AlarmPlayer.isAlarmEnabled = true;
            }
            else
            {
                AlarmPlayer.isAlarmEnabled = false;
                AlarmPlayer.Stop_Alarm();
            }
        }

        private void bDiasble_Click(object sender, EventArgs e)
        {
            //first stop the alarm
            AlarmPlayer.Stop_Alarm();

            //stop monitoring hudson also
            HudsonMonitor.isMonitoringEnabled = false;
            isMonitoring = false;
            bStartMon.Text = "Start Monitoring";

            //convert the value to milli-seconds and start the timer
            AlarmTimer.Start(Convert.ToInt32(nAlarmPauseLength.Value)*1000);

        }

        /***
         * Used to set the text of the Start/Stop monitoring button
         */ 
        public void Monitoring_button_change_text(String message){
            //The following code segment is used to handle the "Cross-thread operation not valid" exception.
            //source: http://stackoverflow.com/questions/10775367/cross-thread-operation-not-valid-control-textbox1-accessed-from-a-thread-othe
            if (this.bStartMon.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Monitoring_button_change_text);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                this.bStartMon.Text = message;
            }
            bStartMon.Text = message;
        }

        delegate void SetTextCallback(string text);

        /***
         * Stops the program
         */ 
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
