using PracticeDonGU_Back.Helpers;

namespace PracticeDonGU_Back.Service
{
    public interface IMineralsService
    {
        public ResultObject GetMineral(uint mineralId);
        public ResultObject GetMinerals();
        public ResultObject PostMineral(string mineralName);
        public ResultObject PutMineral(uint mineralId, string mineralName);
        public ResultObject DeleteMineral(uint mineralId);

    }
}
