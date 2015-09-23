//   SSRSDeployerTool / Job.cs
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

namespace SSRSDeployerTool.SSRSWebService
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2005/06/30/reporting/reportingservices")]
    public partial class Job
    {
        /// <remarks/>
        public string JobID { get; set; }
        
        /// <remarks/>
        public string Name { get; set; }
        
        /// <remarks/>
        public string Path { get; set; }
        
        /// <remarks/>
        public string Description { get; set; }
        
        /// <remarks/>
        public string Machine { get; set; }
        
        /// <remarks/>
        public string User { get; set; }
        
        /// <remarks/>
        public System.DateTime StartDateTime { get; set; }
        
        /// <remarks/>
        public JobActionEnum Action { get; set; }
        
        /// <remarks/>
        public JobTypeEnum Type { get; set; }
        
        /// <remarks/>
        public JobStatusEnum Status { get; set; }
    }
}