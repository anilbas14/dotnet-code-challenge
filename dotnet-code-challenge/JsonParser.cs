using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace dotnet_code_challenge
{
    public class JsonParser
    {
        public Dictionary<string, decimal> Parse(string json)
        {
			// parse json, return dictionary (horse, price)
			var horses = new Dictionary<string, decimal>(){};
			string name;
			decimal price;
			try 
			{
				JsonDocument document = JsonDocument.Parse(json);
				foreach (JsonElement element in document.RootElement.GetProperty("RawData").GetProperty("Markets").EnumerateArray())
				{
					foreach (JsonElement element1 in element.GetProperty("Selections").EnumerateArray())
					{
						name = element1.GetProperty("Tags").GetProperty("name").ToString();
						price = element1.GetProperty("Price").GetDecimal();	
						horses.Add (name, price);
					}

				}
				return horses;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return new Dictionary<string, decimal>(){};				
			} 
        }
    }
}