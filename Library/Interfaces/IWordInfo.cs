using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IWordInfo
    {
        string Value { get; }
        int Count { get; }
        void CountUp();
        ICollection<int> PageNumbers { get; }
        string PageNumbersToString();
        void AddPageNumber(int pageNumber);
    }
}
