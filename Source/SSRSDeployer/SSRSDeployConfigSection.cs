using System.Configuration;

namespace SSRSDeployer
{
    public class SSRSDeployConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("folders")]
        public FoldersCollection FolderItems
        {
            get { return ((FoldersCollection)(base["folders"])); }
        }

        [ConfigurationProperty("target", IsRequired = false)]
        public string Target
        {
            get { return (string)this["target"]; }
            set { this["target"] = value; }
        }

        [ConfigurationProperty("domain", IsRequired = false)]
        public string Domain
        {
            get { return (string)this["domain"]; }
            set { this["domain"] = value; }
        }

        [ConfigurationProperty("username", IsRequired = false)]
        public string UserName
        {
            get { return (string)this["username"]; }
            set { this["username"] = value; }
        }

        [ConfigurationProperty("password", IsRequired = false)]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }
    }
}