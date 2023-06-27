using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chores_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chores_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoresController : ControllerBase
    {
        private List<Chore> chores = new ()
        {
            new Chore() {Id = "1", Title = "Do the dishes", Description = "I want you to do the dishes"},
            new Chore() {Id = "2", Title = "Clean the livingroom", Description = "I want you to clean the living room"},
            new Chore() {Id = "3", Title = "Mow the lawn", Description = "I want you to mow the lawn"},
            new Chore() {Id = "4", Title = "Remove dust in the kitchen", Description = "I want you to remove dust in the kitchen"},
            new Chore() {Id = "5", Title = "Clean the toilet", Description = "I want you to clean the toilet"},
            new Chore() {Id = "6", Title = "Clean your room", Description = "I want you to clean your room"},
            new Chore() {Id = "7", Title = "Clean the bathroom", Description = "I want you to clean the bathroom"},
            new Chore() {Id = "8", Title = "Clean the garage", Description = "I want you to clean the garage"},
        };
        // GET: api/Chores
        [HttpGet]
        public IEnumerable<Chore> Get()
        {
            return chores;
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
