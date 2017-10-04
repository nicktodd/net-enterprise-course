using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompactDiscEntityFramework;

namespace CompactDiscDAO
{
    public class TransactionalCompactDiscDao : CompactDiscDao
    {

        private MusicDbContext _context;

        public TransactionalCompactDiscDao(MusicDbContext context)
        {
            _context = context;
        }

        public void AddCompactDisc(CompactDisc disc)
        {
            _context.CompactDiscs.Add(disc);
        }

        public List<CompactDisc> GetDiscsByTitle(string title)
        {
                return (from m in _context.CompactDiscs where m.title == title select m).ToList();
        }

        public List<CompactDisc> GetDiscsByArtist(string artist)
        {
                return (from m in _context.CompactDiscs where m.artist == artist select m).ToList();
        }

        public List<CompactDisc> GetAllDiscs()
        {
                return _context.CompactDiscs.ToList();
        }
    }
}
