using System;
using Telerik.ApiTesting.Framework;
using Telerik.ApiTesting.Framework.Abstractions;
using APIAutomation.Utilities;
using Newtonsoft.Json.Linq;
using GemBox.Spreadsheet;

namespace APIAutomation
{
	// It is mandatory for each test class to inherit ApiTestBase class as shown below (this is set by default).
    public class CreateEmployeeApi : ApiTestBase
    {				
		public void TestMethod()
		{
		    String[] lastnames ={   "leorek","Antku", "PPLjkiu","chang","Jangri","tappu",
				                   "ktriya","ANtriya","TeerKn","tappu8","JKS","Antukru",
				                   "Bujiya","tink8k","duplicate","luckky",
			                       "Anmolll","prach","chipstwiohfwuifwh","qauartxsd","1bvjhfse"};	
		    int length = lastnames.GetLength(0);
			this.Context.SetValue("length",length.ToString());
			int loop = Int32.Parse(this.Context.GetValue("inc").ToString());
			String lm = lastnames[loop];
			loop=loop+1;
			this.Context.SetValue("inc",loop.ToString());
			this.Context.SetValue("lastname",lm);
			var e = this.Context.GetValue("env1");			
			this.Log.WriteLine("LastName "+this.Context.GetValue("lastname").ToString() + " with environment "+e);			
		}
		
		public void Print(){
			
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
			System.IO.File.WriteAllText(path +"\\CreateEmployeeAPIresult.json",json);	
		   
		   ResultToExcel();
		}
		
			
		public void ResultToExcel(){	
			string code="";
			string path ="";
			string errors="";
			string error="";
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
			id = this.Context.GetValue("lastname").ToString();
			
			// response time of API
			responseTime = this.Context.GetValue("ResponseTime").ToString();
			
			//responseCode of API Hitting
			statusCode = this.Context.GetValue("StatusCode").ToString();
			
		    string body = this.Context.GetValue("Body").ToString();
			JObject j = JObject.Parse(body);
			int pou = (Int32)(j.Count);
			this.Log.WriteLine("Number of Tokens in Jason : "+pou.ToString());
			
			//calculate error array
			try{
				error = j["Errors"][0].ToString();
			}catch(Exception e){
				this.Log.WriteLine("no errors found for : "+id.ToUpper());
			}
			
			// calculate result of API response
			try{
			 result = j["Results"][0]["Person"]["PersonSummary"]["LastName"].ToString();
			}catch(Exception e){
				this.Log.WriteLine("no value for IdPerson");
			}
			
			if(result.Equals(id.ToUpper())){
				result = "PASS";
			}else 
				result ="FALSE";
			if(error.Length!=0){		
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
			 }
			if(string.IsNullOrWhiteSpace(code)){
				code="null";
			}
			 
			DataToExcel.createDataExcelFile(path,"CreateEmployeeAPI",row,id,result,responseTime,statusCode,code,errors,"");			
			this.Log.WriteLine(errors);			
		}
		
		public void responseTime()
		{
		   var rt = this.Context.GetValue("ResponseTime");
			this.Log.WriteLine(rt.ToString());
		}
		
		// This method will execute before the start of the test case
		public override void OnBeforeTestStarted()
			{
			 string value="";
			 string path="";
   			 this.Log.WriteLine("The test case is starting ...");
			 this.Log.WriteLine("Create Excel Result File");
			 path  =  this.Context.GetValue("path").ToString();	
			CreateExcel.createExcel("CreateEmployeeAPI" ,path.ToString());
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