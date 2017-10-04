using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompactDiscDAO;
using CompactDiscEntityFramework;
using Microsoft.Practices.Unity;

namespace CompactDiscRest.Controllers
{
    public class CompactDiscController : ApiController
    {

        private ICompactDiscService _service;


        public CompactDiscController(ICompactDiscService service)
        {
            this._service = service;
        }


        // GET: api/CompactDisc
        public List<CompactDisc> Get()
        {
            return _service.GetCatalog();
        }

        // GET: api/CompactDisc/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CompactDisc
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CompactDisc/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CompactDisc/5
        public void Delete(int id)
        {
        }
    }
}
