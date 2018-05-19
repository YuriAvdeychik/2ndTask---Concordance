using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Classes
{
    public class Concordance : IConcordance
    {
        private IDictionary<char, IDictionary<string, IWordInfo>> _items;
        public IDictionary<char, IDictionary<string, IWordInfo>> Items
        {
            get
            {
                return _items;
            }
        }
        public IDictionary<string, IWordInfo> this[char key]
        {
            get
            {
                return _items[key];
            }
            set
            {
                _items[key] = value;
            }
        }

        public Concordance(string _alphabet)
        {
            _items = new Dictionary<char, IDictionary<string, IWordInfo>>();
            foreach (char letter in _alphabet)
            {
                _items[char.ToUpper(letter)] = new SortedDictionary<string, IWordInfo>();
            }
        }

        public void SaveToFile()
        {
            string currentDirectoryPath = Path.GetDirectoryName(Environment.CurrentDirectory);
            string pathToFile = Path.Combine(currentDirectoryPath, @"..\\../Concordance.txt");
            StreamWriter writer = new StreamWriter(pathToFile, false);

            writer.WriteLine("Concordance:");
            foreach (char mainLetter in this.Items.Keys)
            {
                if (this[mainLetter].Values.Count != 0)
                {
                    writer.WriteLine(mainLetter);
                    foreach (var items in this[mainLetter])
                    {
                        writer.WriteLine("{0}..........{1}: {2}",
                            items.Key, items.Value.Count, items.Value.PageNumbersToString());
                    }
                }
            }
            writer.Close();
        }
    }
}
