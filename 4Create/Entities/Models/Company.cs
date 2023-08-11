using _4Create.Entities.Enums;
using _4Create.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _4Create.Data;
using System.Data;
using _4Create.Migrations;

namespace _4Create.Entities.Models
{

    [Table("Companies")]
    public class Company : IEntity, ICreaction
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(128, ErrorMessage = "Name can't be longer than 128 characters.")]
        public string Name { get; set; }
        #endregion

        #region Navigation
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        #endregion

        #region Constructor's
        public Company()
        { }

        public Company(long Id, DateTime CreatedAt, string Name, ICollection<Employee> Employees) 
        { 
            this.Id = Id; 
            this.CreatedAt = CreatedAt; 
            this.Name = Name;
            this.Employees = Employees;
        }
        #endregion
    }
}
