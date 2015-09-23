//   SSRSDeployerTool / GetSubscriptionPropertiesCompletedEventArgs.cs
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
    public partial class GetSubscriptionPropertiesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {
        private object[] results;
        
        internal GetSubscriptionPropertiesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
        {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public ExtensionSettings ExtensionSettings
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((ExtensionSettings)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string Description
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public ActiveState Active
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((ActiveState)(this.results[3]));
            }
        }
        
        /// <remarks/>
        public string Status
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[4]));
            }
        }
        
        /// <remarks/>
        public string EventType
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[5]));
            }
        }
        
        /// <remarks/>
        public string MatchData
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[6]));
            }
        }
        
        /// <remarks/>
        public ParameterValue[] Parameters
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((ParameterValue[])(this.results[7]));
            }
        }
    }
}