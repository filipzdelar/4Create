using _4Create.Entities.Abstractions;
using _4Create.Entities.Enums;
using _4Create.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;


namespace _4Create.Entities.Models
{
    [Table("Employees")]
    public class Employee : AbstractUser, IEntity
    {
        #region Properties
        public Title Title { get; set; }
        #endregion

        #region Navigation
        [InverseProperty("Employees")]
        public ICollection<Company> Companies { get; set; } = new List<Company>();
        #endregion

        #region Constructor's
        public Employee() { }

        public Employee(long Id, string Email, Title Title) { this.Id = Id; this.Email = Email; this.Title = Title; }
        #endregion
    }
}
