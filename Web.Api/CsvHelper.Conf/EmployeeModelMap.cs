using Web.Api.Helpers;
using CsvHelper.Configuration;
using Web.Api.Models;

namespace Web.Api.CsvHelper.Conf
{
    public class EmployeeModelMap : ClassMap<EmployeeModel>
    {
        public EmployeeModelMap()
        {
            Map(m => m.EmpId).Name("EmpId");
            Map(m => m.ProjectId).Name("ProjectId");
            Map(m => m.DateFrom).Name("DateFrom").TypeConverter<CustomDateTimeConverter>();
            Map(m => m.DateTo).Name("DateTo").TypeConverter<CustomDateTimeConverter>();
        }
    }
}