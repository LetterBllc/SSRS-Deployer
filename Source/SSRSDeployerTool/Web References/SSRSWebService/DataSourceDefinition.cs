//   SSRSDeployerTool / DataSourceDefinition.cs
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
    public partial class DataSourceDefinition : DataSourceDefinitionOrReference
    {
        /// <remarks/>
        public string Extension { get; set; }
        
        /// <remarks/>
        public string ConnectString { get; set; }
        
        /// <remarks/>
        public bool UseOriginalConnectString { get; set; }
        
        /// <remarks/>
        public bool OriginalConnectStringExpressionBased { get; set; }
        
        /// <remarks/>
        public CredentialRetrievalEnum CredentialRetrieval { get; set; }
        
        /// <remarks/>
        public bool WindowsCredentials { get; set; }
        
        /// <remarks/>
        public bool ImpersonateUser { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ImpersonateUserSpecified { get; set; }
        
        /// <remarks/>
        public string Prompt { get; set; }
        
        /// <remarks/>
        public string UserName { get; set; }
        
        /// <remarks/>
        public string Password { get; set; }
        
        /// <remarks/>
        public bool Enabled { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnabledSpecified { get; set; }
    }
}