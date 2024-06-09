using System.ComponentModel.DataAnnotations;

namespace PracticeDonGU_Back.Models
{
    public class Mineral
    {
        public uint MineralId { get; set; }

        [MaxLength(100)]
        public string MineralName { get; set; } = string.Empty;

        public List<Record>? Records { get; set; }
    }
}
