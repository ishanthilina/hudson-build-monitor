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
    public partial class MainWindow : Form
    {
        private Boolean isMonitoring = false;
        Thread workerThread;

        public MainWindow()
        {
            InitializeComponent();
            //start monitoring
            HudsonMonitor.isMonitoringEnabled = true;
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
            }
            else
            {
                HudsonMonitor.isMonitoringEnabled = true;
                //start the monitor
                workerThread = new Thread(HudsonMonitor.run);
                workerThread.Start();
                isMonitoring = true;
                //change the label
                bStartMon.Text = "Stop Monitoring";
            }
            



        }
    }
}
