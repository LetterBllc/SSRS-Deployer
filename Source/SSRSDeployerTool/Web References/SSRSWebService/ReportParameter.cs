//   SSRSDeployerTool / ReportParameter.cs
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
    public partial class ReportParameter
    {
        /// <remarks/>
        public string Name { get; set; }
        
        /// <remarks/>
        public ParameterTypeEnum Type { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TypeSpecified { get; set; }
        
        /// <remarks/>
        public bool Nullable { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NullableSpecified { get; set; }
        
        /// <remarks/>
        public bool AllowBlank { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AllowBlankSpecified { get; set; }
        
        /// <remarks/>
        public bool MultiValue { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MultiValueSpecified { get; set; }
        
        /// <remarks/>
        public bool QueryParameter { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool QueryParameterSpecified { get; set; }
        
        /// <remarks/>
        public string Prompt { get; set; }
        
        /// <remarks/>
        public bool PromptUser { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PromptUserSpecified { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Dependency")]
        public string[] Dependencies { get; set; }
        
        /// <remarks/>
        public bool ValidValuesQueryBased { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidValuesQueryBasedSpecified { get; set; }
        
        /// <remarks/>
        public ValidValue[] ValidValues { get; set; }
        
        /// <remarks/>
        public bool DefaultValuesQueryBased { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DefaultValuesQueryBasedSpecified { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Value")]
        public string[] DefaultValues { get; set; }
        
        /// <remarks/>
        public ParameterStateEnum State { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StateSpecified { get; set; }
        
        /// <remarks/>
        public string ErrorMessage { get; set; }
    }
}