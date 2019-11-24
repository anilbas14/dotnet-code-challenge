using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
			var horses = new Dictionary<string, decimal>();
						
			foreach (string file in Directory.EnumerateFiles("./FeedData", "*.json"))
			{
				FileReader fr = new FileReader();			
				var text = fr.ReadFile(file);
				//parse json
				//align horse names with prices	
				JsonParser jp = new JsonParser();
				var horsesAdd = jp.Parse(text);
				// merge horsesAdd with horses
				horsesAdd.ToList().ForEach(x => horses[x.Key] = x.Value);
			}
			foreach (string file in Directory.EnumerateFiles("./FeedData", "*.xml"))
			{
				FileReader fr = new FileReader();			
				var text = fr.ReadFile(file);
				//parse xml
				//align horse names with prices
				XmlParser xp = new XmlParser();
				var horsesAdd = xp.Parse(text);
				horsesAdd.ToList().ForEach(x => horses[x.Key] = x.Value);				
			} 

			//sort horses in price ascending order
			DictionarySorter ds = new DictionarySorter();
			horses = ds.Sort(horses);
				
			Console.WriteLine("Horse names in price ascending order:");
			 foreach (KeyValuePair<string, decimal> item in horses){
				Console.WriteLine(item.Key);
			} 			

        }
    }
}
