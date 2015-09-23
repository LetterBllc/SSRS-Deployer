//   SSRSDeployerTool / Schedule.cs
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
    public partial class Schedule
    {
        /// <remarks/>
        public string ScheduleID { get; set; }
        
        /// <remarks/>
        public string Name { get; set; }
        
        /// <remarks/>
        public ScheduleDefinition Definition { get; set; }
        
        /// <remarks/>
        public string Description { get; set; }
        
        /// <remarks/>
        public string Creator { get; set; }
        
        /// <remarks/>
        public System.DateTime NextRunTime { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NextRunTimeSpecified { get; set; }
        
        /// <remarks/>
        public System.DateTime LastRunTime { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastRunTimeSpecified { get; set; }
        
        /// <remarks/>
        public bool ReferencesPresent { get; set; }
        
        /// <remarks/>
        public ScheduleStateEnum State { get; set; }
    }
}