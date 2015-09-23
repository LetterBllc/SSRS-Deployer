//   SSRSDeployerTool / DataSetDefinition.cs
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
    public partial class DataSetDefinition
    {
        /// <remarks/>
        public Field[] Fields { get; set; }
        
        /// <remarks/>
        public QueryDefinition Query { get; set; }
        
        /// <remarks/>
        public SensitivityEnum CaseSensitivity { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CaseSensitivitySpecified { get; set; }
        
        /// <remarks/>
        public string Collation { get; set; }
        
        /// <remarks/>
        public SensitivityEnum AccentSensitivity { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AccentSensitivitySpecified { get; set; }
        
        /// <remarks/>
        public SensitivityEnum KanatypeSensitivity { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KanatypeSensitivitySpecified { get; set; }
        
        /// <remarks/>
        public SensitivityEnum WidthSensitivity { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WidthSensitivitySpecified { get; set; }
        
        /// <remarks/>
        public string Name { get; set; }
    }
}