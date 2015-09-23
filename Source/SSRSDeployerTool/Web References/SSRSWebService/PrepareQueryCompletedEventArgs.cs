//   SSRSDeployerTool / PrepareQueryCompletedEventArgs.cs
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PrepareQueryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {
        private object[] results;
        
        internal PrepareQueryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
        {
            this.results = results;
        }
        
        /// <remarks/>
        public DataSetDefinition Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((DataSetDefinition)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public bool Changed
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string[] ParameterNames
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[2]));
            }
        }
    }
}