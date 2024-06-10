using PracticeDonGU_Back.Helpers;

namespace PracticeDonGU_Back.Service
{
    public interface IUnitsService
    {
        public ResultObject GetUnit(uint unitId);
        public ResultObject GetUnits();
        public ResultObject PostUnit(string unitName, float unitValue);
        public ResultObject PutUnit(uint unitId, string unitName, float unitValue);
        public ResultObject DeleteUnit(uint unitId);

    }
}
