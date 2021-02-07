using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Part2
{
    class Program
    {
        const string one = @"C:\Users\D1\Desktop\Nik\Віршик_до_миколая.txt";
        const string two = @"C:\Users\D1\Desktop\Ref\Посилання.txt";
        const string three = @"C:\Users\D1\Desktop\Cat\Чого_хоче_кіт.txt";
        const string onebz = @"C:\Users\D1\Desktop\Nik\Віршик_до_миколая.txt.bz2";
        const string twobz = @"C:\Users\D1\Desktop\Ref\Посилання.txt.bz2";
        const string threebz = @"C:\Users\D1\Desktop\Cat\Чого_хоче_кіт.txt.bz2";
        static void Main(string[] args)
        {
            string text = FileReader.Read(one);
            Console.WriteLine();
            Console.WriteLine(Base64Converter.convert(text));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            text = FileReader.Read(two);
            Console.WriteLine();
            Console.WriteLine(Base64Converter.convert(text));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            text = FileReader.Read(three);
            Console.WriteLine();
            Console.WriteLine(Base64Converter.convert(text));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(Base64Converter.convert(ByteToByteListConverter.convert(onebz)));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(Base64Converter.convert(ByteToByteListConverter.convert(twobz)));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(Base64Converter.convert(ByteToByteListConverter.convert(threebz)));
            Console.WriteLine("------------------------------------------------------------------------------------------");

        }
    }
}
