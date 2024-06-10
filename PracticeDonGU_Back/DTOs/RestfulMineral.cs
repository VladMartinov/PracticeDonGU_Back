using PracticeDonGU_Back.Models;

namespace PracticeDonGU_Back.DTOs
{
    public class RestfulMineral
    {
        public uint MineralId { get; set; } = 0;
        public string MineralName { get; set; } = string.Empty;

        public RestfulMineral() { }

        public RestfulMineral(Mineral mineral)
        {
            MineralId = mineral.MineralId;
            MineralName = mineral.MineralName;
        }
    }
}
