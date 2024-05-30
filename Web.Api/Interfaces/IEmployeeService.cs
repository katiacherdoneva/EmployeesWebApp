using Web.Api.Models;

namespace Web.Api.Interfaces
{
    public interface IEmployeeService
    {
        public IList<PairEmployeesModel> GetLongestWorkingPair(IList<EmployeeModel> employees);
    }
}
