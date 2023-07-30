namespace _4Create.Entities.Models.Middle
{
    public class EmployeeCompany
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
