using Telerik.WebAii.Controls.Xaml.Wpf;
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
using ArtOfTest.WebAii.Wpf;

namespace new_test_project
{
    public class API : BaseWebAiiTest
    {
        #region [ Dynamic Applications Reference ]

        private Applications _applications;

        /// <summary>
        /// Gets the Applications object that has references
        /// to all the elements, windows or regions
        /// in this project.
        /// </summary>
        public Applications Applications
        {
            get
            {
                if (_applications == null)
                {
                    _applications = new Applications(Manager.Current);
                }
                return _applications;
            }
        }

        #endregion
        
        // Add your test methods here...
    
        [CodedStep(@"Execute API test 'SalaryCostApi (3)'")]
        public void API_CodedStep()
        {
            // Execute API test 'SalaryCostApi (3)'
            System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>> variables = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>();
            this.ExecuteApiTest(".\\SalaryCostApi (3)", variables);
            
        }
    }
}
