using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;

using RestSharp;
using Newtonsoft.Json;
using System.Windows.Forms;




namespace hudson_build_monitor
{
    class Program
    {
        static Main mw = new Main();

        static void Main(string[] args)
        {
            MonitorConfig config = MonitorConfig.GetConfig();
            Console.WriteLine("Printing items");
            foreach (BuildJobsCollection item in config.BuildJobs)
            {
                Console.WriteLine(item);

            }

            Console.WriteLine(" done");

            Application.EnableVisualStyles();
            Application.Run(mw);
        }

        /***
         * Used to set the text of the Start/Stop monitoring button
         */ 
        public static void Change_Monitoring_Button_Text(String message)
        {
            mw.Monitoring_button_change_text(message);
        }
    }

   
}
