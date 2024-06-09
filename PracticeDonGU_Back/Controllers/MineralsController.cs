using Microsoft.AspNetCore.Mvc;
using PracticeDonGU_Back.Contexts;
using PracticeDonGU_Back.DTOs;
using PracticeDonGU_Back.Helpers;
using PracticeDonGU_Back.Service;

namespace PracticeDonGU_Back.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/minerals")]
    public class MineralsController : Controller
    {
        private readonly PracticeDbContext _context;
        private readonly IMineralsService _mineralsService;

        public MineralsController(PracticeDbContext context)
        {
            _context = context;
            _mineralsService = new MineralsService(context);
        }

        // GET api/minerals
        /// <summary>
        /// Get minerals
        /// </summary>
        /// <returns>Minerals objects list</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<RestfulMineral>), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetMinerals()
        {
            ResultObject result = _mineralsService.GetMinerals();

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return Ok(result.Object);
        }

        // GET api/minerals/{id}
        /// <summary>
        /// Get mineral
        /// </summary>
        /// <param name="id">Mineral ID</param>
        /// <returns>Mineral object</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RestfulMineral), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetMineral(uint id)
        {
            ResultObject result = _mineralsService.GetMineral(id);

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status404NotFound);
            return Ok(result.Object);
        }

        // POST api/minerals
        /// <summary>
        /// Create new mineral
        /// </summary>
        /// <param name="mineral">Mineral object</param>
        /// <returns>Mineral object</returns>
        [HttpPost]
        [ProducesResponseType(typeof(RestfulMineral), 200)]
        [ProducesResponseType(400)]
        public IActionResult CreateMineral(RestfulMineral mineral)
        {
            ResultObject result = _mineralsService.PostMineral(mineral.MineralName);

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status400BadRequest);
            return Ok(result.Object);
        }

        // PUT api/minerals/{id}
        /// <summary>
        /// Update mineral
        /// </summary>
        /// <param name="id">Mineral ID</param>
        /// <param name="mineral">Mineral object</param>
        /// <returns>Mineral object</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RestfulMineral), 200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateMineral(uint id, RestfulMineral mineral)
        {
            ResultObject result = _mineralsService.PutMineral(id, mineral.MineralName);

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status404NotFound);
            return Ok(result.Object);
        }

        // DELETE api/minerals/{id}
        /// <summary>
        /// Delete mineral
        /// </summary>
        /// <param name="id">Mineral ID</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteMineral(uint id)
        {
            ResultObject result = _mineralsService.DeleteMineral(id);

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status404NotFound);
            return Ok();
        }
    }
}
