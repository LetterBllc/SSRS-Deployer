//   SSRSDeployerTool / CatalogItem.cs
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
    public partial class CatalogItem
    {
        /// <remarks/>
        public string ID { get; set; }
        
        /// <remarks/>
        public string Name { get; set; }
        
        /// <remarks/>
        public string Path { get; set; }
        
        /// <remarks/>
        public string VirtualPath { get; set; }
        
        /// <remarks/>
        public ItemTypeEnum Type { get; set; }
        
        /// <remarks/>
        public int Size { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SizeSpecified { get; set; }
        
        /// <remarks/>
        public string Description { get; set; }
        
        /// <remarks/>
        public bool Hidden { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HiddenSpecified { get; set; }
        
        /// <remarks/>
        public System.DateTime CreationDate { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreationDateSpecified { get; set; }
        
        /// <remarks/>
        public System.DateTime ModifiedDate { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ModifiedDateSpecified { get; set; }
        
        /// <remarks/>
        public string CreatedBy { get; set; }
        
        /// <remarks/>
        public string ModifiedBy { get; set; }
        
        /// <remarks/>
        public string MimeType { get; set; }
        
        /// <remarks/>
        public System.DateTime ExecutionDate { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExecutionDateSpecified { get; set; }
    }
}