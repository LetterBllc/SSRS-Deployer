using System.Configuration;

namespace SSRSDeployer
{
    public class SSRSDeployFolderElement : ConfigurationElement
    {
        [ConfigurationProperty("path", DefaultValue = "", IsKey = true, IsRequired = false)]
        public string Path
        {
            get { return ((string)(base["path"])); }
            set { base["path"] = value; }
        }

        [ConfigurationProperty("target", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Target
        {
            get { return ((string)(base["target"])); }
            set { base["target"] = value; }
        }

        [ConfigurationProperty("datasource", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Datasource
        {
            get { return ((string)(base["datasource"])); }
            set { base["datasource"] = value; }
        }

        [ConfigurationProperty("connectionstring", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string ConnectionString
        {
            get { return ((string)(base["connectionstring"])); }
            set { base["connectionstring"] = value; }
        }
    }
}