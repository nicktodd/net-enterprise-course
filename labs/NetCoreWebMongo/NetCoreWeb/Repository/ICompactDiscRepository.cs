using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWeb.Repository
{
    public interface ICompactDiscRepository
    {
        ICollection<CompactDisc> GetAllCompactDiscs();
        CompactDisc GetCompactDiscById(int id);
        void AddCompactDisc(CompactDisc disc);
        void DeleteCompactDisc(int id);
        void UpdateCompactDisc(CompactDisc disc);
    }
}
