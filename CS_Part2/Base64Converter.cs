using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Part2
{
    public class Base64Converter
    {
        const string Base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        public static string convert(string text)
        {
            string stringBase64 = "";
            int Padding;
            int countOfIterator = 0;
            string stringBuffer = "";
            char[] arrayBuffer = new char[6];


            List<char[]> listOfBytes = ASCIIConverter.convert(text);
            List<char[]> listOfByteBase64 = new List<char[]>();


            int j = 0;
            int numberOfCase = 0;

            foreach (char[] array in listOfBytes)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    arrayBuffer[j] = array[i];

                    if (j == 5)
                    {
                        if (!((Padding = (array.Length - i + 1)) % 3 == 0))
                            if (Padding % 3 == 1)
                                numberOfCase = 1;
                            else
                                if (Padding % 3 == 2)
                                numberOfCase = 2;

                        listOfByteBase64.Add(arrayBuffer);
                        arrayBuffer = new char[6];
                        j = 0;
                        if (listOfBytes.Count - 1 == countOfIterator)
                        {
                            int counterOfZeros = 0;
                            for (i += 1; i < array.Length; i++)
                            {
                                counterOfZeros++;
                                arrayBuffer[j] = array[i];
                                j++;
                            }
                            for (; j < arrayBuffer.Length; j++)
                            {
                                arrayBuffer[j] = '0';
                            }
                            listOfByteBase64.Add(arrayBuffer);
                            break;
                        }
                        continue;
                    }
                    j++;
                }
                countOfIterator++;
            }
            for (int i = 0; i < listOfByteBase64.Count; i++)
            {
                stringBuffer = "";
                foreach (char number in listOfByteBase64[i])
                {
                    stringBuffer += number;
                }
                stringBase64 += Base64[Convert.ToInt32(stringBuffer, 2)];
            }
            if (numberOfCase == 1)
                stringBase64 += "==";
            else
                 if (numberOfCase == 2)
                stringBase64 += "=";

            return stringBase64;
        }
        public static string convert(List<char[]> ASCIIText)
        {
            string stringBase64 = "";
            string stringBuffer = "";
            int Padding;
            int countOfIterator = 0;
            char[] arrayBuffer = new char[6]; 

            //List<char[]> listOfBytes = AsciConverter(text);
            List<char[]> listOfByteBase64 = new List<char[]>();
            int j = 0;

            int numberOfCase = 0;
         

            foreach (char[] array in ASCIIText)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    arrayBuffer[j] = array[i];

                    if (j == 5)
                    {
                        if (!((Padding = (array.Length - i + 1)) % 3 == 0))
                            if (Padding % 3 == 1)
                                numberOfCase = 1;
                            else
                                if (Padding % 3 == 2)
                                numberOfCase = 2;

                        listOfByteBase64.Add(arrayBuffer);
                        arrayBuffer = new char[6];
                        j = 0;
                        if (ASCIIText.Count - 1 == countOfIterator)
                        {
                            int counterOfZeros = 0;
                            for (i += 1; i < array.Length; i++)
                            {
                                counterOfZeros++;
                                arrayBuffer[j] = array[i];
                                j++;
                            }
                            for (; j < arrayBuffer.Length; j++)
                            {
                                arrayBuffer[j] = '0';
                            }
                            listOfByteBase64.Add(arrayBuffer);
                            break;
                        }
                        continue;
                    }
                    j++;
                }
                countOfIterator++;
            }
            for (int i = 0; i < listOfByteBase64.Count; i++)
            {
                stringBuffer = "";
                foreach (char number in listOfByteBase64[i])
                {
                    stringBuffer += number;
                }
                stringBase64 += Base64[Convert.ToInt32(stringBuffer, 2)];
            }
            if (numberOfCase == 1)
                stringBase64 += "==";
            else
                 if (numberOfCase == 2)
                stringBase64 += "=";

            return stringBase64;
        }
    }
}
