using System.Collections.Generic;
using CompactDiscEntityFramework;

namespace CompactDiscDAO
{
    public interface ICompactDiscService
    {
        List<CompactDisc> GetCatalog();
        void AddToCatalog(CompactDisc disc);
    }
}