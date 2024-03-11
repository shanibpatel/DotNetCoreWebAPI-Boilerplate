using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPI.Data
{
    public class WebAPIDBContext : DbContext
    {
        public WebAPIDBContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Clients> Clients { get; set; }

        DbSet<Users> Users { get; set; }
    }
}
