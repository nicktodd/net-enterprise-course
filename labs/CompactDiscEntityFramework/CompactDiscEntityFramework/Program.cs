using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompactDiscEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            MusicDbContext context = new MusicDbContext();

            // insert a row
            //CompactDisc disc = new CompactDisc() {title = "Gold", artist = "Abba", price = (decimal?)12.99, tracks = 11};
            //context.CompactDiscs.Add(disc);
            //context.SaveChanges();

            // get all the CDs
            List<CompactDisc> cds = context.CompactDiscs.ToList();
            foreach (var cd in cds)
            {
                //Console.WriteLine(cd.title);                
            }

            // Linq Queries
            List<CompactDisc> cdsCalledGold = context.CompactDiscs.Where(m => m.title == "Gold").ToList();
           var cdsCalledGoldWithLinq = from m in context.CompactDiscs where m.title == "Gold" select m;

            // all CDs where artist begins with S
            var cdBeginningWithS = from m1 in context.CompactDiscs where m1.title.StartsWith("S") select m1 ;
            // number of CDs
            var numberOfCDs = context.CompactDiscs.Count();
            // all cds in alphabetic order by title
            var cdsOrderByTitle = from m3 in context.CompactDiscs orderby m3.title select m3;
            // all tracks by spice girls
            var tracksBySpiceGirls = from m4 in context.Tracks where m4.compactDisc.artist == "Spice Girls" select m4;
            foreach (var track in tracksBySpiceGirls)
            {
                Console.WriteLine(track.title);
            }

            // handling lazy loaded properties
            // retrieve CD by Spice Girls

            // even though the album has been retrieved, the tracks have not (lazy loading)
            // if the context is open then they would have been retrieved when this line executes
            // but since the context is no longer available we have no access to the database
            var spiceGirlsAlbum = context.CompactDiscs.FirstOrDefault(m => m.artist == "Spice Girls");

            // this revised query solves the problem by pulling the tracks back as well with an Include
            var spiceGirlsAlbumWithTracks = context.CompactDiscs.Include("trackList").FirstOrDefault(m => m.artist == "Spice Girls");


            CompactDisc updateDisc = new CompactDisc() { id = 1, title = "Strokes 2", artist = "The Strokes", price = (decimal?)12.99 };
            context.CompactDiscs.AddOrUpdate(updateDisc);
            context.SaveChanges();

            CompactDisc discByColdplay = (from disc in context.CompactDiscs where disc.artist == "ColdPlay" select disc).FirstOrDefault();
            discByColdplay.title = "Best of ColdPlay";
            context.SaveChanges();

            context.Dispose();

            foreach (var track in spiceGirlsAlbumWithTracks.trackList)
            {
                Console.WriteLine(track.title);
            }

            Console.ReadKey();
        }
    }
}
