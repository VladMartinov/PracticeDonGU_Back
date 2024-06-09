namespace PracticeDonGU_Back.Models
{
    public class Record
    {
        public DateTime RecordDate { get; set; } = DateTime.Now;

        public uint MineralId {  get; set; }
        public Mineral Mineral { get; set; } = new Mineral();

        public uint? UnitId { get; set; }
        public Unit? Unit { get; set; }

        public float RecordValue { get; set; } = 0;
    }
}
