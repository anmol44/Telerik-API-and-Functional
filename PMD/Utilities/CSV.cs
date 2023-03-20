using System;
using System.IO;
using Telerik.ApiTesting.Framework;
using Telerik.ApiTesting.Framework.Abstractions;
using PMD.Utilities;
	

namespace PMD.Utilities
{
     public class CreateCSV
    {
				public static void addrecord(string SrNumber,string Id, string Result, string ResponseTime, string StatusCode, string ErrorCode, string ErrorMessage, string Environment, string Version, string AverageResponseID, string MaximumDuration, string MinimunDuration, string Mode, string Median,  string path){
					try{
						
						using(System.IO.StreamWriter file= new System.IO.StreamWriter(path,true)){
							//file.WriteLine(SrNumber+","+Id+","+Result+","+ResponseTime+","+StatusCode+","+"\""+ErrorCode+"\""+","+"\""+ErrorMessage+"\""+","+Environment+","+Version);
							file.WriteLine(SrNumber+","+Id+","+Result+","+ResponseTime+","+StatusCode+","+"\""+ErrorCode+"\""+","+"\""+ErrorMessage+"\""+","+Environment+","+Version+","+" "+","+" "+","+AverageResponseID+","+""+MaximumDuration+","+""+MinimunDuration+","+""+Mode+","+""+Median);
							
						}
						
					}
					catch(Exception e){
						
						throw new ApplicationException("This file has some problem : " +e.ToString());
					}
				}
				
				public static void  deleteCSV(string path){
					File.Delete(path);
				}
				
				public static string createCSV(string finalPath, string initailPath,string average, string maxDuration, string minDuration, string mode, string median){
					StreamReader sr = new StreamReader(initailPath,true);
					StreamWriter sw = new StreamWriter(finalPath ,true);
					string actualString = "" ;
					string str = "" ;
					string[] st ;
					char[] seperator = {','};
				    actualString = sr.ReadLine();
					str = sr.ReadLine();
					st = str.Split(seperator);
					//Console.WriteLine(st.Length.ToString());
					//Console.WriteLine(str);
					//Console.WriteLine(sr.Read());
					st[11] = average;
					st[12] = maxDuration;
					st[13] = minDuration;
					st[14] = mode;
					st[15] = median;
					str="";
					Console.WriteLine(st.Length);
					for(int i=0;i<st.Length;i++){
						str =str + st[i]+",";
					}
					try{
					sw.WriteLine(actualString);
					sw.WriteLine(str);
					}
					catch(Exception e){
						Console.Write(e.Message.ToString());
					}
					
					while(str!=null){
						str = sr.ReadLine();
						sw.WriteLine(str);
					}
					sr.Dispose();
					sw.Dispose();
					actualString = actualString+str;
					return actualString;
				}
				
				public static string getCSV(string path){
					string str = "";
					string id = "";
					string consisitID = "";
					StreamReader sr = new StreamReader(path,true);
					str=sr.ReadLine().ToString();
					while(str!=null){
						
						str =  sr.ReadLine();
						if(str ==null)return id; 
					   consisitID = Function.stringArray(str,0).ToString();
						
						id= id+consisitID+" ";
						
					}
					sr.Dispose();
					
					return id;
				}
	}
}