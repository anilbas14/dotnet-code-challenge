using System;
using Xunit;
using System.Collections.Generic;

namespace dotnet_code_challenge.Test
{
    public class XmlParser_ParseShould
    {
		private readonly XmlParser _xp;
		
		string xml = 
		"<?xml version=\"1.0\"?>"+
		"<meeting xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">"+
		"  <races>"+
		"    <race number=\"1\" name=\"Evergreen Turf Plate\" id=\"1536514\" Status=\"OPEN\">"+
		"      <horses>"+
		"        <horse name=\"Horse3\">"+
		"          <number>1</number>"+
		"        </horse>"+
		"        <horse name=\"Horse4\" >"+
		"          <number>2</number>"+
		"        </horse>"+
		"      </horses>"+
		"      <prices>"+
		"        <price>"+
		"         <horses>"+
		"            <horse number=\"1\" Price=\"7.5\"/>"+
		"            <horse number=\"2\" Price=\"8.7\"/>"+
		"          </horses>"+
		"        </price>"+
		"      </prices>"+
		"    </race>"+
		"  </races>"+
		"</meeting>";

		public XmlParser_ParseShould()
		{
			_xp = new XmlParser();
		}
        [Fact]
        public void Parse_EmptyStringInput_ReturnsEmptyDictionary()
        {
			var result = _xp.Parse("");			
			Assert.Equal(new Dictionary<string, decimal>(){}, result);
			
        }
		
		[Fact]
        public void Parse_Xml_ReturnsCorrectDictionary()
        {
			var result = _xp.Parse(xml);
            var correctresult = new Dictionary<string, decimal>(){};
			correctresult.Add("Horse3", (decimal)7.5);
			correctresult.Add("Horse4", (decimal)8.7);			
			Assert.Equal(correctresult, result);
			
        }
		
    }
}
