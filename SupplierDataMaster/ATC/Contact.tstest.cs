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
using System.Threading;

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

    public class Contact : BaseWebAiiTest
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
    
        [CodedStep(@"Wait for Exists 'ContactSpan'")]
        public void Contact_CodedStep()
        {
            // Wait for Exists 'ContactSpan'
            Pages.CreationRequestSupplier0.ContactSpan.Wait.ForExists(30000);
            
        }
    
        [CodedStep(@"Verify element 'ContactSpan' 'is' visible.")]
        public void Contact_CodedStep1()
        {
            // Verify element 'ContactSpan' 'is' visible.
            Pages.CreationRequestSupplier0.ContactSpan.Wait.ForExists(30000);
          
            
        }
    
        [CodedStep(@"Verify element 'Contact1Div' 'is' visible.")]
        public void Contact_CodedStep2()
        {
            // Verify element 'Contact1Div' 'is' visible.
            Pages.CreationRequestSupplier0.Contact1Div.Wait.ForExists(30000);
          
            
        }
    
        [CodedStep(@"Verify element 'FunctionLabelTag' 'is' visible.")]
        public void Contact_CodedStep3()
        {
            // Verify element 'FunctionLabelTag' 'is' visible.
            Pages.CreationRequestSupplier0.FunctionLabelTag.Wait.ForExists(30000);
           
            
        }
    
        [CodedStep(@"Wait for element 'ValidateSpan' 'is' visible.")]
        public void Contact_CodedStep4()
        {
            // Wait for element 'ValidateSpan' 'is' visible.
            
            Pages.CreationRequestSupplier4.ValidateSpan.Wait.ForExists(30000);
            
        }
    
        [CodedStep(@"Scroll ContactSpan to top of window.")]
        public void Contact_CodedStep5()
        {
            Thread.Sleep(2000);
            Pages.CreationRequestSupplier0.ContactSpan.ScrollToVisible(ArtOfTest.WebAii.Core.ScrollToVisibleType.ElementTopAtWindowTop);
            
        }
    
        [CodedStep(@"Desktop command: LeftClick on ValidateSpan")]
        public void Contact_CodedStep6()
        {
            // Desktop command: LeftClick on ValidateSpan
            Pages.CreationRequestSupplier4.ValidateSpan.Wait.ForExists(30000);
            Pages.CreationRequestSupplier4.ValidateSpan.ScrollToVisible(ArtOfTest.WebAii.Core.ScrollToVisibleType.ElementCenterAtWindowCenter);
            Pages.CreationRequestSupplier4.ValidateSpan.MouseClick(ArtOfTest.WebAii.Core.MouseClickType.LeftClick, 0, 0, ArtOfTest.Common.OffsetReference.AbsoluteCenter);
             Thread.Sleep(3000);
           
            
        }
    
        [CodedStep(@"Desktop command: LeftClick on SendRequestSpan")]
        public void Contact_CodedStep7()
        {
            // Desktop command: LeftClick on SendRequestSpan
            Pages.CreationRequestSupplier0.SendRequestSpan.Wait.ForExists(30000);
            Pages.CreationRequestSupplier0.SendRequestSpan.ScrollToVisible(ArtOfTest.WebAii.Core.ScrollToVisibleType.ElementCenterAtWindowCenter);
            Pages.CreationRequestSupplier0.SendRequestSpan.MouseClick(ArtOfTest.WebAii.Core.MouseClickType.LeftClick, 0, 0, ArtOfTest.Common.OffsetReference.AbsoluteCenter);
              Thread.Sleep(35000);
    //         String js = "document.evaluate(\"//span[@class='K-link']\",document,null,XPathResult.FIRST_ORDERED_NODE_TYPE,null).singleNodeValue";

          
        }
    
        [CodedStep(@"Wait for Exists 'ContactSpan'")]
        public void Contact_CodedStep8()
        {
            // Wait for Exists 'ContactSpan'
            Pages.CreationRequestSupplier0.ContactSpan.Wait.ForExists(30000);
            Thread.Sleep(2000);
           
        }
    }
}
