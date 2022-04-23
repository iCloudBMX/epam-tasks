using System;
using System.Collections.Generic;
using System.Text;

namespace Katas
{
    public class DictionaryReplacer
    {
        public static string ReplaceSuffixWithKeys(
            string inputString, 
            Dictionary<string, string> dictionary)
        {
            StringBuilder result = new StringBuilder();
            
            for(int index = 0; index < inputString.Length; index++)
            {
                if(inputString[index] != '$')
                    result.Append(inputString[index]);
                
                else
                {
                    index++;
                    string key = "";
                    while (index < inputString.Length && inputString[index] != '$')
                    {
                        key += inputString[index];
                        index++;
                    }

                    if (dictionary.ContainsKey(key))
                        result.Append(dictionary[key]);
                }
            }

            return result.ToString();
        }
    }
}
