using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_CS
{
    class Program
    {
        const string UpCaseAlphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
        const string DownCaseAlphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        const string Alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
        const int AlphabetLength = 33;
        const string one = @"C:\Users\D1\Desktop\Nik\Віршик_до_миколая.txt";
        const string two = @"C:\Users\D1\Desktop\Ref\Посилання.txt";
        const string three = @"C:\Users\D1\Desktop\Cat\Чого_хоче_кіт.txt";
        
        static double[,] Array = new double[AlphabetLength, 2];
        static int countOfAllLetters = 0;
        static double Entropy = 0;
        static void Main(string[] args)
        {


            string text = ReadFile(one);
            CountLetters(text); 
            CountFrequency(); 
            Entropy = CountEntropy();
            double amountOfInformation = Entropy * countOfAllLetters;
            ShowArray(Array);
            WriteInformation(one, amountOfInformation);
            CompareArchive(amountOfInformation, one);
            

            Console.WriteLine("==========================================================================\n");

            text = ReadFile(two);
            CountLetters(text); 
            CountFrequency(); 
            Entropy = CountEntropy();
            amountOfInformation = Entropy * countOfAllLetters;
            ShowArray(Array);
            WriteInformation(two, amountOfInformation);
            CompareArchive(amountOfInformation, two); 
            

            Console.WriteLine("==========================================================================\n");

            text = ReadFile(three);
            CountLetters(text); 
            CountFrequency(); 
            Entropy = CountEntropy();
            amountOfInformation = Entropy * countOfAllLetters;
            ShowArray(Array);
            WriteInformation(three, amountOfInformation);
            CompareArchive(amountOfInformation, three); 
          

            Console.ReadLine();
        }

        //
        static void CompareArchive(double amountOfInformation, string path)
        {
            string[] archive = new string[] { ".zip", ".rar", ".gz", ".bz2", ".xz" };
            foreach (string extention in archive)
            {
                FileInfo file = new FileInfo(path + extention);

                Console.WriteLine("Розмір архіву {0}: {1}", extention, file.Length);

                if (file.Length > amountOfInformation)
                    Console.WriteLine("Розмір архіву " + extention + " більше кількості інформації у файлі\n");
                else
                {
                    if (file.Length == amountOfInformation)
                        Console.WriteLine("Розмір архіву " + extention + " рівне кількості інформації у файлі\n");
                    else
                        Console.WriteLine("Розмір архіву " + extention + " менше кількості інформації у файлі\n");
                }
            }

        }
        static double CountEntropy()
        {
            double Entropy = 0;
            for (int i = 0; i < AlphabetLength; i++)
            {
                if (Array[i, 0] != 0)
                    Entropy += Array[i, 1] * Math.Log(1 / Array[i, 1], 2);
            }
            return Entropy;
        }
        //write information
        static void WriteInformation(string path, double amountOfInformation)
        {
            FileInfo file = new FileInfo(path);
            
            Console.WriteLine("кількість інформації {0:F5} bits", amountOfInformation);
            Console.WriteLine("кількість інформації {0:F5} bytes", amountOfInformation / 8); // 1byte = 8 bits
            Console.WriteLine("Ентропія {0:F5} bits \n", Entropy);
            Console.WriteLine("Розмір : {0} bytes", file.Length);
            if (file.Length > amountOfInformation / 8)
                Console.WriteLine("Розмір більше кількості інформації у файлі\n");
            else
            {
                if (file.Length == amountOfInformation / 8)
                {
                    Console.WriteLine("Розмір рівний кількості інформації у файлі\n");
                }
                else
                {
                    Console.WriteLine("Розмір менше кількості інформації у файлі\n");
                }
            }
        }

        //
        static void ShowArray(double[,] Array)
        {
            Console.WriteLine("Буква\t\tКількість\tЧастота");
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                Console.Write("{0}\t", DownCaseAlphabet[i]);
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Console.Write("{0,15:F5}", Array[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //count frequency
        static void CountFrequency()
        {
            for (int i = 0; i < AlphabetLength; i++)
            {
                try
                {
                    Array[i, 1] = Array[i, 0] / countOfAllLetters;
                }
                catch (DivideByZeroException)
                {
                    Array[i, 1] = 0;
                }
            }
        }

        //count letters
        static void CountLetters(string text)
        {
            countOfAllLetters = 0;
            bool firstOne = true;
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                int OneLetterCounter = 0;
                foreach (char letter in text)
                {
                    if (Alphabet.Contains(letter))
                    {
                        if (firstOne)
                            countOfAllLetters++;
                        if (letter == UpCaseAlphabet[i] || letter == DownCaseAlphabet[i])
                        {
                            OneLetterCounter++;
                        }
                    }
                }
                firstOne = false;
                Array[i, 0] = OneLetterCounter;
            }
            Console.WriteLine("\n");
            Console.WriteLine("Кількість букв: {0}", countOfAllLetters);
        }

        //read
        static string ReadFile(string filePath)
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
