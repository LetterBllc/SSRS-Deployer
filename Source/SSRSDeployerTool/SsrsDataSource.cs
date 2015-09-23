//   SSRSDeployerTool / SsrsDataSource.cs
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
    class SsrsDataSource : ConfigurationElement
    {
        //[ConfigurationProperty("datasourceName", DefaultValue = "", IsKey = true, IsRequired = false)]
        //public string DatasourceName
        //{
        //    get
        //    {
        //        return (string)base["datasourceName"];
        //    }
        //    set
        //    {
        //        base["datasourceName"] = value;
        //    }
        //}
        [ConfigurationProperty("dsPathName", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string DatasourcePathWithName
        {
            get
            {
                return base["dsPathName"].ToString().Replace("\\", "/"); 
            }
            set
            {
                base["dsPathName"] = value;
            }
        }

        [ConfigurationProperty("connectionString", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string ConnectionString
        {
            get
            {
                return (string)base["connectionString"];
            }
            set
            {
                base["connectionString"] = value;
            }
        }
    }
}