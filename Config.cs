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
        [ConfigurationCollection(typeof(MonitorConfigInstanceCollection), AddItemName = "job")]
        public MonitorConfigInstanceCollection BuildJobs
        {
            get
            {
                object o = this["buildJobs"];
                return o as MonitorConfigInstanceCollection;
            }
        }

    }

    public class MonitorConfigInstanceCollection : ConfigurationElementCollection
    {
        public MonitorConfigInstanceElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as MonitorConfigInstanceElement;
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

        public new MonitorConfigInstanceElement this[string responseString]
        {
            get { return (MonitorConfigInstanceElement)BaseGet(responseString); }
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
            return new MonitorConfigInstanceElement();
        }

        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((MonitorConfigInstanceElement)element).Name;
        }
    }

    public class MonitorConfigInstanceElement : ConfigurationElement
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
