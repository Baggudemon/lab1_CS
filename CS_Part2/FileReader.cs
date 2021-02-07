using System;
using System.IO;

namespace CS_Part2
{
    class FileReader
    {
        public static string Read(string filePath)
        {
            string text = "";
            string input;
            try
            {
                using (StreamReader reader = File.OpenText(filePath))
                {
                    while ((input = reader.ReadLine()) != null)
                    {
                        text += input + "\n";
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Sorry Buddy, try another filepath");
                throw;
            }
            Console.WriteLine(filePath);
            return text;
        }
    }
}
