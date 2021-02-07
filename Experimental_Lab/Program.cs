using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimental_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        
    public static string ToBase64String(byte[] inArray)
    {
        if (inArray == null)
        {
            throw new ArgumentNullException("inArray");
        }
        return ToBase64String(inArray, 0, inArray.Length, Base64FormattingOptions.None);
    }


    public static unsafe string ToBase64String(byte[] inArray, int offset, int length, Base64FormattingOptions options)
    {
        if (inArray == null)
        {
            throw new ArgumentNullException("inArray");
        }
        if (length < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        if ((options < Base64FormattingOptions.None) || (options > Base64FormattingOptions.InsertLineBreaks))
        {
            throw new ArgumentException();
        }
        int num = inArray.Length;
        if (offset > (num - length))
        {
            throw new ArgumentOutOfRangeException();
        }
        if (num == 0)
        {
            return string.Empty;
        }
        bool insertLineBreaks = options == Base64FormattingOptions.InsertLineBreaks;
        string str = string.FastAllocateString(ToBase64_CalculateAndValidateOutputLength(length, insertLineBreaks));
        fixed (char* str2 = ((char*)str))
        {
            char* outChars = str2;
            if (outChars != null)
            {
                outChars += RuntimeHelpers.OffsetToStringData;
            }
            fixed (byte* numRef = inArray)
            {
                int num3 = ConvertToBase64Array(outChars, numRef, offset, length, insertLineBreaks);
                return str;
            }
        }
    }





    private static unsafe int ConvertToBase64Array(char* outChars, byte* inData, int offset, int length, bool insertLineBreaks)
    {
        int num = length % 3;
        int num2 = offset + (length - num);
        int index = 0;
        int num4 = 0;
        fixed (char* chRef = base64Table)
        {
            int num5;
            for (num5 = offset; num5 < num2; num5 += 3)
            {
                if (insertLineBreaks)
                {
                    if (num4 == 0x4c)
                    {
                        outChars[index++] = '\r';
                        outChars[index++] = '\n';
                        num4 = 0;
                    }
                    num4 += 4;
                }
                outChars[index] = chRef[(inData[num5] & 0xfc) >> 2];
                outChars[index + 1] = chRef[((inData[num5] & 3) << 4) | ((inData[num5 + 1] & 240) >> 4)];
                outChars[index + 2] = chRef[((inData[num5 + 1] & 15) << 2) | ((inData[num5 + 2] & 0xc0) >> 6)];
                outChars[index + 3] = chRef[inData[num5 + 2] & 0x3f];
                index += 4;
            }
            num5 = num2;
            if ((insertLineBreaks && (num != 0)) && (num4 == 0x4c))
            {
                outChars[index++] = '\r';
                outChars[index++] = '\n';
            }
            if (num == 1)
            {
                outChars[index] = chRef[(inData[num5] & 0xfc) >> 2];
                outChars[index + 1] = chRef[(inData[num5] & 3) << 4];
                outChars[index + 2] = chRef[0x40];
                outChars[index + 3] = chRef[0x40];
                index += 4;
            }
            else if (num == 2)
            {
                outChars[index] = chRef[(inData[num5] & 0xfc) >> 2];
                outChars[index + 1] = chRef[((inData[num5] & 3) << 4) | ((inData[num5 + 1] & 240) >> 4)];
                outChars[index + 2] = chRef[(inData[num5 + 1] & 15) << 2];
                outChars[index + 3] = chRef[0x40];
                index += 4;
            }
        }
        return index;
    }
    }






}
