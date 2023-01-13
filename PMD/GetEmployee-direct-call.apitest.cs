using System;
using Telerik.ApiTesting.Framework;
using Telerik.ApiTesting.Framework.Abstractions;
using PMD.Utilities;
using System.Globalization;
using System.IO;
using APIAutomation;
using Newtonsoft.Json.Linq;
using APIAutomation.Utilities;

namespace PMD
{
	// It is mandatory for each test class to inherit ApiTestBase class as shown below (this is set by default).
    public class GetEmployee_direct_call : ApiTestBase 
    {				
		public void TestMethod()
		{
	       String loop = "";
			
			int rowNumber = Int32.Parse(this.Context.GetValue("row").ToString());
			rowNumber =rowNumber+1;
			this.Context.SetValue("row",rowNumber.ToString());

			loop = this.Context.GetValue("loop").ToString();
			int count  =Int32.Parse(loop); 
			count = count +1;
			this.Context.SetValue("loop", count);

		
		}
		
		
		public void ResultToExcel(){	
		// @Anmol Chaudhary
			string code="";
			string path ="";
			string errors="";
			string row = "";
			string id ="";
			string responseTime="";
			string statusCode="";
			string result ="";
		    string env ="";
		    string vers = "";
		    string fileName = "";
		    string dateandtime = "";			
			//path of file
			path  =  this.Context.GetValue("path").ToString();
		    
		    // name of File
		    fileName = this.Context.GetValue("fileName").ToString();
			
			// calculate row
			//row = this.Context.GetValue("inc").ToString();
	     	 row = this.Context.GetValue("row").ToString();
			
			//calculate id
		//	id = this.Context.GetValue("id").ToString();
			
			// response time of API
			responseTime = this.Context.GetValue("ResponseTime").ToString();
			
			//responseCode of API Hitting
			statusCode = this.Context.GetValue("StatusCode").ToString();
		
		    // environment of test
		    env =  this.Context.GetValue("env").ToString();
		
		    // environment of test
		    vers =  this.Context.GetValue("version").ToString();
		
		    // get date and time of starting test 
		    dateandtime = this.Context.GetValue("dateAndTime").ToString();
			
		    string body = this.Context.GetValue("Body").ToString();
			JObject j = JObject.Parse(body);
			int pou = (Int32)(j.Count);
			this.Log.WriteLine("Number of Tokens in Jason : "+pou.ToString());
			
			// calculate result of API response
			
			try{
			 result = j["Results"][0].ToString();
			}catch(Exception e){
				this.Log.WriteLine("no result");
			}
			
			if(result.Length>0){
				result = "PASS";
			}else 
				result ="FALSE";
			
			try{				
				foreach(JToken token in j.FindTokens("Code")){
					code = code+token.ToString()+Environment.NewLine;				
				}				
				foreach(JToken token in j.FindTokens("Message")){
					errors = errors+token.ToString() + Environment.NewLine;
				}								
		        //	 code = j["Results"][0]["IdPerson"].ToString();				
			 }catch(Exception e){
				this.Log.WriteLine("no value for IdPerson");				
			      }	
			 
			//DataToExcel.createDataExcelFile(path,"salaryApi",row,id,result,responseTime,statusCode,code,errors,env,vers);		
		   CreateCSV.addrecord(row,"",result,responseTime,statusCode,code,errors,env,vers,"avg","max","min","mode","min",path.ToString()+fileName.ToString()+dateandtime+".csv");
			this.Log.WriteLine(errors);			
		}
		
		public override void OnBeforeTestStarted()
	// @Anmol chaudhary
			{
			 string dateandtime = "";
			 string value="";
			 string path="";
			 string fileName="";
			 string env ="";
		     string vers = "";
			 string loopvalue="";
			 string url = "";
   			 this.Log.WriteLine("The test case is starting ...");
			 this.Log.WriteLine("Create Excel Result File");
			 path  =  this.Context.GetValue("path").ToString();	
			 // name of File
		    fileName = this.Context.GetValue("fileName").ToString();
		//	CreateExcel.createExcel("salaryApi" ,path.ToString());
				
				dateandtime  = DateTime.Now.ToString("_ddMMyyyy_hh_mm_ss");
				this.Log.WriteLine("Time of starting Test :: "+dateandtime);
				this.Context.SetValue("dateAndTime",dateandtime);
				this.Log.WriteLine("URL :: "+this.Context.GetValue("base-url-direct"));
				this.Log.WriteLine("loop-value :: "+this.Context.GetValue("loop-value"));
				
		// File Handling.		
				try{
					if(File.Exists(path.ToString()+fileName.ToString())){
						File.Delete(path.ToString()+fileName.ToString());
					} else {
						this.Log.WriteLine("File Not Find");
					}
				}catch(Exception e){
					this.Log.WriteLine("Regarding file :: " +e.Message.ToString());
				}
			
		    CreateCSV.addrecord("SERIAL NUMBER","ID","RESULT","RESPONSE TIME","STATUS CODE","ERROR CODE","ERROR MESSAGE","ENVIRONMENT","VERSION","AverageResponseOfID","MaximumDuration","MinimunDuration","Mode","Median",path.ToString()+fileName.ToString()+dateandtime+".csv");
			}
		
		
		public override void OnAfterTestCompleted()
		{
			
		//	string value ="";
		//	string path = "";
			
			 string path="";
			 string fileName="";
		   	 string dateandtime="";
			 string responseArray=""; 
			 string exitDateAndTime = "";
			 
			 path  =  this.Context.GetValue("path").ToString();	
		 // name of File
		    fileName = this.Context.GetValue("fileName").ToString();
	   	//	CreateExcel.createExcel("salaryApi" ,path.ToString());
		    dateandtime = this.Context.GetValue("dateAndTime").ToString();
		// Date and time for the final data
	        exitDateAndTime = DateTime.Now.ToString("_ddMMyyyy_hh_mm_ss");	
			responseArray = this.Context.GetValue("responseArray").ToString();
			this.Log.WriteLine(responseArray);
			
		    this.Log.WriteLine("Ending the test case ...");
		//	CreateCSV.addrecord(" "," "," ", " "," "," ", " "," "," ",Function.average(responseArray).ToString(),Function.maximumDuration(responseArray).ToString(),Function.minimumDuration(responseArray).ToString(),PMD.Utilities.Function.mode(responseArray).ToString(),Function.median(responseArray).ToString(),path.ToString()+fileName.ToString()+dateandtime+".csv");
			CreateCSV.createCSV(path.ToString()+fileName.ToString()+exitDateAndTime+".csv",path.ToString()+fileName.ToString()+dateandtime+".csv",Function.average(responseArray).ToString(),Function.maximumDuration(responseArray).ToString(),Function.minimumDuration(responseArray).ToString(),PMD.Utilities.Function.mode(responseArray).ToString(),Function.median(responseArray).ToString());
			CreateCSV.deleteCSV(path.ToString()+fileName.ToString()+dateandtime+".csv");
		}
	}
}