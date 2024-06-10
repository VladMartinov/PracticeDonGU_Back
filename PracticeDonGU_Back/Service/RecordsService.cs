using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeDonGU_Back.Contexts;
using PracticeDonGU_Back.DTOs;
using PracticeDonGU_Back.Helpers;
using PracticeDonGU_Back.Models;

namespace PracticeDonGU_Back.Service
{
    public class RecordsService(PracticeDbContext context) : IRecordsService
    {
        private readonly PracticeDbContext _context = context;

        public ResultObject GetRecord(DateTime recordDate, uint mineralId)
        {
            var result = new ResultObject();

            var record = _context.Records.FirstOrDefault(r => r.RecordDate == recordDate && r.MineralId == mineralId);
            
            if (record != null)
            {
                result.Success = true;
                result.Message = "Record found";
                result.Result = new StatusCodeResult(StatusCodes.Status200OK);
                result.Object = new RestfulRecord(record);
            }
            else
            {
                result.Message = "Record not found";
                result.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return result;
        }

        public ResultObject GetRecords()
        {
            var result = new ResultObject();

            List<Record> records = _context.Records.ToList();
            List<RestfulRecord> restfulMinals = records.Select(r => new RestfulRecord(r)).ToList();

            result.Success = true;
            result.Message = "Records founded";
            result.Result = new StatusCodeResult(StatusCodes.Status200OK);
            result.Object = restfulMinals;

            return result;
        }

        public ResultObject PostRecord(DateTime recordDate, uint mineralId, uint? unitId, float recordValue)
        {
            var result = new ResultObject();

            var records = _context.Records.FromSqlRaw("EXEC CREATE_RECORD @p0, @p1, @p2, @p3", recordDate, mineralId, unitId, recordValue).ToList();

            if (records.Count > 0)
            {
                result.Success = true;
                result.Message = "Record created successfully";
                result.Result = new StatusCodeResult(StatusCodes.Status200OK);
                result.Object = new RestfulRecord(records.First());
            }
            else
            {
                result.Message = "Error creating record";
                result.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            return result;
        }

        public ResultObject PutRecord(DateTime recordDate, uint mineralId, uint? unitId, float recordValue)
        {
            var result = new ResultObject();

            var records = _context.Records.FromSqlRaw("EXEC UPDATE_RECORD @p0, @p1, @p2, @p3", recordDate, mineralId, unitId, recordValue).ToList();

            if (records.Count > 0)
            {
                result.Success = true;
                result.Message = "Record updated successfully";
                result.Result = new StatusCodeResult(StatusCodes.Status200OK);
                result.Object = new RestfulRecord(records.First());
            }
            else
            {
                result.Message = "Error update record";
                result.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return result;
        }

        public ResultObject DeleteRecord(DateTime recordDate, uint mineralId)
        {
            var result = new ResultObject();

            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC DELETE_RECORD @p0, @p1", recordDate, mineralId);

            if (rowsAffected > 0)
            {
                result.Success = true;
                result.Message = "Record deleted successfully";
                result.Result = new StatusCodeResult(StatusCodes.Status200OK);
            }
            else
            {
                result.Message = "Error deleting record";
                result.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return result;
        }
    }
}
