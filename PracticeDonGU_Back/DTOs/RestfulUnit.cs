using PracticeDonGU_Back.Models;

namespace PracticeDonGU_Back.DTOs
{
    public class RestfulUnit
    {
        public uint UnitId { get; set; } = 0;
        public string UnitName { get; set; } = string.Empty;
        public float UnitValue { get; set; } = 0;

        public RestfulUnit() { }

        public RestfulUnit(Unit unit)
        {
            UnitId = unit.UnitId;
            UnitName = unit.UnitName;
            UnitValue = unit.UnitValue;
        }
    }
}
