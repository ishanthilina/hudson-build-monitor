using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace hudson_build_monitor
{
    class MonitorConfig : ConfigurationSection 
    {
        public static MonitorConfig GetConfig()
        {
            return (MonitorConfig)System.Configuration.ConfigurationManager.GetSection("buildJobsSection");
        }

        [ConfigurationProperty("buildJobs", IsRequired = true, IsDefaultCollection = true)]
        //[ConfigurationCollection(typeof(BuildJobsCollection), AddItemName = "job")]
        public BuildJobsCollection BuildJob
        {
            get { return (BuildJobsCollection)this["buildJobs"]; }
            set { this["buildJobs"] = value; }
        }

    }

    public class BuildJobsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new BuildJob();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            //set to whatever Element Property you want to use for a key
            return ((BuildJob)element).Name;
        }
        public BuildJob this[int index]
        {
            get { return (BuildJob)base.BaseGet(index); }
            set{
                if(base.BaseGet(index)!=null){
                    base.BaseRemoveAt(index);
                }
                base.BaseAdd(index,value);
            }
        }
        public BuildJob this[string id]{
            get{return (BuildJob)base.BaseGet(id);}
        }
    }

    public class BuildJob : ConfigurationElement
    {
        //Make sure to set IsKey=true for property exposed as the GetElementKey above
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get { return (string)base["url"]; }
            set { base["url"] = value; }
        }
    }
}
