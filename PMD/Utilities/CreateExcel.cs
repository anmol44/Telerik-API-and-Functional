using System;
using Telerik.ApiTesting.Framework;
using Telerik.ApiTesting.Framework.Abstractions;
using GemBox.Spreadsheet;

namespace APIAutomation.Utilities
{
    public static class CreateExcel
    {
		public static void createExcel(string sheetName ,string path){
		    string id ;
			
			if(sheetName.Equals("salaryApi")){
				id= "salaryCost Api";
			}else 
				id = "createEmployee Api";
			 SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
			//create Workbook for create worksheet with sheet name .
		       var workbook = new ExcelFile();
    	       var worksheet = workbook.Worksheets.Add(sheetName);
			
			//edit format of excel Heading 
			  worksheet.Rows[0].Style = workbook.Styles[BuiltInCellStyleName.Heading1];
     	      worksheet.Columns[0].Width = 35 * 256;
      		  worksheet.Columns[2].Width = 35 * 256;
			  worksheet.Columns[4].Width = 35 * 256;
			  worksheet.Columns[6].Width = 35 * 256;
			  worksheet.Columns[8].Width = 35 * 256;
		      worksheet.Columns[10].Width = 35 * 256;
			  worksheet.Columns[12].Width = 35 * 256;
			  worksheet.Columns[14].Width = 35 * 256;
			  worksheet.Columns[16].Width = 35 * 256; 
			
			
			  worksheet.Cells[0, 0].Value = "SR NUMBER";
			  worksheet.Cells[0, 0].Style.Font.Color = SpreadsheetColor.FromName(ColorName.Blue);
			
			if(id.Equals("salaryCost Api"))  { 				
			  worksheet.Cells[0, 2].Value = "ID";
			  worksheet.Cells[0, 2].Style.Font.Color = SpreadsheetColor.FromName(ColorName.Blue);
			}else {
              worksheet.Cells[0, 2].Value = "LASTNAME";
			  worksheet.Cells[0, 2].Style.Font.Color = SpreadsheetColor.FromName(ColorName.Blue);				  				
			}              
				
              worksheet.Cells[0, 4].Value = "RESULT";
			  worksheet.Cells[0, 4].Style.Font.Color = SpreadsheetColor.FromName(ColorName.Blue);
				
			  worksheet.Cells[0, 6].Value = "RESPONSE TIME";
			  worksheet.Cells[0, 6].Style.Font.Color = SpreadsheetColor.FromName(ColorName.Blue); 
				
			  worksheet.Cells[0, 8].Value = "STATUS CODE";
			  worksheet.Cells[0, 8].Style.Font.Color = SpreadsheetColor.FromName(ColorName.Blue);
				
			  worksheet.Cells[0, 10].Value = "ERROR CODE";
			  worksheet.Cells[0, 10].Style.Font.Color = SpreadsheetColor.FromName(ColorName.Blue);     	
              
			  worksheet.Cells[0, 12].Value = "ERROR MESSAGE";
			  worksheet.Cells[0, 12].Style.Font.Color = SpreadsheetColor.FromName(ColorName.Blue);
				
              worksheet.Cells[0, 14].Value = "ENVIRONMENT";
			  worksheet.Cells[0, 14].Style.Font.Color = SpreadsheetColor.FromName(ColorName.Blue); 
			
			  worksheet.Cells[0, 16].Value = "VERSION";
			  worksheet.Cells[0, 16].Style.Font.Color = SpreadsheetColor.FromName(ColorName.Blue);   	

			
		
				
			// worksheet.Cells[1, 0].Value = IdValue;			
            // Console.WriteLine( "Rows  "+   worksheet.Rows.Count.ToString());
            // Save to XLSX file.
			
            workbook.Save(path+"\\"+sheetName+".xlsx");
		}
				
	}
}