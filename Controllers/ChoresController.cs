using chores_backend.Data.Repositories;
using chores_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chores_backend.Controllers
{
    [Authorize]
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
            //TODO: Change orderby title to order by date added
            return _choresRepository.GetAll().OrderBy(c => c.Title);
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
