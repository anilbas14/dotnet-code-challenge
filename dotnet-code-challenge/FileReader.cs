using System;
using System.IO;

namespace dotnet_code_challenge
{
    class FileReader
    {
        public string ReadFile(string address)
        {
			try
            { 
				StreamReader sr = new StreamReader(address);
			    String line = sr.ReadToEnd();
                return line;
		    }
			catch (IOException e)
			{
				return e.Message;
			}

        }
    }
}
