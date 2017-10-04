using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompactDiscEntityFramework;
using Microsoft.Practices.Unity;

namespace CompactDiscDAO
{
    public class CompactDiscService : ICompactDiscService
    {
       [Dependency]
        public CompactDiscDao DiscDao { get; set; }

        public List<CompactDisc> GetCatalog()
        {
            return DiscDao.GetAllDiscs();
        }

        public void AddToCatalog(CompactDisc disc)
        {
            DiscDao.AddCompactDisc(disc);
        } 

    }
}
