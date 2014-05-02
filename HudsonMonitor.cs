using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

using RestSharp;
using Newtonsoft.Json;

using System.Threading;
using WMPLib;

using System.Xml;
using System.IO;


namespace hudson_build_monitor
{
    class HudsonMonitor
    {
        //hudson build statuses
        public const String SUCCESS = "SUCCESS";

        public static Boolean isMonitoringEnabled = false;


        //settings
        private static String apiRoot = ConfigurationManager.AppSettings["apiRoot"];
        private static int sleepLength = Convert.ToInt32(ConfigurationManager.AppSettings["monitoringFrequency"]) * 1000;



        public static void run()
        {
            while (isMonitoringEnabled)
            {
                Build lastBuild = Check_Last_Build();

                Console.WriteLine("Build Number:" + lastBuild.buildNo + " || Status: " + lastBuild.buildStatus);
                
                //if the status is not success, play the alarm
                if (!lastBuild.buildStatus.Equals(SUCCESS))
                {
                    AlarmPlayer.Play_Alarm();
                }
                Thread.Sleep(sleepLength);
            }

            //stop the alarm when stopping monitoring
            AlarmPlayer.Stop_Alarm();



        }
        /***
         * Checks the status of the last build
         */
        private static Build Check_Last_Build()
        {
            //get the result from the API
            var client = new RestClient(apiRoot);
            var request = new RestRequest("lastBuild/api/xml", Method.GET);
            var queryResult = client.Execute(request).Content;

            //parse the JSON string
            //dynamic result = JsonConvert.DeserializeObject(queryResult);

            StringBuilder output = new StringBuilder();
            String buildStatus;
            int buildNo;

            XmlReader reader = XmlReader.Create(new StringReader(queryResult));
            
                
                reader.ReadToFollowing("building");
                String isBuilding = reader.ReadElementContentAsString();
                //if no build is in progress
                if (!isBuilding.Equals("true"))
                {
                    reader.ReadToFollowing("number");
                    buildNo = Convert.ToInt32(reader.ReadElementContentAsString());
                    //reset the reader
                    reader = XmlReader.Create(new StringReader(queryResult));
                    
                    reader.ReadToFollowing("result");
                    buildStatus = reader.ReadElementContentAsString();
                    
                    return new Build(buildNo, buildStatus);
                }

                else
                {
                    return new Build(00, "SUCCESS");
                }
                

        }
    }
}
