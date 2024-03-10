using DotNetCoreWebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWebAPI.Data
{
    public class Clients : BaseDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [Required]
        [StringLength(50)]
        public string ClientCode { get; set; }

        [Required]
        [StringLength(100)]
        public string ClientName { get; set; }

        [StringLength(100)]
        public string ContactPerson { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(15)]
        public string MobileNo { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }
    }
}
