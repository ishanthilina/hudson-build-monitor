using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RestSharp;
using Newtonsoft.Json;

using System.Threading;
using WMPLib;

namespace hudson_build_monitor
{
    class HudsonMonitor
    {
        //hudson build statuses
        public const String SUCCESS = "SUCCESS";

        public static Boolean isMonitoringEnabled = false;
        

        //settings
        private static String apiRoot = "http://deadlock.netbeans.org/job/trunk/";
        private static int sleepLength = 500;

        

        public static void run()
        {
            while (isMonitoringEnabled)
            {
                Build lastBuild = Check_Last_Build();

                Console.WriteLine("Last Build Number:" + lastBuild.buildNo);
                Console.WriteLine("Last Build Status:" + lastBuild.buildStatus);
                if (lastBuild.buildStatus.Equals(SUCCESS))
                {
                    AlarmPlayer.Play_Alarm();
                }
                Thread.Sleep(sleepLength);
            }

            //stop the alarm when stopping monitoring
            AlarmPlayer.Stop_Alarm();


            
        }

        private static Build Check_Last_Build()
        {
            //get the result from the API
            var client = new RestClient(apiRoot);
            var request = new RestRequest("lastBuild/api/json", Method.GET);
            var queryResult = client.Execute(request).Content;

            //parse the JSON string
            dynamic result = JsonConvert.DeserializeObject(queryResult);
            int buildNo = Convert.ToInt32(result.number);
            String buildStatus = result.result;
            return new Build(buildNo, buildStatus);
        }

        


    }
}
