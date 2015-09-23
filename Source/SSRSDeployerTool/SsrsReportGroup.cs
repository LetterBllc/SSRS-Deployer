//   SSRSDeployerTool / SsrsReportGroup.cs
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

using System.Configuration;

namespace SSRSDeployerTool
{
    class SsrsReportGroup : ConfigurationElement
    {
        [ConfigurationProperty("source", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Source
        {
            get
            {
                return base["source"].ToString().Replace("\\", "/");
            }
            set
            {
                base["source"] = value;
            }
        }

        [ConfigurationProperty("target", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Target
        {
            get
            {
                var value = base["target"].ToString().Replace("\\", "/").Trim('/');
                return string.Format("/{0}", value);
            }
            set
            {
                base["target"] = value;
            }
        }

        [ConfigurationProperty("dataSources")]
        public ConfigDataSourcesCollection DataSources
        {
            get
            {
                return base["dataSources"] as ConfigDataSourcesCollection;
            }
        }
    }
}