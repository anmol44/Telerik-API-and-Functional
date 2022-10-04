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
using ArtOfTest.WebAii.Win32.Dialogs;
using System.Threading;

namespace new_test_project
{

    public class SupplierSite : BaseWebAiiTest
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
        
           public  String supplierIdGenerator(){
                               
            String supplierSiteId = "097280234";
            int id=Int32.Parse(GetExtractedValue("increament").ToString());
            String increamentedId = supplierSiteId+id.ToString();
            SetExtractedValue("increament",id+1);                    
            return increamentedId;
        }
    
        [CodedStep(@"Desktop command: LeftClick on CreationSpan")]
        public void SupplierSite_CodedStep()
        {
            // Desktop command: LeftClick on CreationSpan
            Pages.RequestsSupplierMaster.CreationSpan.Wait.ForExists(30000);
            Pages.RequestsSupplierMaster.CreationSpan.ScrollToVisible(ArtOfTest.WebAii.Core.ScrollToVisibleType.ElementCenterAtWindowCenter);
            Pages.RequestsSupplierMaster.CreationSpan.MouseClick(ArtOfTest.WebAii.Core.MouseClickType.LeftClick, 0, 0, ArtOfTest.Common.OffsetReference.AbsoluteCenter);
            
                        // Add an alert dialog to monitor
            Manager.DialogMonitor.AddDialog(new AlertDialog(ActiveBrowser, DialogButton.OK));

            // Given that there were not dialog attribute set, the manager will not start the monitoring.
            // You need to invoke the monitoring
            Manager.DialogMonitor.Start();
        }
    
        [CodedStep(@"Enter text '092334354365' in 'EstablishmentIdentifierText'")]
        public void SupplierSite_CodedStep1()
        {
            // Enter text '092334354365' in 'EstablishmentIdentifierText'
            String supplier = supplierIdGenerator().ToString();
            Element element = Find.ByXPath("//input[@id='EstablishmentIdentifier' or @placeholder='Supplier site identifier']");
            Actions.SetText(element, supplier);
             Log.WriteLine(supplier);
            
        }
    
        [CodedStep(@"Desktop command: LeftClick on AccountFile0Hidden")]
        public void SupplierSite_CodedStep2()
        {
            // Desktop command: LeftClick on AccountFile0Hidden
            Pages.CreationRequestSupplier0.AccountFile0Hidden.Wait.ForExists(30000);
            Pages.CreationRequestSupplier0.AccountFile0Hidden.ScrollToVisible(ArtOfTest.WebAii.Core.ScrollToVisibleType.ElementCenterAtWindowCenter);
            Pages.CreationRequestSupplier0.AccountFile0Hidden.MouseClick(ArtOfTest.WebAii.Core.MouseClickType.LeftClick, 0, 0, ArtOfTest.Common.OffsetReference.AbsoluteCenter);
            Thread.Sleep(5000);
        }
    
        [CodedStep(@"Enter text '5456477879' in 'EstablishmentIdentifierText'")]
        public void SupplierSite_CodedStep3()
        {
            // Enter text '5456477879' in 'EstablishmentIdentifierText'
            Actions.SetText(Pages.CreationRequestSupplier0.EstablishmentIdentifierText, "5456477879");
            
        }
    
        [CodedStep(@"KendoTab: 'Supplier site' click action.")]
        public void SupplierSite_CodedStep4()
        {
            // KendoTab: 'Supplier site' click action.
            Pages.CreationRequestSupplier0.Tab1ListItem.Click();
            
        }
    
        [CodedStep(@"Desktop command: LeftClick on Div")]
        public void SupplierSite_CodedStep5()
        {
            // Desktop command: LeftClick on Div2
          
            Pages.CreationRequestSupplier0.Div.ScrollToVisible(ArtOfTest.WebAii.Core.ScrollToVisibleType.ElementCenterAtWindowCenter);
            Pages.CreationRequestSupplier0.Div.MouseClick(ArtOfTest.WebAii.Core.MouseClickType.LeftClick, 0, 0, ArtOfTest.Common.OffsetReference.AbsoluteCenter);
            
        }
    
        [CodedStep(@"KendoTab: 'Supplier site' click action.")]
        public void SupplierSite_CodedStep6()
        {
            // KendoTab: 'Supplier site' click action.
            Pages.CreationRequestSupplier0.Tab1ListItem.Click();
            
        }
    
        [CodedStep(@"Wait for Exists 'SupplierSiteSpan'")]
        public void SupplierSite_CodedStep7()
        {
            // Wait for Exists 'SupplierSiteSpan'
            Pages.CreationRequestSupplier0.SupplierSiteSpan.Wait.ForExists(30000);
            
        }
    
        [CodedStep(@"Verify element 'SupplierSiteSpan' 'is' visible.")]
        public void SupplierSite_CodedStep8()
        {
            // Verify element 'SupplierSiteSpan' 'is' visible.
            Element element=  Find.ByXPath("(//span[@class='k-link'])[1]");          
            Actions.Click(element);
  
            
        }
    
        [CodedStep(@"Desktop command: LeftClick on SendRequestSpan0")]
        public void SupplierSite_CodedStep9()
        {
            // Desktop command: LeftClick on SendRequestSpan0
          //  Pages.CreationRequestSupplier0.SendRequestSpan0.Wait.ForExists(30000);
          //  Pages.CreationRequestSupplier0.SendRequestSpan0.ScrollToVisible(ArtOfTest.WebAii.Core.ScrollToVisibleType.ElementCenterAtWindowCenter);
          //  Pages.CreationRequestSupplier0.SendRequestSpan0.MouseClick(ArtOfTest.WebAii.Core.MouseClickType.LeftClick, 0, 0, ArtOfTest.Common.OffsetReference.AbsoluteCenter);
            
            Element element =  Find.ByXPath("//span[@class='k-link k-menu-link' and contains(text(),'Send request')]");
            Actions.Click(element);
        }
    }
}
