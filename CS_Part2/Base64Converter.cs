using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Part2
{
    public class Base64Converter
    {
        const string Base64Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        public static string convert(byte[] byteMass)
        {
            string final = "";
            int Base = byteMass.Length % 3;
            for (int i = 0; i < byteMass.Length - Base; i = i + 3)
            {
                byte One = byteMass[i];
                byte Two = byteMass[i + 1];
                byte Three = byteMass[i + 2];

                final += Base64Alphabet[One >> 2];

                final += Base64Alphabet[((One & 3) << 4) | (Two >> 4)];

                final += Base64Alphabet[((Two & 15) << 2) | (Three >> 6)];

                final += Base64Alphabet[Three & 63];
            }
            if (Base == 1)
            {
                byte One = byteMass[byteMass.Length - 2];
                final += Base64Alphabet[One >> 2];
                final += Base64Alphabet[((One & 3) << 4)];
                final += "==";
            }
            if (Base == 2)
            {
                byte One = byteMass[byteMass.Length - 2];
                byte Two = byteMass[byteMass.Length - 1];
                final += Base64Alphabet[One >> 2];
                final += Base64Alphabet[((One & 3) << 4) | (Two >> 4)];
                final += "=";
            }
            return final;
        }
    }
}
