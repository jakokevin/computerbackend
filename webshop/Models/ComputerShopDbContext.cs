using Microsoft.EntityFrameworkCore;

namespace webshop.Models
{
    public class ComputerShopDbContext : DbContext
    {
        public ComputerShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public ComputerShopDbContext()
        {
        }

        public DbSet<Osystem> Osystems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = "server=localhost;database=computershop13a;uid=root;password=";

            optionsBuilder.UseMySql(conn,ServerVersion.AutoDetect(conn));
        }


    }
}
