using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Classes
{
    public class ConcordanceCreater
    {
        private string _alphabet;

        public ConcordanceCreater(string alphabetPath)
        {
            StreamReader alphabet = new StreamReader(alphabetPath);
            _alphabet = alphabet.ReadLine();
        }

        public Concordance CreateConrcondance(string path, int N) // int N - count of string in one page
        {

            Concordance concordance = new Concordance(_alphabet);
            StreamReader text = new StreamReader(path);

            string pattern = string.Format("\\b[{0}]+\\b", _alphabet);
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            StringBuilder currentPage = new StringBuilder();
            string currentString = text.ReadLine();
            int currentStringNumber = 0;
            int currentPageNumber = 1;

            while (currentString != null)
            {
                currentStringNumber += 1;
                currentPage.Append(currentString + " ");
                if (currentStringNumber == N)
                {
                    CreateConcordanceItems(regex, currentPage.ToString(), concordance, currentPageNumber);
                    currentPageNumber += 1;
                    currentStringNumber = 0;
                    currentPage.Clear();
                }
                currentString = text.ReadLine();
                if (currentString == null)
                {
                    CreateConcordanceItems(regex, currentPage.ToString(), concordance, currentPageNumber);
                }
            }
            text.Close();
            return concordance;
        }
        private void CreateConcordanceItems(
            Regex regex, string currentPage, Concordance concordance, int currentPageNumber)
        {
            MatchCollection wordsCollection = regex.Matches(currentPage.ToString());
            foreach (var word in wordsCollection)
            {
                string _word = word.ToString().ToLower();
                char firstLetter = char.ToUpper(_word[0]);

                SortedDictionary<string, IWordInfo> wordValue =
                    (SortedDictionary<string, IWordInfo>)concordance[firstLetter];
                if (wordValue.Keys.Contains(_word))
                {
                    wordValue[_word].CountUp();
                    wordValue[_word].AddPageNumber(currentPageNumber);
                }
                else
                {
                    IWordInfo newWord = new WordInfo(_word, currentPageNumber);
                    wordValue[newWord.Value] = newWord;
                }
            }
        }
    }
}
