using DotNetCoreWebAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreWebAPI.Data
{
    public class Users : BaseDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [ForeignKey("Clients")]
        public int ClientId { get; set; }

        [Required]
        [StringLength(40)] // Adjust the maximum length as needed
        public string UserName { get; set; }

        [Required]
        [StringLength(40)] // Adjust the maximum length as needed
        public string Password { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public virtual Clients Clients { get; set; } = null!;
    }
}
