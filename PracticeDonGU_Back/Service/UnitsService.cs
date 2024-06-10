using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeDonGU_Back.Contexts;
using PracticeDonGU_Back.DTOs;
using PracticeDonGU_Back.Helpers;
using PracticeDonGU_Back.Models;

namespace PracticeDonGU_Back.Service
{
    public class UnitsService(PracticeDbContext context) : IUnitsService
    {
        private readonly PracticeDbContext _context = context;

        public ResultObject GetUnit(uint unitId)
        {
            var result = new ResultObject();

            var unit = _context.Units.FirstOrDefault(m => m.UnitId == unitId);
            
            if (unit != null)
            {
                result.Success = true;
                result.Message = "Unit found";
                result.Result = new StatusCodeResult(StatusCodes.Status200OK);
                result.Object = new RestfulUnit(unit);
            }
            else
            {
                result.Message = "Unit not found";
                result.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return result;
        }

        public ResultObject GetUnits()
        {
            var result = new ResultObject();

            List<Unit> units = _context.Units.ToList();
            List<RestfulUnit> restfulMinals = units.Select(m => new RestfulUnit(m)).ToList();

            result.Success = true;
            result.Message = "Units founded";
            result.Result = new StatusCodeResult(StatusCodes.Status200OK);
            result.Object = restfulMinals;

            return result;
        }

        public ResultObject PostUnit(string unitName, float unitValue)
        {
            var result = new ResultObject();

            var units = _context.Units.FromSqlRaw("EXEC CREATE_UNIT @p0, @p1", unitName, unitValue).ToList();

            if (units.Count > 0)
            {
                result.Success = true;
                result.Message = "Unit created successfully";
                result.Result = new StatusCodeResult(StatusCodes.Status200OK);
                result.Object = new RestfulUnit(units.First());
            }
            else
            {
                result.Message = "Error creating unit";
                result.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            return result;
        }

        public ResultObject PutUnit(uint unitId, string unitName, float unitValue)
        {
            var result = new ResultObject();

            var units = _context.Units.FromSqlRaw("EXEC UPDATE_UNIT @p0, @p1, @p2", unitId, unitName, unitValue).ToList();

            if (units.Count > 0)
            {
                result.Success = true;
                result.Message = "Unit updated successfully";
                result.Result = new StatusCodeResult(StatusCodes.Status200OK);
                result.Object = new RestfulUnit(units.First());
            }
            else
            {
                result.Message = "Error update unit";
                result.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return result;
        }

        public ResultObject DeleteUnit(uint unitId)
        {
            var result = new ResultObject();

            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC DELETE_UNIT @p0", unitId);

            if (rowsAffected > 0)
            {
                result.Success = true;
                result.Message = "Unit deleted successfully";
                result.Result = new StatusCodeResult(StatusCodes.Status200OK);
            }
            else
            {
                result.Message = "Error deleting unit";
                result.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return result;
        }
    }
}
