using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompactDiscEntityFramework;
using Microsoft.Practices.Unity;

namespace CompactDiscDAO
{
    public class TransactionalCompactDiscService : ICompactDiscService
    {
        [Dependency]
        public CompactDiscDao CdDao { get; set; }

        public List<CompactDisc> GetCatalog()
        {
            UnitOfWork uow = new UnitOfWork();
            return uow.CdDao.GetAllDiscs();
            // no changes to commit
        }

        public void AddToCatalog(CompactDisc disc)
        {
            UnitOfWork uow = new UnitOfWork();
            uow.CdDao.AddCompactDisc(disc);
            uow.Commit();
        }
    }
}
