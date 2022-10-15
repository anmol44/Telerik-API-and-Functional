using System;
using Telerik.ApiTesting.Framework;
using Telerik.ApiTesting.Framework.Abstractions;

namespace PMD.Utilities
{
     public class CreateCSV
    {
				public static void addrecord(string SrNumber,string Id, string Result, string ResponseTime, string StatusCode, string ErrorCode, string ErrorMessage, string Environment, string Version, string path){
					try{
						
						using(System.IO.StreamWriter file= new System.IO.StreamWriter(path,true)){
							file.WriteLine(SrNumber+","+Id+","+Result+","+ResponseTime+","+StatusCode+","+"\""+ErrorCode+"\""+","+"\""+ErrorMessage+"\""+","+Environment+","+Version);
						}
						
					}
					catch(Exception e){
						
						throw new ApplicationException("This file has some problem : " +e.ToString());
					}
				}
	}
}