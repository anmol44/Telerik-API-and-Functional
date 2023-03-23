using System;
using Telerik.ApiTesting.Framework;
using Telerik.ApiTesting.Framework.Abstractions;
using APIAutomation.Utilities;
using Newtonsoft.Json.Linq;

using PMD.Utilities;
using System.Globalization;
using System.IO;

namespace APIAutomation
{
	// It is mandatory for each test class to inherit ApiTestBase class as shown below (this is set by default).
    public class SalaryCostApi : ApiTestBase
    {				
	public void TestMethod()
		{
		  //	String[] lastnames ={"26424", "30730","216565", "102891", "59260", "255966", "112142", "112174", "112396", "176447", "129877", "174711", "179106", "135231", "189384", "276466", "210490", "233334", "236829", "257356"};	
		   // int length = lastnames.GetLength(0);
			string idData = "";
		//	int loopTest = 3000;
		//	int arrayLength = lastnames.GetLength(0);
		//	this.Context.SetValue("length",loopTest.ToString());
			int rowNumber = Int32.Parse(this.Context.GetValue("row").ToString());
			
			
		//	int loop = Int32.Parse(this.Context.GetValue("inc").ToString());
		//	if(loop%arrayLength==0){
		//		this.Context.SetValue("inc",0);
		//		loop = Int32.Parse(this.Context.GetValue("inc").ToString());
		//	}
			
			idData = this.Context.GetValue("idData").ToString();
			this.Log.WriteLine(Function.getIDFromString(idData.TrimEnd(' '),rowNumber));
			string lm = Function.getIDFromString(idData.TrimEnd(' '),rowNumber);
			rowNumber =rowNumber+1;
			this.Context.SetValue("row",rowNumber.ToString());
		//	string lm = Function.getIDFromString(idData.TrimEnd(' '),rowNumber);
		//	String lm = lastnames[loop];
		//	loop=loop+1;
		//	this.Context.SetValue("inc",loop.ToString());
			this.Context.SetValue("id",lm);
			//this.Log.WriteLine("Print loop " +lm);
		//	this.Log.WriteLine(this.Context.GetValue("id").ToString());
		//	var e = this.Context.GetValue("env");
		//	this.Log.WriteLine("Print environment " +e);
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
			id = this.Context.GetValue("id").ToString();
			
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
					code = code+token.ToString()+" ";				
				}				
				foreach(JToken token in j.FindTokens("Message")){
					errors = errors+token.ToString() + " ";
				}								
		        //	 code = j["Results"][0]["IdPerson"].ToString();				
			 }catch(Exception e){
				this.Log.WriteLine("no value for IdPerson");				
			      }	
			 char[] separater = {' '};
			 code = code.TrimEnd(separater);
			 errors = errors.TrimEnd(separater);
			 
			//DataToExcel.createDataExcelFile(path,"salaryApi",row,id,result,responseTime,statusCode,code,errors,env,vers);		
		   CreateCSV.addrecord(row,id,result,responseTime,statusCode,code,errors,env,vers,"","","","","",path.ToString()+fileName.ToString()+dateandtime+".csv");	
			 ResponseTime();
		}
		
		
	public  void  ResponseTime()
		{
			string rt ="";
			string responseArray = "";
		    rt = this.Context.GetValue("ResponseTime").ToString();
			this.Log.WriteLine(rt);
			responseArray = this.Context.GetValue("responseArray").ToString();
			responseArray = Function.appendString(responseArray,rt).ToString();
			
			this.Context.SetValue("responseArray",responseArray);
		}
		
		
	// This method will execute before the start of the test case
	public override void OnBeforeTestStarted()
	// @Anmol chaudhary
			{
			 string dateandtime = "";
			 string value="";
			 string path="";
			 string fileName="";
			 string testPath="";
			 string testFile = "";
			 string idData = ""; 
   			 this.Log.WriteLine("The test case is starting ...");
			 this.Log.WriteLine("Create Excel Result File");
			 path  =  this.Context.GetValue("path").ToString();	
			 testPath  =  this.Context.GetValue("testPath").ToString();	
			 testFile = this.Context.GetValue("testFile").ToString();	
			 // name of File
		    fileName = this.Context.GetValue("fileName").ToString();
		//	CreateExcel.createExcel("salaryApi" ,path.ToString());
				
				dateandtime  = DateTime.Now.ToString("_ddMMyyyy_hh_mm_ss");
				this.Log.WriteLine("Time of starting Test :: "+dateandtime);
				this.Context.SetValue("dateAndTime",dateandtime);
				
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
			try{	
			this.Context.SetValue("idData",CreateCSV.getCSV(testPath.ToString()+testFile.ToString()+".csv").ToString());
				this.Context.SetValue("loop-value",Function.getSizeOfIDs(this.Context.GetValue("idData").ToString().TrimEnd(' ')));
				this.Log.WriteLine("ID Data imported to idData variable in String format");
			}catch(Exception e){
				this.Log.WriteLine("Get CSV :: "+ e.Message.ToString());
			}
		    CreateCSV.addrecord("SERIAL NUMBER","ID","RESULT","RESPONSE TIME","STATUS CODE","ERROR CODE","ERROR MESSAGE","ENVIRONMENT","VERSION","AverageResponseOfID","MaximumDuration","MinimunDuration","Mode","Median",path.ToString()+fileName.ToString()+dateandtime+".csv");
			}

// This method will execute after all test steps in the test case have ended
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
		    this.Log.WriteLine("Ending the test case ...");
		//	this.Log.WriteLine(responseArray+"ANMOL");
		//	CreateCSV.addrecord(" "," "," ", " "," "," ", " "," "," ",Function.average(responseArray).ToString(),Function.maximumDuration(responseArray).ToString(),Function.minimumDuration(responseArray).ToString(),PMD.Utilities.Function.mode(responseArray).ToString(),Function.median(responseArray).ToString(),path.ToString()+fileName.ToString()+dateandtime+".csv");
			CreateCSV.createCSV(path.ToString()+fileName.ToString()+exitDateAndTime+".csv",path.ToString()+fileName.ToString()+dateandtime+".csv",Function.average(responseArray).ToString(),Function.maximumDuration(responseArray).ToString(),Function.minimumDuration(responseArray).ToString(),PMD.Utilities.Function.mode(responseArray).ToString(),Function.median(responseArray).ToString());
		//	this.Log.WriteLine("Anmol");
			CreateCSV.deleteCSV(path.ToString()+fileName.ToString()+dateandtime+".csv");
		//	this.Count();
		//	this.responseTime();	
		//	path  =  this.Context.GetValue("path").ToString();	
		//	DataToExcel.createDataExcelFile(path,"salaryApi","1","12","fafasfs","hhhiii");
		}
	}
	
}