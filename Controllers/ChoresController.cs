using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chores_backend.Data;
using chores_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chores_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoresController : ControllerBase
    {
        private readonly IChoresRepository _choresRepository;

        public ChoresController(IChoresRepository choresRepository)
        {
            _choresRepository = choresRepository;
        }
        
        // GET: api/Chores
        [HttpGet]
        public IEnumerable<Chore> Get()
        {
            //TODO: Changer orderby title to order by date added
            return _choresRepository.GetAll().OrderBy(c => c.Title);
        }

        // GET: api/Chores/5
        [HttpGet("{id}", Name = "Get")]
        private string Get(int id)
        {
            return "value";
        }

        // POST: api/Chores
        [HttpPost]
        private void Post([FromBody] string value)
        {
        }

        // PUT: api/Chores/5
        [HttpPut("{id}")]
        private void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Chores/5
        [HttpDelete("{id}")]
        private void Delete(int id)
        {
        }
    }
}
