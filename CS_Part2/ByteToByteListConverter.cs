using System;
using System.Collections.Generic;
using System.IO;

namespace CS_Part2
{

    class ByteToByteListConverter
    {
        private static char[] ToChar(int a)
        {

            char[] boolArrayOfEightBit = new char[8];
            string boolArray = Convert.ToString(a, 2);
            int i = 0;
            if (boolArray.Length != 8)
            {
                for (; i < 8 - boolArray.Length; i++)
                {
                    boolArrayOfEightBit[i] = '0';
                }
            }
            int j = 0;
            for (; i < boolArrayOfEightBit.Length; i++)
            {
                boolArrayOfEightBit[i] = boolArray[j];
                j++;
            }
            return boolArrayOfEightBit;
        }
        public static List<char[]> convert(string path)
        {
            List<char[]> listOfByte = new List<char[]>();
            byte[] array = File.ReadAllBytes(path);
            foreach (byte a in array)
            {
                listOfByte.Add(ToChar(a));
            }
            Console.WriteLine(path);
            return listOfByte;
        }
    }
}
