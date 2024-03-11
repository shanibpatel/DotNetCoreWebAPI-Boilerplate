namespace DotNetCoreWebAPI.Models
{
    public class CustomerSaveDto : BaseDto
    {

        public int CustomerId { get; set; }

        public int ClientId { get; set; }

        public string CustomerName { get; set; }

        public string MobileNo { get; set; }

        public string Address { get; set; }

        public string Locality { get; set; }

        public string Notes { get; set; }

    }
}
