//   SSRSDeployerTool / ReportGroupsCollection.cs
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
    [ConfigurationCollection(typeof(SsrsReportGroup), AddItemName = "reportGroup")]
    class ReportGroupsCollection : ConfigurationElementCollection, IEnumerable<SsrsReportGroup>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SsrsReportGroup();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var configElement = element as SsrsReportGroup;
            return configElement != null ? configElement.Source : "";
        }

        public SsrsReportGroup this[int index]
        {
            get
            {
                return this.BaseGet(index) as SsrsReportGroup;
            }
        }

        #region IEnumerable<ConfigElement> Members

        IEnumerator<SsrsReportGroup> IEnumerable<SsrsReportGroup>.GetEnumerator()
        {
            return (from i in Enumerable.Range(0, this.Count)
                    select this[i])
                                   .GetEnumerator();
        }
        
        #endregion
    }
}