using System.Configuration;

namespace SSRSDeployer
{
    [ConfigurationCollection(typeof(SSRSDeployFolderElement))]
    public class FoldersCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SSRSDeployFolderElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SSRSDeployFolderElement)(element)).Path;
        }
        public SSRSDeployFolderElement this[int idx]
        {
            get { return (SSRSDeployFolderElement)BaseGet(idx); }
        }
    }
}
