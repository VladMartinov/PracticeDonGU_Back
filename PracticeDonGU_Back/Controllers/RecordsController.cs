using Microsoft.AspNetCore.Mvc;
using PracticeDonGU_Back.Contexts;
using PracticeDonGU_Back.DTOs;
using PracticeDonGU_Back.Helpers;
using PracticeDonGU_Back.Service;

namespace PracticeDonGU_Back.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/records")]
    public class RecordsController(PracticeDbContext context) : Controller
    {
        private readonly RecordsService _recordsService = new (context);

        // GET api/records/all
        /// <summary>
        /// Get records
        /// </summary>
        /// <returns>Records objects list</returns>
        [HttpGet("all")]
        [ProducesResponseType(typeof(List<RestfulRecord>), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetRecords()
        {
            ResultObject result = _recordsService.GetRecords();

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return Ok(result.Object);
        }

        // GET api/records
        /// <summary>
        /// Get record
        /// </summary>
        /// <param name="recordDate">Record Date</param>
        /// <param name="mineralId">Mineral ID</param>
        /// <returns>Record object</returns>
        [HttpGet("single")]
        [ProducesResponseType(typeof(RestfulRecord), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetRecord(DateTime recordDate, uint mineralId)
        {
            ResultObject result = _recordsService.GetRecord(recordDate, mineralId);

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status404NotFound);
            return Ok(result.Object);
        }

        // POST api/records
        /// <summary>
        /// Create new record
        /// </summary>
        /// <param name="record">Record object</param>
        /// <returns>Record object</returns>
        [HttpPost]
        [ProducesResponseType(typeof(RestfulRecord), 200)]
        [ProducesResponseType(400)]
        public IActionResult CreateRecord(RestfulRecord record)
        {
            ResultObject result = _recordsService.PostRecord(record.RecordDate, record.MineralId, record.UnitId, record.RecordValue);

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status400BadRequest);
            return Ok(result.Object);
        }

        // PUT api/records
        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="record">Record object</param>
        /// <returns>Record object</returns>
        [HttpPut]
        [ProducesResponseType(typeof(RestfulRecord), 200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRecord(RestfulRecord record)
        {
            ResultObject result = _recordsService.PutRecord(record.RecordDate, record.MineralId, record.UnitId, record.RecordValue);

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status404NotFound);
            return Ok(result.Object);
        }

        // DELETE api/records/{id}
        /// <summary>
        /// Delete record
        /// </summary>
        /// <param name="recordDate">Record Date</param>
        /// <param name="mineralId">Mineral ID</param>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRecord(DateTime recordDate, uint mineralId)
        {
            ResultObject result = _recordsService.DeleteRecord(recordDate, mineralId);

            if (!result.Success) return new StatusCodeResult(StatusCodes.Status404NotFound);
            return Ok();
        }
    }
}
