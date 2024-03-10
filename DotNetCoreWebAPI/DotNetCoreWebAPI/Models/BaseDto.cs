namespace DotNetCoreWebAPI.Models
{
    public class BaseDto
    {
        public string CreatedBy { get; set; } = "Spatel";

        public DateTime CreatedWhen { get; set; } = DateTime.UtcNow;

        public string TouchedBy { get; set; } = "Spatel";

        public DateTime TouchedWhen { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;
    }
}
