using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chores_backend.Models;
using chores_backend.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chores_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoresController : ControllerBase
    {
        private readonly ChoresDbContext _dbContext;

        public ChoresController(ChoresDbContext context)
        {
            _dbContext = context;
        }
        
        // GET: api/Chores
        [HttpGet]
        public IEnumerable<Chore> Get()
        {
            return _dbContext.Chores;
        }

        // GET: api/Chores/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Chores
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Chores/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Chores/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
