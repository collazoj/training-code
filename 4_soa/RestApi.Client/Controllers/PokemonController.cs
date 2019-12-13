using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApi.Data;
using RestApi.Data.Models;

namespace RestApi.Client.Controllers
{
    [Produces("application/json")]  //Web service returns the format of the request. This filter returns json. Recommended that you pick 1 data format.
    // [Consumes("application/xml")]
    [Route("api/[Controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonDbContext _db;
        // private ILogger _logger;

        public PokemonController(PokemonDbContext dbContext)
        {
          _db = dbContext;
          // _logger = logger;
        }

        [HttpGet]
        // public IActionResult Get()
        public async Task<IActionResult> Get()
        {
          // return NotFound(pokemons);
          // return OK(pokemons);      //"Ok" checks data and then gives it
          // _logger.LogInformation("Get Methods");
          return await Task.Run(() => { return Ok(_db.Pokemon.ToList());});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
          // return pokemons[id-1];
          // _logger.LogInformation($"Get by Id Method{id}");
          return await Task.FromResult(Ok(_db.Pokemon.FirstOrDefault(p=> p.Id ==id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pokemon poke)
        {
          if (ModelState.IsValid)
          {
            _db.Pokemon.Add(poke);
            _db.SaveChanges();    //add and save first

            return await Task.FromResult(Ok(poke));
          }
          return await Task.FromResult(NotFound(poke));
        }
    }
}