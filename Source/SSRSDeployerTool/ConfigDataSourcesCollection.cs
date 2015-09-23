//   SSRSDeployerTool / ConfigDataSourcesCollection.cs
// ------------------------------------------------------------------
//   Author:     Mark Ewer (MEwer@LetterBllc.com)
//   Modified:   9/23/2015
// ------------------------------------------------------------------
//   This software is a copyrighted work and no license to use, 
//   modify, or distribute is granted to you without specific written 
//   consent from Letter B LLC.
//  
//   Copyright 2014 Letter B LLC, All Rights Reserved
// ------------------------------------------------------------------

using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace SSRSDeployerTool
{
    [ConfigurationCollection(typeof(SsrsDataSource), AddItemName = "dataSource")]
    class ConfigDataSourcesCollection : ConfigurationElementCollection, IEnumerable<SsrsDataSource>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SsrsDataSource();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var configElement = element as SsrsDataSource;
            if (configElement != null)
            {
                return configElement.DatasourcePathWithName.GetName();
            }
            return "";
        }

        public SsrsDataSource this[int index]
        {
            get
            {
                return this.BaseGet(index) as SsrsDataSource;
            }
        }

        #region IEnumerable<DataSource> Members

        IEnumerator<SsrsDataSource> IEnumerable<SsrsDataSource>.GetEnumerator()
        {
            return (from i in Enumerable.Range(0, this.Count)
                    select this[i])
                                   .GetEnumerator();
        }
        
        #endregion
    }
}