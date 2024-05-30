namespace Web.Api.Models
{
    public class PairEmployeesModel
    {
        public int EmpId1 { get; set; }

        public int EmpId2 { get; set; }

        public int ProjectId { get; set; }

        public long DaysWorked { get; set; }
    }
}
