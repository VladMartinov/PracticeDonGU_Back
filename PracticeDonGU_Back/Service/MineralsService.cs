using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeDonGU_Back.Contexts;
using PracticeDonGU_Back.DTOs;
using PracticeDonGU_Back.Helpers;
using PracticeDonGU_Back.Models;

namespace PracticeDonGU_Back.Service
{
    public class MineralsService : IMineralsService
    {
        private readonly PracticeDbContext _context;

        public MineralsService(PracticeDbContext context)
        {
            _context = context;
        }

        public ResultObject GetMineral(uint mineralId)
        {
            var result = new ResultObject();

            var mineral = _context.Minerals.FirstOrDefault(m => m.MineralId == mineralId);
            
            if (mineral != null)
            {
                result.Success = true;
                result.Message = "Mineral found";
                result.Result = new StatusCodeResult(StatusCodes.Status200OK);
                result.Object = new RestfulMineral(mineral);
            }
            else
            {
                result.Message = "Mineral not found";
                result.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return result;
        }

        public ResultObject GetMinerals()
        {
            var result = new ResultObject();

            List<Mineral> minerals = _context.Minerals.ToList();
            List<RestfulMineral> restfulMinals = minerals.Select(m => new RestfulMineral(m)).ToList();

            result.Success = true;
            result.Message = "Minerals founded";
            result.Result = new StatusCodeResult(StatusCodes.Status200OK);
            result.Object = restfulMinals;

            return result;
        }

        public ResultObject PostMineral(string mineralName)
        {
            var result = new ResultObject();

            var minerals = _context.Minerals.FromSqlRaw("EXEC CREATE_MINERAL @p0", mineralName).ToList();

            if (minerals.Count > 0)
            {
                result.Success = true;
                result.Message = "Mineral created successfully";
                result.Result = new StatusCodeResult(StatusCodes.Status200OK);
                result.Object = new RestfulMineral(minerals.First());
            }
            else
            {
                result.Message = "Error creating mineral";
                result.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            return result;
        }

        public ResultObject PutMineral(uint mineralId, string mineralName)
        {
            var result = new ResultObject();

            var minerals = _context.Minerals.FromSqlRaw("EXEC UPDATE_MINERAL @p0, @p1", mineralId, mineralName).ToList();

            if (minerals.Count > 0)
            {
                result.Success = true;
                result.Message = "Mineral updated successfully";
                result.Result = new StatusCodeResult(StatusCodes.Status200OK);
                result.Object = new RestfulMineral(minerals.First());
            }
            else
            {
                result.Message = "Error update mineral";
                result.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return result;
        }

        public ResultObject DeleteMineral(uint mineralId)
        {
            var result = new ResultObject();

            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC DELETE_MINERAL @p0", mineralId);

            if (rowsAffected > 0)
            {
                result.Success = true;
                result.Message = "Mineral deleted successfully";
                result.Result = new StatusCodeResult(StatusCodes.Status200OK);
            }
            else
            {
                result.Message = "Error deleting mineral";
                result.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return result;
        }
    }
}
