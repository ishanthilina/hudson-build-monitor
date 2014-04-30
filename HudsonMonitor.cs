using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RestSharp;
using Newtonsoft.Json;

using System.Threading;

namespace hudson_build_monitor
{
    class HudsonMonitor
    {
        public static Boolean isMonitoringEnabled = false;
        public static void run()
        {
            while (isMonitoringEnabled)
            {
                Build lastBuild = Check_Last_Build();

                Console.WriteLine("Last Build Number:" + lastBuild.buildNo);
                Console.WriteLine("Last Build Status:" + lastBuild.buildStatus);
                Thread.Sleep(100);
            }
            
        }

        private static Build Check_Last_Build()
        {
            //get the result from the API
            var client = new RestClient("http://deadlock.netbeans.org/job/trunk/");
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
