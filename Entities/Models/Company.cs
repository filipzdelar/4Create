using _4Create.Entities.Enums;
using _4Create.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4Create.Entities.Models
{

    [Table("Companies")]
    public class Company : IEntity, ICreaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        //public DateTime CreatedAt { get; set; }

        //public Title Title { get; set; }
        public string Email { get; set; }
    }
}
