using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompactDiscEntityFramework;

namespace CompactDiscDAO
{
    public interface CompactDiscDao
    {

        void AddCompactDisc(CompactDisc disc);
        List<CompactDisc> GetDiscsByTitle(string title);
        List<CompactDisc> GetDiscsByArtist(string artist);
        List<CompactDisc> GetAllDiscs();
    }

}
