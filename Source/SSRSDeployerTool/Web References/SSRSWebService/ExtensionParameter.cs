//   SSRSDeployerTool / ExtensionParameter.cs
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
    public partial class ExtensionParameter
    {
        /// <remarks/>
        public string Name { get; set; }
        
        /// <remarks/>
        public string DisplayName { get; set; }
        
        /// <remarks/>
        public bool Required { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequiredSpecified { get; set; }
        
        /// <remarks/>
        public bool ReadOnly { get; set; }
        
        /// <remarks/>
        public string Value { get; set; }
        
        /// <remarks/>
        public string Error { get; set; }
        
        /// <remarks/>
        public bool Encrypted { get; set; }
        
        /// <remarks/>
        public bool IsPassword { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Value")]
        public ValidValue[] ValidValues { get; set; }
    }
}