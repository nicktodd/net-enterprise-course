using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompactDiscEntityFramework;

namespace CompactDiscDAO
{
    public class EFCompactDiscDao : CompactDiscDao
    {
        public void AddCompactDisc(CompactDisc disc)
        {
            using (MusicDbContext context = new MusicDbContext())
            {
                context.CompactDiscs.Add(disc);
            }
               
        }

        public List<CompactDisc> GetDiscsByTitle(string title)
        {
            using (MusicDbContext context = new MusicDbContext())
            {
                return (from m in context.CompactDiscs where m.title == title select m).ToList();
            }
        }

        public List<CompactDisc> GetDiscsByArtist(string artist)
        {
            using (MusicDbContext context = new MusicDbContext())
            {
                return (from m in context.CompactDiscs where m.artist == artist select m).ToList();
            }
        }

        public List<CompactDisc> GetAllDiscs()
        {
            using (MusicDbContext context = new MusicDbContext())
            {
                return context.CompactDiscs.ToList();
            }
        }
    }
}
