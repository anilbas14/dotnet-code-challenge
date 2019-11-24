using System;
using Xunit;
using System.Collections.Generic;

namespace dotnet_code_challenge.Test
{
    public class DictionarySorter_SortShould
    {
		private readonly DictionarySorter _ds;
		
		public DictionarySorter_SortShould()
		{
			_ds = new DictionarySorter();
		}
		
        [Fact]
        public void Sort_EmptyStringInput_ReturnsEmptyDictionary()
        {
			var emptydict = new Dictionary<string, decimal>(){};
			var result = _ds.Sort(emptydict);			
			Assert.Equal(new Dictionary<string, decimal>(){}, result);
			
        }
		
		 [Fact]
        public void Parse_JSON_ReturnsCorrectDictionary()
        {
			var unsorted = new Dictionary<string, decimal>()
			{
				{"Horse6", (decimal)8.9},
				{"Horse5", (decimal)5.7}
			};
            var sorted = new Dictionary<string, decimal>()
			{
				{"Horse5", (decimal)5.7},
				{"Horse6", (decimal)8.9}				
			};
            var result = _ds.Sort(unsorted);			
			Assert.Equal(sorted, result);		
        } 		
    }
}
