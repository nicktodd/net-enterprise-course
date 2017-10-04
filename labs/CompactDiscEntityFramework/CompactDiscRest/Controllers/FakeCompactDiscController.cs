using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompactDiscEntityFramework;

namespace CompactDiscRest.Controllers
{
    public class FakeCompactDiscController : ApiController
    {
        private static Dictionary<int, CompactDisc> _catalog;

        static FakeCompactDiscController()
        {
            _catalog = new Dictionary<int, CompactDisc>();
            _catalog.Add(1, new CompactDisc() { artist = "Rag'n'Bone Man", title = "Human", price = (decimal?)11.99, tracks = (int?)10, id=1 });
            _catalog.Add(2, new CompactDisc() { artist = "Adele", title = "25", price = (decimal?)8.99, tracks = (int?)11, id = 2 });
            _catalog.Add(3, new CompactDisc() { artist = "Justin Bieber", title = "Purpose", price = (decimal?)12.99, tracks = (int?)11, id = 3 });
            _catalog.Add(4, new CompactDisc() { artist = "Ed Sheeran", title = "Divide", price = (decimal?)8.99, tracks = (int?)11, id = 4 });
        }

        // GET: api/FakeCompactDisc
        public List<CompactDisc> Get()
        {
            return _catalog.Values.ToList();
        }

        // GET: api/FakeCompactDisc/5
        public CompactDisc Get(int id)
        {
            return _catalog[id];
        }

        // POST: api/FakeCompactDisc
        public void Post([FromBody]CompactDisc value)
        {
            if (!_catalog.ContainsKey(value.id))
                _catalog.Add(value.id, value);
        }

        // PUT: api/FakeCompactDisc/5
        public void Put(int id, [FromBody]CompactDisc value)
        {
            if (_catalog.ContainsKey(value.id))
                _catalog.Add(value.id, value);
        }

        // DELETE: api/FakeCompactDisc/5
        public void Delete(int id)
        {
            _catalog.Remove(id);
        }
    }
}
