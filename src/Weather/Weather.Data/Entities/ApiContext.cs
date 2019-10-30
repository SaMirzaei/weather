namespace Weather.Data.Entities
{
    using Microsoft.EntityFrameworkCore;

    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Information> Informations { get; set; }
    }
}
