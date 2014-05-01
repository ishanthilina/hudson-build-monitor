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
            
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mw);
            
            //Build lastBuild=Check_Last_Build();

            //Console.WriteLine("Last Build Number:" + lastBuild.buildNo);
            //Console.WriteLine("Last Build Status:" + lastBuild.buildStatus);
            //Console.Read();
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

        public static void Change_Monitoring_Button_Text(String message)
        {
            mw.Monitoring_button_change_text(message);
        }
    }

   
}
