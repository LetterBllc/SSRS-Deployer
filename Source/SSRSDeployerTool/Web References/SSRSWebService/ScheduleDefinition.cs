//   SSRSDeployerTool / ScheduleDefinition.cs
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
    public partial class ScheduleDefinition : ScheduleDefinitionOrReference
    {
        /// <remarks/>
        public System.DateTime StartDateTime { get; set; }
        
        /// <remarks/>
        public System.DateTime EndDate { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateSpecified { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DailyRecurrence", typeof(DailyRecurrence))]
        [System.Xml.Serialization.XmlElementAttribute("MinuteRecurrence", typeof(MinuteRecurrence))]
        [System.Xml.Serialization.XmlElementAttribute("MonthlyDOWRecurrence", typeof(MonthlyDOWRecurrence))]
        [System.Xml.Serialization.XmlElementAttribute("MonthlyRecurrence", typeof(MonthlyRecurrence))]
        [System.Xml.Serialization.XmlElementAttribute("WeeklyRecurrence", typeof(WeeklyRecurrence))]
        public RecurrencePattern Item { get; set; }
    }
}