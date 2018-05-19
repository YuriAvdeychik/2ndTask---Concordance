using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Library.Classes;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //string textFilePath = ConfigurationManager.AppSettings["TextFilePath"];
            //string alhabetFilePath = ConfigurationManager.AppSettings["AlphabetFilePath"];
            string textFilePath = @"C:\Users\YURI\source\repos\2ndTask---Concordance\Text.txt";
            string alhabetFilePath = @"C:\Users\YURI\source\repos\2ndTask---Concordance\Alphabet.txt";

            ConcordanceCreater concordanceCreater = new ConcordanceCreater(alhabetFilePath);
            Concordance concordance = concordanceCreater.CreateConrcondance(textFilePath, 4); //int N - count of string in one page
            concordance.SaveToFile();

            Console.ReadKey();
        }
    }
}
