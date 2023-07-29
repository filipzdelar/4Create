using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using _4Create.Entities.Interfaces;

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

        [Required(ErrorMessage = "Changeset is required.")]
        [StringLength(200, ErrorMessage = "Changeset can't be longer than 40 characters.")]
        public string? Changeset { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        [StringLength(200, ErrorMessage = "Comment can't be longer than 200 characters.")]
        public string? Comment { get; set; }
    }
}
