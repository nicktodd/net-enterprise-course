using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace NetCoreWeb.Repository
{
    public class CompactDiscRepositoryImpl : ICompactDiscRepository
    {

        private readonly IMongoDatabase _db;

        public CompactDiscRepositoryImpl()
        {
            MongoClient client = new MongoClient("mongodb://mymongo:27017");
            _db = client.GetDatabase("music");
        }
       

        public ICollection<CompactDisc> GetAllCompactDiscs()
        {
            List<CompactDisc> cds = new List<CompactDisc>();
            var cursor = _db.GetCollection<CompactDisc>("compactdiscs").Find(new BsonDocument()).ToCursor();
            foreach (var document in cursor.ToEnumerable())
            {
                cds.Add(document);
            }
            return cds;
        }

        public CompactDisc GetCompactDiscById(int id)
        {
            return _db.GetCollection<CompactDisc>("compactdiscs").Find(disc => disc.CdId == id).FirstOrDefault();
        }

        public void AddCompactDisc(CompactDisc disc)
        {
            _db.GetCollection<CompactDisc>("compactdiscs").InsertOne(disc);
        }

        public void DeleteCompactDisc(int id)
        {
            _db.GetCollection<CompactDisc>("compactdiscs").DeleteOne(disc => disc.CdId == id);
        }

        public void UpdateCompactDisc(CompactDisc disc)
        {
            _db.GetCollection<CompactDisc>("compactdiscs").ReplaceOneAsync(n => n.CdId.Equals(disc.CdId)
                , disc
                , new UpdateOptions { IsUpsert = true });
        }
    }
}
