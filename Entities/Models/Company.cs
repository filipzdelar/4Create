using _4Create.Entities.Base;
using _4Create.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4Create.Entities.Models
{

    [Table("Companies")]
    public class Company : IEntity, ICreaction
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public string Title { get; set; }
    }
}
