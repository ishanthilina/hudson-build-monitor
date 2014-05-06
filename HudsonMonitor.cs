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
using System.Collections.Specialized;

using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]


namespace hudson_build_monitor
{
    class HudsonMonitor
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod
().DeclaringType); 

        //hudson build statuses
        public const String SUCCESS = "SUCCESS";
        public const String BUILDING = "BUILDING";

        public static Boolean isMonitoringEnabled = false;
        public static Boolean beSilentTillNextCommit = false;

        private static Dictionary<String, Build> failedBuilds = new Dictionary<String, Build>();


        //settings
        //private static String apiRoot = ConfigurationManager.AppSettings["apiRoot"];
        private static int sleepLength = Convert.ToInt32(ConfigurationManager.AppSettings["monitoringFrequency"]) * 1000;
        private static NameValueCollection settings = ConfigurationManager.GetSection("buildJobsSection/buildJobs") 
                                            as System.Collections.Specialized.NameValueCollection;



        public static void run()
        {
            log.Info("Monitoring started.");

            while (isMonitoringEnabled)
            {
                Console.WriteLine("\t ### #################### ### ");
                Console.WriteLine("\t ### Hudson Build Monitor ### ");
                Console.WriteLine("\t ### #################### ### ");
                Console.WriteLine();

                //print the time
                Console.WriteLine("\t   Current Time: "+DateTime.Now.ToString("h:mm:ss tt"));
                Console.WriteLine();


                if (settings != null)
                {
                    Console.Write("Name".PadRight(25));
                    Console.Write("Number".PadRight(10));
                    Console.Write("Status".PadRight(10));
                    Console.WriteLine();
                    Console.WriteLine();

                    foreach (string buildName in settings.AllKeys)
                    {
                        
                        Build lastBuild = Check_Last_Build(settings[buildName]);

                        Console.Write(buildName.PadRight(25));
                        Console.Write(lastBuild.buildNo.ToString().PadRight(10));
                        Console.Write(lastBuild.buildStatus.ToString().PadRight(10));
                        Console.WriteLine();

                        //if the status is not success
                        if (!lastBuild.buildStatus.Equals(SUCCESS) && !lastBuild.buildStatus.Equals(BUILDING))
                        {
                            log.Info("Build: " + buildName+" Number: "+lastBuild.buildNo+" - Build failed." );
                            //add the build to the failed list
                            if (!failedBuilds.ContainsKey(buildName))
                            {
                                log.Info(" Build: " + buildName + " Number: " + lastBuild.buildNo + " - Added the build to the failed list.");
                                failedBuilds.Add(buildName, lastBuild);
                            }
                            //if the alarm should keep silent till the next commit
                            if (beSilentTillNextCommit)
                            {
                                log.Info("Build: " + buildName + " Number: " + lastBuild.buildNo + " - Be silent till next commit=True.");
                                //if this is a new commit
                                if (lastBuild.buildNo > failedBuilds[buildName].buildNo)
                                {
                                    log.Info("Build: " + buildName + " Number: " + lastBuild.buildNo + " - Fails on next commit also, replaying alarm.");

                                    //play the alarm
                                    AlarmPlayer.Play_Alarm();
                                    //reset the status
                                    beSilentTillNextCommit = false;
                                }
                            }
                            else
                            {
                                log.Info("Build: " + buildName + " Number: " + lastBuild.buildNo + " - Build failed, playing alarm.");

                                //play the alarm
                                AlarmPlayer.Play_Alarm();
                            }
                            
                        }
                        //if the status is success
                        else
                        {
                            //check if the build has failed in the previous commit
                            if (failedBuilds.ContainsKey(buildName))
                            {
                                log.Info("Build: " + buildName + " Number: " + lastBuild.buildNo + " -  Removing build form failed list.");

                                //remove it from the failed list 
                                failedBuilds.Remove(buildName);

                                //disable the alarm if no builds are failed now
                                if (failedBuilds.Count == 0)
                                {
                                    log.Info("Build: " + buildName + " Number: " + lastBuild.buildNo + " - All builds fine, disabling alarm.");
                                    AlarmPlayer.Stop_Alarm();
                                }
                            }
                        }
                    }
                    //refresh the output
                    Console.SetCursorPosition(0, Console.CursorTop - (settings.Count+8));
                }
                
                Thread.Sleep(sleepLength);
            }

            //stop the alarm when stopping monitoring
            AlarmPlayer.Stop_Alarm();

            log.Info("Monitoring stopped.");



        }

        /***
         * Clear all the information regarding the previous failed builds.
         */ 
        public static void ClearBuildData()
        {
            failedBuilds.Clear();
        }
        /***
         * Checks the status of the last build
         */
        private static Build Check_Last_Build(String apiRoot)
        {
            //get the result from the API
            var client = new RestClient(apiRoot);
            var request = new RestRequest("lastBuild/api/xml", Method.GET);
            var queryResult = client.Execute(request).Content;

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
                    reader.ReadToFollowing("number");
                    buildNo = Convert.ToInt32(reader.ReadElementContentAsString());
                    return new Build(buildNo, BUILDING);
                }
                

        }
    }
}
