using System;
using System.Collections;
using Telerik.ApiTesting.Framework;
using Telerik.ApiTesting.Framework.Abstractions;

namespace  PMD.Utilities
{
    public static class Function
    {
				public static float average(string allResponse){
					float sum = 0;
					float[] array;
					array = stringToArray(allResponse);
				    for(int i=0;i<array.Length;i++){
						sum+=array[i];
					}
					return sum/array.Length;
				} 
				
				
				public static int mode(string allResponse){
					
					char[] seperator = {' '};
					string[] response = allResponse.Split(seperator,StringSplitOptions.RemoveEmptyEntries);
					int length = response.Length;
					int max=0;
					int count=0;
					int mode =0 ;
					for(int i=0;i<length;i++){
						count = 0;
						for(int j=0;j<length;j++){							
							if(Int32.Parse(response[i])==Int32.Parse(response[j])){
								count++;
							}
							if(count>max){
								max=count;
								mode = Int32.Parse(response[i]);
							}	
						}						
					}
					if(max==1){
							return 0;
						}
					return mode;
				}
				
				public static float maximumDuration(string allResponse){
					float[] array;
					float max =0;
					array = stringToArray(allResponse);
					max = array[0];
					for(int i =1 ; i< array.Length; i++){
						if(max<array[i]){
							max = array[i];
						}
					}
					return max;
				}
				
				public static float minimumDuration(string allResponse){
					float[] array;
					float min =0;
					array = stringToArray(allResponse);
					min = array[0];
					for(int i =1 ; i< array.Length; i++){
						if(min>array[i]){
							min = array[i];
						}
					}
					return min;
				}
				
				public static float median(string allResponse){
					float med;
					float[] array;
					array = stringToArray(allResponse);
					int len = array.Length;
					Array.Sort(array);
					if(len%2==0){
						return (array[len/2-1] + array[len/2])/2;
					}else
						return array[len/2];
				}
				
				public static string appendString(string str,string append){
					str = str+" "+append;
					return str;
				}
				
				public static float[] stringToArray(string allResponse){
					char[] seperator = {' '};
					string[] response = allResponse.Split(seperator,StringSplitOptions.RemoveEmptyEntries);
					int length = response.Length;
					float[] array = new float[length];
					for(int i=0 ; i < length ; i++){
						array[i] = float.Parse(response[i]);
					}
					return array;
				}
				
				public static string stringArray(string streamLine, int col){
					char[] separator = {','};
					string[] id = streamLine.Split(separator);
						return id[col];
				}
				
				public static string getIDFromString(string idData, int index){
					char[] separator = {' '};
					string[] ids = idData.Split(separator);
				//	Console.WriteLine("Toatl IDs :: " +ids.Length);
					return ids[index];
				}
				
				public static int getSizeOfIDs(string idData){
					char[] separator = {' '};
					string[] ids = idData.Split(separator);					
					return ids.Length;
				}
				
				public static void averageOfEachID(string id, string allResponse){
					float[] allID;
					float[] responseTime;
					allID = stringToArray(id);
					responseTime = stringToArray(allResponse);
					int length = allID.Length;
					Hashtable ht = new Hashtable();
					allID = stringToArray(id);
					responseTime= stringToArray(allResponse);
					for(int i =0 ; i<length; i++){
						if(ht.ContainsKey(allID[i])){
							ht.Add(allID[i],responseTime[i]);
						}else if(ht.ContainsKey(allID[i])){
							ht.Add(allID[i],ht.Values);
						}
					}
					
				}
	}
}