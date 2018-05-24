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
            //start
            try
            {
                string textFilePath = ConfigurationManager.AppSettings["TextFilePath"];
                string alhabetFilePath = ConfigurationManager.AppSettings["AlphabetFilePath"];
                ConcordanceCreater concordanceCreater = new ConcordanceCreater(alhabetFilePath);
                Concordance concordance = concordanceCreater.CreateConrcondance(textFilePath, 4); //int N - count of string in one page
                concordance.SaveToFile();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }         

            Console.ReadKey();
        }
    }
}
