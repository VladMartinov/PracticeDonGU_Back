using PracticeDonGU_Back.Helpers;

namespace PracticeDonGU_Back.Service
{
    public interface IRecordsService
    {
        public ResultObject GetRecord(DateTime recordDate, uint mineralId);
        public ResultObject GetRecords();
        public ResultObject PostRecord(DateTime recordDate, uint mineralId, uint? unitId, float recordValue);
        public ResultObject PutRecord(DateTime recordDate, uint mineralId, uint? unitId, float recordValue);
        public ResultObject DeleteRecord(DateTime recordDate, uint mineralId);

    }
}
