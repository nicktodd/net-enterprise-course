using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreWeb.Repository;

namespace NetCoreWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompactDiscController : ControllerBase
    {
        // injected by the dependency injection setup in Startup.cs
        ICompactDiscRepository repository;

        public CompactDiscController(ICompactDiscRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompactDisc>> Get()
        {
            return new ActionResult<IEnumerable<CompactDisc>>(repository.GetAllCompactDiscs());
        }


        [HttpGet("{id}")]
        public ActionResult<CompactDisc> Get(int id)
        {
            return new ActionResult<CompactDisc>(repository.GetCompactDiscById(id));
        }


        [HttpPost]
        public void Post([FromBody] CompactDisc disc)
        {
            repository.AddCompactDisc(disc);
        }


        [HttpPut]
        public void Put([FromBody] CompactDisc disc)
        {
            repository.UpdateCompactDisc(disc);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteCompactDisc(id);
        }

    }
}
