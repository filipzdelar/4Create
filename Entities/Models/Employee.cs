using _4Create.Entities.Abstractions;
using _4Create.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;


namespace _4Create.Entities.Models
{
    [Table("Employees")]
    public class Employee : AbstractUser, IEntity
    {
        public ICollection<Company> Companies { get; set; } = new List<Company>();

        public Employee() { }

        public Employee(long Id, string Email) { this.Id = Id; this.Email = Email; }

    }
}
