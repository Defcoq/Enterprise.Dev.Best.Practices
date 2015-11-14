using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.JP.Ecommerce.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string JanrainApiKey
        {
            get
            {
               return ConfigurationManager.AppSettings["JanRainApiKey"];
            }
        }

        public string LoggerName
        {
            get { return ConfigurationManager.AppSettings["LoggerName"]; }
        }
        public string NumberOfResultsPerPage
        {
            get { return ConfigurationManager.AppSettings["NumberOfResultsPerPage"]; }
        }

    }

}
