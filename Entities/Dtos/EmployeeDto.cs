using _4Create.Entities.Enums;

namespace _4Create.Entities.Dtos
{
    public class EmployeeDto
    {
        public long Id { get; set; }

        public Title Title { get; set; }

        public string Email { get; set; }
    }
}
