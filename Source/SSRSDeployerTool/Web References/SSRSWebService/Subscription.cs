//   SSRSDeployerTool / Subscription.cs
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
    public partial class Subscription
    {
        /// <remarks/>
        public string SubscriptionID { get; set; }
        
        /// <remarks/>
        public string Owner { get; set; }
        
        /// <remarks/>
        public string Path { get; set; }
        
        /// <remarks/>
        public string VirtualPath { get; set; }
        
        /// <remarks/>
        public string Report { get; set; }
        
        /// <remarks/>
        public ExtensionSettings DeliverySettings { get; set; }
        
        /// <remarks/>
        public string Description { get; set; }
        
        /// <remarks/>
        public string Status { get; set; }
        
        /// <remarks/>
        public ActiveState Active { get; set; }
        
        /// <remarks/>
        public System.DateTime LastExecuted { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastExecutedSpecified { get; set; }
        
        /// <remarks/>
        public string ModifiedBy { get; set; }
        
        /// <remarks/>
        public System.DateTime ModifiedDate { get; set; }
        
        /// <remarks/>
        public string EventType { get; set; }
        
        /// <remarks/>
        public bool IsDataDriven { get; set; }
    }
}