using System;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine("-------------------------MyEncript--------------------------------------------------------");
            string text = FileReader.Read(one);
            Console.WriteLine();
            Console.WriteLine(Base64Converter.convert(text));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------NotMyEncript-----------------------------------------------------");
            Console.WriteLine((Convert.ToBase64String(Encoding.Default.GetBytes(text))));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------MyEncript--------------------------------------------------------");
            text = FileReader.Read(two);
            Console.WriteLine();
            Console.WriteLine(Base64Converter.convert(text));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------NotMyEncript-----------------------------------------------------");
            Console.WriteLine((Convert.ToBase64String(Encoding.Default.GetBytes(text))));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------MyEncript--------------------------------------------------------");
            text = FileReader.Read(three);
            Console.WriteLine();
            Console.WriteLine(Base64Converter.convert(text));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------NotMyEncript-----------------------------------------------------");
            Console.WriteLine((Convert.ToBase64String(Encoding.Default.GetBytes(text))));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------MyEncript--------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(Base64Converter.convert(ByteToByteListConverter.convert(onebz)));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------NotMyEncript-----------------------------------------------------");
            Console.WriteLine((Convert.ToBase64String(File.ReadAllBytes(onebz))));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------MyEncript--------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(Base64Converter.convert(ByteToByteListConverter.convert(twobz)));
            Console.WriteLine("-------------------------NotMyEncript-----------------------------------------------------");
            Console.WriteLine((Convert.ToBase64String(File.ReadAllBytes(twobz))));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------MyEncript--------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(Base64Converter.convert(ByteToByteListConverter.convert(threebz)));
            Console.WriteLine("-------------------------NotMyEncript-----------------------------------------------------");
            Console.WriteLine((Convert.ToBase64String(File.ReadAllBytes(threebz))));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------------------");

        }
    }
}
