using DotNetCoreWebAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreWebAPI.Data
{
    public class Customer : BaseDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [ForeignKey("Clients")]
        public int ClientId { get; set; }

        [Required]
        [StringLength(40)]
        public string CustomerName { get; set; }

        [StringLength(15)]
        public string MobileNo { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(150)]
        public string Locality { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public virtual Clients Clients { get; set; } = null!;
    }
}
