using System;
using Telerik.ApiTesting.Framework;
using Telerik.ApiTesting.Framework.Abstractions;
using GemBox.Spreadsheet;

namespace APIAutomation.Utilities
	// Design by @Anmol chaudhary
{
    public class DataToExcel
    {
		public static void createDataExcelFile(string path, string fileName, string row, string id,
			                                       string result ,string responseTime, 
			                                       string statusCode, string  errorCode,
			                                       string errorMessage, string Environment ){
				 
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
			 	var workbook =  ExcelFile.Load(path+"\\"+fileName+".xlsx");
				
			    var worksheet = workbook.Worksheets[0];
			    int r = Int32.Parse(row);
				
				worksheet.Cells[r,0].Value = r;	
			    worksheet.Cells[r,2].Value = id;	
				worksheet.Cells[r,4].Value = result;
			    if(result=="FALSE"){
					worksheet.Cells[r,4].Style.FillPattern.SetSolid(SpreadsheetColor.FromName(ColorName.Accent6Lighter60Pct));
				}else worksheet.Cells[r,4].Style.FillPattern.SetSolid(SpreadsheetColor.FromName(ColorName.Background2));
				worksheet.Cells[r,6].Value = responseTime;
				worksheet.Cells[r,8].Value = statusCode;
				worksheet.Cells[r,10].Value = errorCode;
				worksheet.Cells[r,12].Value = errorMessage;
				worksheet.Cells[r,14].Value = Environment;
					
				workbook.Save(path+"\\"+fileName+".xlsx");	
				
				   }
	}
}