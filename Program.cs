using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;

using RestSharp;
using Newtonsoft.Json;




namespace hudson_build_monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Check_Last_Build();
        }

        private static void Check_Last_Build()
        {
            var client = new RestClient("http://deadlock.netbeans.org/job/trunk/");
            var request = new RestRequest("lastBuild/api/json", Method.GET);
            var queryResult = client.Execute(request).Content;

            dynamic stuff = JsonConvert.DeserializeObject(queryResult);
            Console.WriteLine("Last Build Number:" + stuff.number);
            Console.WriteLine("Last Build Status:"+stuff.result);



            Console.Read();
        }
    }
}
