using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = ConfigurationManager.AppSettings["TextFilePath"];
            string alhabetFilePath = ConfigurationManager.AppSettings["AlphabetFilePath"];

            Console.ReadKey();
        }
    }
}
