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

    public class ValidateAccountManager : BaseWebAiiTest
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
    
        [CodedStep(@"Desktop command: LeftClick on Span")]
        public void ValidateAccountManager_CodedStep()
        {
            // Desktop command: LeftClick on Span
         //   Pages.CreationRequestSupplier10.Span.Wait.ForExists(30000);
          //  Pages.CreationRequestSupplier10.Span.ScrollToVisible(ArtOfTest.WebAii.Core.ScrollToVisibleType.ElementCenterAtWindowCenter);
         //   Pages.CreationRequestSupplier10.Span.MouseClick(ArtOfTest.WebAii.Core.MouseClickType.LeftClick, 0, 0, ArtOfTest.Common.OffsetReference.AbsoluteCenter);
             Settings.Current.UnexpectedDialogAction = UnexpectedDialogAction.HandleAndContinue;
            
            try{
              Element element = Find.ByXPath("(//button[@class='k-button k-primary' and contains(text(),'Ok') ])[2]");
            Actions.Click(element);
             Settings.Current.UnexpectedDialogAction = UnexpectedDialogAction.HandleAndContinue;
            Thread.Sleep(2000);
            }
            catch(Exception e){
                Log.WriteLine(e.ToString());
            }
        }
    
        [CodedStep(@"Desktop command: LeftClick on ValidateSpan")]
        public void ValidateAccountManager_CodedStep1()
        {
            // Desktop command: LeftClick on ValidateSpan
             Settings.Current.UnexpectedDialogAction = UnexpectedDialogAction.HandleAndContinue;
            try{
            Pages.CreationRequestSupplier3.ValidateSpan.Wait.ForExists(30000);
         //   Pages.CreationRequestSupplier3.ValidateSpan.ScrollToVisible(ArtOfTest.WebAii.Core.ScrollToVisibleType.ElementCenterAtWindowCenter);
         //   Pages.CreationRequestSupplier3.ValidateSpan.MouseClick(ArtOfTest.WebAii.Core.MouseClickType.LeftClick, 0, 0, ArtOfTest.Common.OffsetReference.AbsoluteCenter);
            Element element = Find.ByXPath("//span[@class='k-link k-menu-link' and contains(text(),'Validate (Account Manager)')]");
            Actions.Click(element);
            }
            catch(Exception e){
                Log.WriteLine(e.ToString());
            }
            Settings.Current.UnexpectedDialogAction = UnexpectedDialogAction.HandleAndContinue;
            
        }
    
        [CodedStep(@"Wait for Exists 'Span'")]
        public void ValidateAccountManager_CodedStep2()
        {
            // Wait for Exists 'Span'
            try {
            Pages.CreationRequestSupplier10.Span.Wait.ForExists(30000);
            }
            catch(Exception e){
                Log.WriteLine(e.ToString());
            }
        }
    }
}
