using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CompactDiscEntityFramework;

namespace CompactDiscDAO
{
    

    public class FakeCompactDiscDao : CompactDiscDao
    {
        private List<CompactDisc> discs = new List<CompactDisc>();

        public FakeCompactDiscDao()
        {
            discs.Add(new CompactDisc() {artist = "Rag'n'Bone Man", title = "Human", price = (decimal?)11.99, tracks = (int?)10});
            discs.Add(new CompactDisc() { artist = "Adele", title = "25", price = (decimal?)8.99, tracks = (int?)11 });
            discs.Add(new CompactDisc() { artist = "Justin Bieber", title = "Purpose", price = (decimal?)12.99, tracks = (int?)11 });
            discs.Add(new CompactDisc() { artist = "Ed Sheeran", title = "Divide", price = (decimal?)8.99, tracks = (int?)11 });


        }
        public void AddCompactDisc(CompactDisc disc)
        {
            discs.Add(disc);
        }

        public List<CompactDisc> GetDiscsByTitle(string title)
        {
            return (from m in discs where m.title == title select m).ToList();
        }

        public List<CompactDisc> GetDiscsByArtist(string artist)
        {
            return (from m in discs where m.artist == artist select m).ToList();
        }

        public List<CompactDisc> GetAllDiscs()
        {
            return discs;
        }
    }
}
