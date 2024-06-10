using PracticeDonGU_Back.Models;

namespace PracticeDonGU_Back.DTOs
{
    public class RestfulRecord
    {
        public DateTime RecordDate { get; set; } = DateTime.Now;
        public uint MineralId { get; set; } = 0;
        public uint? UnitId { get; set; } = 0;
        public float RecordValue { get; set; } = 0;

        public RestfulRecord() { }

        public RestfulRecord(Record record)
        {
            RecordDate = record.RecordDate;
            MineralId = record.MineralId;
            if (record.UnitId != null) UnitId = record.UnitId;
            RecordValue = record.RecordValue;
        }
    }
}
