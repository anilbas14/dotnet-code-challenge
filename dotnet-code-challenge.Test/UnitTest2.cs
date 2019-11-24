using System;
using Xunit;
using System.Collections.Generic;

namespace dotnet_code_challenge.Test
{
    public class XmlParser_ParseShould
    {
		private readonly XmlParser _xp;

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
		
    }
}
