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

    public class SelectPerfTestId : BaseWebAiiTest
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
    
        [CodedStep(@"Verify 'TextContent' 'Contains' 'PERFTEST (10677)' on 'PERFTESTLink'")]
        public void SelectPerfTestId_CodedStep()
        {
            // Verify 'TextContent' 'Contains' 'PERFTEST (10677)' on 'PERFTESTLink'
            Pages.RequestsSupplierMaster0.PERFTESTLink.AssertContent().TextContent(ArtOfTest.Common.StringCompareType.Contains, "PERFTEST (10677)");
            
        }
    
        [CodedStep(@"KendoGrid: [0, 0]Cell text 'Exact' 'PERFTEST (10677)'")]
        public void SelectPerfTestId_CodedStep1()
        {
            // KendoGrid: [0, 0]Cell text 'Exact' 'PERFTEST (10677)'
            Pages.RequestsSupplierMaster0.TableCell.ControlAssert().StringValue("CellText", "PERFTEST (10677)", ArtOfTest.Common.StringCompareType.Exact);
            
        }
    
        [CodedStep(@"Desktop command: LeftClick on MyCreationRequestsGridDiv")]
        public void SelectPerfTestId_CodedStep2()
        {
            // Desktop command: LeftClick on MyCreationRequestsGridDiv
            Pages.RequestsSupplierMaster0.MyCreationRequestsGridDiv.Wait.ForExists(30000);
            Pages.RequestsSupplierMaster0.MyCreationRequestsGridDiv.ScrollToVisible(ArtOfTest.WebAii.Core.ScrollToVisibleType.ElementCenterAtWindowCenter);
            Pages.RequestsSupplierMaster0.MyCreationRequestsGridDiv.MouseClick(ArtOfTest.WebAii.Core.MouseClickType.LeftClick, 0, 0, ArtOfTest.Common.OffsetReference.AbsoluteCenter);
            
        }
    
        [CodedStep(@"Click 'Ae8fb71795bd4f229177C37f67f69057Span'")]
        public void SelectPerfTestId_CodedStep3()
        {
            // Click 'Ae8fb71795bd4f229177C37f67f69057Span0'
            Pages.CreationRequestSupplier1.Ae8fb71795bd4f229177C37f67f69057Span0.Click(false);
            
        }
    }
}
