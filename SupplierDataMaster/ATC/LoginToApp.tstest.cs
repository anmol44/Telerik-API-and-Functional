using Telerik.TestStudio.Translators.Common;
using Telerik.TestingFramework.Controls.TelerikUI.Blazor;
using Telerik.TestingFramework.Controls.KendoUI.Angular;
using Telerik.TestingFramework.Controls.KendoUI;
using Telerik.WebAii.Controls.Html;
using Telerik.WebAii.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;
using ArtOfTest.WebAii.Design;
using ArtOfTest.WebAii.Design.Execution;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace new_test_project
{

    public class LoginToApp : BaseWebAiiTest
    {
        #region [ Dynamic Pages Reference ]

        private Pages _pages;

        /// <summary>
        /// Gets the Pages object that has references
        /// to all the elements, frames or regions
        /// in this project.
        /// </summary>
        public Pages Pages
        {
            get
            {
                if (_pages == null)
                {
                    _pages = new Pages(Manager.Current);
                }
                return _pages;
            }
        }

        #endregion
        
        // Add your test methods here...
    
        [CodedStep(@"Navigate to : 'https://arc.sd.is.ssg/'")]
        public void LoginToApp_CodedStep()
        {
            // Navigate to : 'https://arc.sd.is.ssg/'
            ActiveBrowser.NavigateTo("https://arc.sd.is.ssg/LoginAsUser", true);
         int id = Int32.Parse(Data["SUPPLIER"].ToString());         
            SetExtractedValue("increament",id); 
        }
    
        [CodedStep(@"Enter text 'lbaisin' in 'TxtAliasText' - DataDriven: [$(increament)]")]
        public void LoginToApp_CodedStep1()
        {
            // Enter text 'lbaisin' in 'TxtAliasText'
            Actions.SetText(Pages.IndexSupplierMasterData.TxtAliasText, ((string)(System.Convert.ChangeType(Data["USER"], typeof(string)))));
            
        }
    
        [CodedStep(@"Enter text 'dev123' in 'TxtPasswordPassword'")]
        public void LoginToApp_CodedStep2()
        {
            // Enter text 'dev123' in 'TxtPasswordPassword'
            Actions.SetText(Pages.IndexSupplierMasterData.TxtPasswordPassword, ((string)(System.Convert.ChangeType(Data["PASSWORD"], typeof(string)))));
            
        }
    }
}
