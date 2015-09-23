// -----------------------------------------------
//   Author:     Hung Vo ( it.minhhung@gmail.com )
//   Modified:   2014/12/18
// -----------------------------------------------

using System.Configuration;
using System.Linq;

namespace SSRSDeployerTool
{
    class SsrsDeploy : ConfigurationSection
    {
        [ConfigurationProperty("reportGroups", IsRequired = true)]
        public ReportGroupsCollection ReportGroups
        {
            get
            {
                return base["reportGroups"] as ReportGroupsCollection;
            }
        }

        [ConfigurationProperty("reportServiceUrl", IsRequired = false)]
        public string ReportServiceUrl
        {
            get
            {
                var url = (string)base["reportServiceUrl"];

                if (!url.StartsWith("http")) // support: https
                {
                    url = string.Format("http://{0}", url);
                }

                url = url.Trim('/');

                if (!url.EndsWith(".asmx"))
                {
                    url = string.Format("{0}/ReportService2005.asmx", url);
                }

                return url;
            }
            set
            {
                base["reportServiceUrl"] = value;
            }
        }

        [ConfigurationProperty("domain", IsRequired = false)]
        public string Domain
        {
            get
            {
                return (string)base["domain"];
            }
            set
            {
                base["domain"] = value;
            }
        }

        [ConfigurationProperty("password", IsRequired = false)]
        public string Password
        {
            get
            {
                return (string)base["password"];
            }
            set
            {
                base["password"] = value;
            }
        }

        [ConfigurationProperty("username", IsRequired = false)]
        public string Username
        {
            get
            {
                return (string)base["username"];
            }
            set
            {
                base["username"] = value;
            }
        }
    }
}