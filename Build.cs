using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hudson_build_monitor
{
    /**
     * This class is used to store information of builds 
     */
    class Build
    {
        public int buildNo { get; set; }
        public String buildStatus { get; set; }

        public Build(int buildNo, String buildStatus)
        {
            this.buildNo = buildNo;
            this.buildStatus = buildStatus;
        }
    }
}
