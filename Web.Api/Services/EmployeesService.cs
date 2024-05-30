using Web.Api.Interfaces;
using Web.Api.Models;
using Web.Api.Utils;

namespace Web.Api.Services
{
    public class EmployeesService : IEmployeeService
    {
        public IList<PairEmployeesModel> GetLongestWorkingPair(IList<EmployeeModel> employees)
        {
            var overlaps = employees
            .SelectMany((emp1, index1) => employees
                .Where((emp2, index2) => emp1.ProjectId == emp2.ProjectId && index1 < index2)
                .Select(emp2 => new
                {
                    EmpId1 = emp1.EmpId,
                    EmpId2 = emp2.EmpId,
                    ProjectId = emp1.ProjectId,
                    DaysWorked = CalculateDatetime.Overlap(emp1.DateFrom, emp1.DateTo ?? DateTime.Now, emp2.DateFrom, emp2.DateTo ?? DateTime.Now)
                })
                .Where(pair => pair.DaysWorked > 0)
            );

            var groupedOverlaps = overlaps
                .GroupBy(pair => new { pair.EmpId1, pair.EmpId2, pair.ProjectId })
                .Select(group => new PairEmployeesModel
                {
                    EmpId1 = group.Key.EmpId1,
                    EmpId2 = group.Key.EmpId2,
                    ProjectId = group.Key.ProjectId,
                    DaysWorked = group.Sum(pair => pair.DaysWorked)
                })
                .OrderByDescending(pair => pair.DaysWorked)
                .ToList();

            return groupedOverlaps;
        }
    }
}
