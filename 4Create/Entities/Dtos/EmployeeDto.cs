using _4Create.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace _4Create.Entities.Dtos
{
    public class EmployeeDto
    {

        [Required(ErrorMessage = "Title is required.")]
        [EnumDataType(typeof(Title), ErrorMessage = "Invalid title.")]
        public Title Title { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(128, ErrorMessage = "Email can't be longer than 128 characters.")]
        public string? Email { get; set; }

        public List<long>? CompanyIds { get; set; }
    }
}
