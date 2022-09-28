using Assignment4.Managers;
using Microsoft.AspNetCore.Mvc;
using OLAClassLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();

        // GET: api/<FootballPlayersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<FootballPlayer>> Get()
        {
            IEnumerable<FootballPlayer> data = _manager.GetAll();
            if (data.Count() == 0) return NoContent();
            return Ok(data);
        }

        // GET api/<FootballPlayersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Get(int id)
        {
            FootballPlayer? player = _manager.GetById(id);
            if (player == null) return NotFound();
            return Ok(player);
        }

        // POST api/<FootballPlayersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer value)
        {
            if (value == null) return BadRequest();
            FootballPlayer player = _manager.Add(value);
            return Created($"api/FootballPlayers/{player.Id}", player);
        }

        // PUT api/<FootballPlayersController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
        {
            if (value == null) return NotFound();
            FootballPlayer? player = _manager.Update(id, value);
            return Ok(player);
        }

        // DELETE api/<FootballPlayersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer? player = _manager.GetById(id);
            if (player == null) return NotFound();
            _manager.Delete(player.Id);
            return Ok(player);
        }
    }
}
