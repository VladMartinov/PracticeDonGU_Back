using Microsoft.AspNetCore.Mvc;
using PracticeDonGU_Back.Contexts;
using PracticeDonGU_Back.DTOs;
using PracticeDonGU_Back.Helpers;
using PracticeDonGU_Back.Service;

namespace PracticeDonGU_Back.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/units")]
    public class UnitsController(PracticeDbContext context) : Controller
    {
        private readonly UnitsService _unitsService = new (context);

        // GET api/units
        /// <summary>
        /// Get units
        /// </summary>
        /// <returns>Units objects list</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<RestfulUnit>), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetUnits()
        {
            ResultObject result = _unitsService.GetUnits();

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return Ok(result.Object);
        }

        // GET api/units/{id}
        /// <summary>
        /// Get unit
        /// </summary>
        /// <param name="id">Unit ID</param>
        /// <returns>Unit object</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RestfulUnit), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetUnit(uint id)
        {
            ResultObject result = _unitsService.GetUnit(id);

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status404NotFound);
            return Ok(result.Object);
        }

        // POST api/units
        /// <summary>
        /// Create new unit
        /// </summary>
        /// <param name="unit">Unit object</param>
        /// <returns>Unit object</returns>
        [HttpPost]
        [ProducesResponseType(typeof(RestfulUnit), 200)]
        [ProducesResponseType(400)]
        public IActionResult CreateUnit(RestfulUnit unit)
        {
            ResultObject result = _unitsService.PostUnit(unit.UnitName, unit.UnitValue);

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status400BadRequest);
            return Ok(result.Object);
        }

        // PUT api/units/{id}
        /// <summary>
        /// Update unit
        /// </summary>
        /// <param name="id">Unit ID</param>
        /// <param name="unit">Unit object</param>
        /// <returns>Unit object</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RestfulUnit), 200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUnit(uint id, RestfulUnit unit)
        {
            ResultObject result = _unitsService.PutUnit(id, unit.UnitName, unit.UnitValue);

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status404NotFound);
            return Ok(result.Object);
        }

        // DELETE api/units/{id}
        /// <summary>
        /// Delete unit
        /// </summary>
        /// <param name="id">Unit ID</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUnit(uint id)
        {
            ResultObject result = _unitsService.DeleteUnit(id);

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status404NotFound);
            return Ok();
        }
    }
}
