using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompactDiscEntityFramework;

namespace CompactDiscDAO
{
    public class UnitOfWork
    {
        private MusicDbContext _context;

        public UnitOfWork()
        {
            this._context = new MusicDbContext();
        }

        // now expose each of the repositories, in our case there is only one

        private CompactDiscDao _cdDao;

        public CompactDiscDao CdDao
        {
            get
            {
                if (_cdDao == null)
                {
                    _cdDao = new TransactionalCompactDiscDao(_context);
                    
                }
                return _cdDao;

            }
        }

        public void Commit()
        {
            _context.SaveChanges();
            _context.Dispose();
        }

        public void Rollback()
        {
            _context.Dispose();
        }

    }
}
