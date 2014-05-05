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
            return (MonitorConfig)System.Configuration.ConfigurationManager.GetSection("buildJobsSection") ?? new MonitorConfig();
        }

        [System.Configuration.ConfigurationProperty("buildJobs")]
        [ConfigurationCollection(typeof(BuildJobsCollection), AddItemName = "job")]
        public BuildJobsCollection BuildJobs
        {
            get
            {
                object o = this["buildJobs"];
                return o as BuildJobsCollection;
            }
        }

    }

    public class BuildJobsCollection : ConfigurationElementCollection
    {
        public BuildJob this[int index]
        {
            get
            {
                return base.BaseGet(index) as BuildJob;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new BuildJob this[string responseString]
        {
            get { return (BuildJob)BaseGet(responseString); }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        protected override System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new BuildJob();
        }

        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((BuildJob)element).Name;
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
