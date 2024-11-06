using System.Security.Principal;

namespace QwertyToAzertyApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Translator
    {
        private static readonly Dictionary<char, char> QwertyToAzertyMap = new()
        {
            { 'a', 'q' }, { 'A', 'q' }, { 'q', 'a' }, { 'Q', 'a' },
            { 'z', 'w' }, { 'Z', 'w' }, { 'w', 'z' }, { 'W', 'z' },
            { 'm', ',' }, { 'M', '?' }, { ';', 'm' }, { ':', 'M' },
            { '<', '.' }, { '>', '/' }, { ',', '.' }, { '8', '!' }
        };

        public static string TranslateToAzerty(string input)
        {
            char[] result = input.ToCharArray();
            for (int i = 0; i < result.Length; i++)
            {
                if (QwertyToAzertyMap.ContainsKey(result[i]))
                {
                    if (i == 0)
                    {
                        result[i] = QwertyToAzertyMap[result[i]];
                    }
                    result[i] = QwertyToAzertyMap[result[i]];
                }
                
            }

            for (int i = 0; i < result.Length; i++)
            {
                if (i != 0)
                {
                    result[i] = Convert.ToChar(result[i].ToString().ToLower());
                }
            }

            string translatedResult = new string(result);
            return translatedResult.CapitalizeAfter(new []{ '.', '<' });
        }
        
        public static string CapitalizeAfter(this string s, IEnumerable<char> chars)
        {
            var charsHash = new HashSet<char>(chars);
            StringBuilder sb = new StringBuilder(s);
            for (int i = 0; i < sb.Length - 2; i++)
            {
                if (charsHash.Contains(sb[i]) && sb[i + 1] == ' ')
                    sb[i + 2] = char.ToUpper(sb[i + 2]);
            }
            return sb.ToString();
        }
    }
}