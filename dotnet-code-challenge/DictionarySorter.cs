using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge
{
    public class DictionarySorter
    {
        public Dictionary<string, decimal> Sort(Dictionary<string, decimal> input)
        {
			var sorted = from pair in input
                    orderby pair.Value ascending
                    select pair;
					
			return sorted.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}