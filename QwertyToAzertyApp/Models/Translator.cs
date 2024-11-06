namespace QwertyToAzertyApp.Models;
using System.Collections.Generic;

public static class Translator
{
    private static readonly Dictionary<char, char> QwertyToAzertyMap = new()
    {
        { 'a', 'q' }, { 'q', 'a' }, { 'z', 'w' }, { 'w', 'z' },
        { 'm', ',' }, { ';', 'm' },{'<','.'} // Add more mappings as needed
        // Add mappings for uppercase letters and symbols if needed
    };

    public static string TranslateToAzerty(string input)
    {
        char[] result = input.ToCharArray();
        for (int i = 0; i < result.Length; i++)
        {
            if (QwertyToAzertyMap.ContainsKey(result[i]))
            {
                result[i] = QwertyToAzertyMap[result[i]];
            }
        }
        return new string(result);
    }
}
