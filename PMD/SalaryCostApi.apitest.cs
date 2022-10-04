using System;
using Telerik.ApiTesting.Framework;
using Telerik.ApiTesting.Framework.Abstractions;
using APIAutomation.Utilities;
using Newtonsoft.Json.Linq;
using GemBox.Spreadsheet;

namespace APIAutomation
{
	// It is mandatory for each test class to inherit ApiTestBase class as shown below (this is set by default).
    public class SalaryCostApi : ApiTestBase
    {				
	public void TestMethod()
		{
			String[] lastnames ={"26424", "30730","33793", "59179", "59260", "60393", "112142", "112174", "112396", "114667", "129877", "174711", "179106", "181411", "189384", "191829", "210490", "233334", "236829", "257356"};	
		    int length = lastnames.GetLength(0);
			this.Context.SetValue("length",length.ToString());
			int loop = Int32.Parse(this.Context.GetValue("inc").ToString());
			String lm = lastnames[loop];
			loop=loop+1;
			this.Context.SetValue("inc",loop.ToString());
			this.Context.SetValue("id",lm);
			//this.Log.WriteLine("Print loop " +lm);
			this.Log.WriteLine(this.Context.GetValue("id").ToString());
			var e = this.Context.GetValue("env");
			this.Log.WriteLine("Print environment " +e);
		}
	
	public void Count()
		  {
		    string json ="";
			string code="";
			string path ="";
		    string body = this.Context.GetValue("Body").ToString();
			JObject j = JObject.Parse(body);
			int pou = (Int32)(j.Count);
			
			try{
			 code = j["Results"][0]["IdPerson"].ToString();
			}catch(Exception e){
				this.Log.WriteLine("no value for IdPerson");
			}
			
            if(code.Length==0){this.Log.WriteLine("NO value present");}
		   
		 	this.Context.SetValue("extractValue",code.ToString());
		   
		    //this.Log.WriteLine(code.ToString());        			
			//this.Log.WriteLine(pou.ToString());
			
		    json =	this.Context.GetValue("json").ToString();
			json =json+body+"\n";
			this.Context.SetValue("json",json);
			this.Log.WriteLine(this.Context.GetValue("json").ToString());
		    path =this.Context.GetValue("path").ToString();			
			System.IO.File.WriteAllText(path +"\\SalaryCostAPIresult.json",json);	
		   
		   ResultToExcel();
		   }
		
	public void ResultToExcel(){	
			string code="";
			string path ="";
			string errors="";
			string row = "";
			string id ="";
			string responseTime="";
			string statusCode="";
			string result ="";
			
			//path of file
			path  =  this.Context.GetValue("path").ToString();
			
			// calculate row
			row = this.Context.GetValue("inc").ToString();
			
			//calculate id
			id = this.Context.GetValue("id").ToString();
			
			// response time of API
			responseTime = this.Context.GetValue("ResponseTime").ToString();
			
			//responseCode of API Hitting
			statusCode = this.Context.GetValue("StatusCode").ToString();
			
		    string body = this.Context.GetValue("Body").ToString();
			JObject j = JObject.Parse(body);
			int pou = (Int32)(j.Count);
			this.Log.WriteLine("Number of Tokens in Jason : "+pou.ToString());
			
			// calculate result of API response
			
			try{
			 result = j["Results"][0]["IdPerson"].ToString();
			}catch(Exception e){
				this.Log.WriteLine("no value for IdPerson");
			}
			
			if(result.Equals(id)){
				result = "PASS";
			}else 
				result ="FALSE";
			
			try{				
				foreach(JToken token in j.FindTokens("Code")){
					code = code+token.ToString()+"\n";					
				}				
				foreach(JToken token in j.FindTokens("Message")){
					errors = errors+token.ToString()+"\n";
				}								
		        //	 code = j["Results"][0]["IdPerson"].ToString();				
			 }catch(Exception e){
				this.Log.WriteLine("no value for IdPerson");				
			      }		
			 
			DataToExcel.createDataExcelFile(path,"salaryApi",row,id,result,responseTime,statusCode,code,errors,"");			
			this.Log.WriteLine(errors);			
		}
		
		
	public void responseTime()
		{
			string rt ="";
		    rt = this.Context.GetValue("ResponseTime").ToString();
			this.Log.WriteLine(rt);
		}
		
		
		// This method will execute before the start of the test case
		public override void OnBeforeTestStarted()
			{
			 string value="";
			 string path="";
   			 this.Log.WriteLine("The test case is starting ...");
			 this.Log.WriteLine("Create Excel Result File");
			 path  =  this.Context.GetValue("path").ToString();	
			CreateExcel.createExcel("salaryApi" ,path.ToString());
			}

// This method will execute after all test steps in the test case have ended
	public override void OnAfterTestCompleted()
		{
			
		//	string value ="";
		//	string path = "";
		    this.Log.WriteLine("Ending the test case ...");
		//	this.Count();
		//	this.responseTime();	
		//	path  =  this.Context.GetValue("path").ToString();	
		//	DataToExcel.createDataExcelFile(path,"salaryApi","1","12","fafasfs","hhhiii");
		}
	}
	
}