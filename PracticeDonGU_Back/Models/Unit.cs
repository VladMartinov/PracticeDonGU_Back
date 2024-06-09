using System.ComponentModel.DataAnnotations;

namespace PracticeDonGU_Back.Models
{
    public class Unit
    {
        public uint UnitId { get; set; }

        [MaxLength(100)]
        public string UnitName { get; set; } = string.Empty;
        public float UnitValue { get; set; } = 0;

        public List<Record>? Records { get; set; }
    }
}
