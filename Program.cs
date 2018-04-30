using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    internal static class Program
    {
        private static Dictionary<string, int> CreateDictionary(string input)
        {
            input += " ";
            var dictionary = new Dictionary<string, int>();
            int length = 0, position = -1;
            for (var i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) || char.IsNumber(input[i]))
                {
                    if (length != 0)
                    {
                        length++;
                    }
                    else
                    {
                        position = i;
                        length = 1;
                    }
                }
                else
                {
                    if (length == 0 || position == -1) continue;
                    var addString = input.Substring(position, length).ToLower();
                    position = -1;
                    length = 0;
                    if (dictionary.ContainsKey(addString))
                    {
                        dictionary[addString]++;
                    }
                    else
                    {
                        dictionary.Add(addString, 1);
                    }
                }
            }

            return dictionary;
        }

        private static void Main()
        {
            var newDictionary = CreateDictionary(Console.ReadLine());
            Console.WriteLine("Адекватный словарь слов из НЕзаглавных буков");
            foreach (var i in newDictionary)
            {
                Console.WriteLine(i.Key + " " + i.Value);
            }
        }
    }
}