namespace DotNetCoreWebAPI.Models
{
    public class UserSaveDto : BaseDto
    {
        public int UserId { get; set; }

        public int ClientId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Notes { get; set; }

    }
}
