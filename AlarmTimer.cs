using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;

namespace hudson_build_monitor
{
    class AlarmTimer
    {
        private static System.Timers.Timer _timer;
        
        public static void Start(int length )
        {
            _timer = new System.Timers.Timer(length); // Set up the timer for "length" seconds
            //
            // Type "_timer.Elapsed += " and press tab twice.
            //
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true; // Enable it
        }

        public static void stop()
        {
            _timer.Enabled = false;
        }

        /***
         * Gets called when the timer has completed counting to the desired tme.
         */ 
        private static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Timer countdown done");

            HudsonMonitor.isMonitoringEnabled = true;
            AlarmPlayer.isAlarmEnabled = true;
            Thread workerThread = new Thread(HudsonMonitor.run);
            workerThread.Start();
            MainWindow.isMonitoring = true;

            //check the check box also


            //stop the timer
            _timer.Enabled = false;
        }
    }
}
