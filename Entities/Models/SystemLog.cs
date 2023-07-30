using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _4Create.Entities.Interfaces;
using _4Create.Entities.Enums;

namespace _4Create.Entities.Models
{
    public class SystemLog : IEntity, ICreaction
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public ResourceType ResourceType { get; set; }
        public long ResourceId { get; set; }
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Event is required.")]
        [StringLength(200, ErrorMessage = "Event can't be longer than 200 characters.")]
        public string? Event { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        [StringLength(200, ErrorMessage = "Comment can't be longer than 200 characters.")]
        public string? Comment { get; set; }

        [Required(ErrorMessage = "Attributes are required.")]
        [StringLength(2000, ErrorMessage = "Attributes can't be longer than 2000 characters.")]
        public string? ResourceAttributes { get; set; }
    }
}
