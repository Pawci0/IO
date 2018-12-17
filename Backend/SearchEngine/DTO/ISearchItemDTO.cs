using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.DTO
{
    public interface ISearchItemDTO
    {
        string Name { get; }
        float Score { get; }
    }
}
