using System;
using System.Xml;
using System.Collections.Generic;

namespace dotnet_code_challenge
{
    public class XmlParser
    {
        public Dictionary<string, decimal> Parse(string xml)
        {
			// parse XML, return dictionary {horse, price}
			var prices = new Dictionary<string, decimal>(){};
			var numbers = new Dictionary<Int32, string>(){};
			string name;
			Int32 number;
			decimal price;
			try 
			{
				XmlDocument document = new XmlDocument();
				document.LoadXml(xml);
				XmlNodeList racesXml = document.DocumentElement.SelectNodes("/meeting/races/race");
				XmlNodeList horsesXml, pricesXml;
				foreach (XmlNode race in racesXml)
				{
					horsesXml = race.SelectNodes("//horses/horse");
					foreach (XmlNode horse in horsesXml)
					{
						if (horse.Attributes["name"] != null) 
						{
							name = horse.Attributes["name"].Value;
							number = Int32.Parse(horse.SelectSingleNode("number").InnerText);
							numbers.Add(number, name);
						}
					}
					pricesXml = race.SelectNodes("//prices/price/horses/horse");
					foreach (XmlNode priceXml in pricesXml)
					{
						number = Int32.Parse(priceXml.Attributes["number"].Value);
						name = numbers[number];
						price = decimal.Parse(priceXml.Attributes["Price"].Value);
						prices.Add(name, price);
					}
				}
				return prices;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return new Dictionary<string, decimal>(){};				
			}
        }
    }
}