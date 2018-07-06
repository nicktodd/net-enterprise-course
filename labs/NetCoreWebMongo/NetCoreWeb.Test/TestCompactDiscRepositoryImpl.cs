using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.Common.DataCollection;
using MongoDB.Driver;
using NetCoreWeb.Repository;
using Xunit;
using Xunit.Sdk;

namespace NetCoreWeb.Test
{
    public class TestCompactDiscRepositoryImpl : IDisposable
    {
        private readonly CompactDiscRepositoryImpl _repo;


        public TestCompactDiscRepositoryImpl()
        {
            _repo = new CompactDiscRepositoryImpl();

        }

        public void Dispose()
        {
           //MongoClient client = new MongoClient("mongodb://localhost:27017");
           // IMongoDatabase _db = client.GetDatabase("music");
           // _db.DropCollection("compactdiscs");
        }

        [Fact]
        public void CanAddOneCompactDisc()
        {
            CompactDisc disc = new CompactDisc() {Artist = "Abba", Title = "Abba Gold", Price = 7.99M, CdId = 1};
            _repo.AddCompactDisc(disc);
            ICollection<CompactDisc> discs = _repo.GetAllCompactDiscs();
            
            Assert.True(discs.First(d => d.CdId == 1).CdId == 1);
        }

        [Fact]
        public void CanUpdateOneCompactDisc()
        {
            CompactDisc disc = new CompactDisc() { Artist = "Abba", Title = "Abba Gold", Price = 7.99M, CdId = 1 };
            _repo.AddCompactDisc(disc);
            disc.Title = "Abba Silver";
            _repo.UpdateCompactDisc(disc);
            ICollection<CompactDisc> discs = _repo.GetAllCompactDiscs();
            Assert.True(discs.First(d => d.CdId == 1).Title == "Abba Silver");
        }

        [Fact]
        public void CanDeleteOneCompactDisc()
        {
            CompactDisc disc = new CompactDisc() { Artist = "Abba", Title = "Abba Gold", Price = 7.99M, CdId = 1 };
            _repo.AddCompactDisc(disc);
            _repo.DeleteCompactDisc(1);
            ICollection<CompactDisc> discs = _repo.GetAllCompactDiscs();
            Assert.True(discs.Count == 0);


        }

    }
}
