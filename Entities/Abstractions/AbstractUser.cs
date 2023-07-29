using _4Create.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4Create.Entities.Abstractions
{
    /// <summary>
    /// Abstract class for applicaton's users
    /// </summary>
    public abstract class AbstractUser : IEntity, ICreaction
    {
        #region Properties
        /// <summary>
        /// Database Primary Key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// User's email
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [StringLength(128, ErrorMessage = "Email can't be longer than 128 characters.")]
        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; }
        #endregion


    }
}
