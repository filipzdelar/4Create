using _4Create.Entities.Enums;
using _4Create.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _4Create.Data;
using System.Data;

namespace _4Create.Entities.Models
{

    [Table("Companies")]
    public class Company : IEntity, ICreaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }


        [Required(ErrorMessage = "Name is required.")]
        [StringLength(200, ErrorMessage = "Firstname can't be longer than 200 characters.")]
        public Title Title { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();


        public Company() { }

        public Company(long Id, DateTime CreatedAt, Title Title, string Email) 
        { 
            this.Id = Id; 
            this.CreatedAt = CreatedAt; 
            this.Title = Title;
            this.Email = Email;
        }
    }
}
