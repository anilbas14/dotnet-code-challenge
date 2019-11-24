using System;
using Xunit;
using System.Collections.Generic;

namespace dotnet_code_challenge.Test
{
    public class JsonParser_ParseShould
    {
		private readonly JsonParser _jp;
		
		string json = 
		"{\n"+
		"  \"RawData\": {\n"+
		"    \"Markets\": [\n"+
		"     {\n"+
		"        \"Selections\": [\n"+
		"          {\n"+
		"            \"Price\": 8.4,\n"+
		"            \"Tags\": {\n"+
		"             \"name\": \"Horse1\"\n"+
		"            }\n"+
		"          },\n"+
		"          {\n"+
		"            \"Price\": 7.6,\n"+
		"            \"Tags\": {\n"+
		"              \"name\": \"Horse2\"\n"+
		"            }\n"+
		"          }\n"+
		"        ]\n"+
		"	  }\n"+
		"	]\n"+
		"  }\n"+
		"}";
		public JsonParser_ParseShould()
		{
			_jp = new JsonParser();
		}
        [Fact]
        public void Parse_EmptyStringInput_ReturnsEmptyDictionary()
        {
			var result = _jp.Parse("");			
			Assert.Equal(new Dictionary<string, decimal>(){}, result);
			
        }
		
		[Fact]
        public void Parse_Json_ReturnsCorrectDictionary()
        {
			var result = _jp.Parse(json);
            var correctresult = new Dictionary<string, decimal>(){};
			correctresult.Add("Horse1", (decimal)8.4);	
			correctresult.Add("Horse2", (decimal)7.6);		
			Assert.Equal(correctresult, result);
			
        }
		
    }
}