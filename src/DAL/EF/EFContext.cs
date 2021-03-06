using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using POC.DAL.Entities;

namespace POC.DAL
{
    public class EFContext : IdentityDbContext<User>
    {
        private readonly IConfiguration _config;

        public EFContext(IConfiguration config) : base()
        {
            _config = config;
            Database.EnsureCreated();
        }

        public DbSet<Canvas> Canvas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<InstagramMedia> InstagramMedias { get; set; }
        public DbSet<FileEntity> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Local"),
            cfg => cfg.MigrationsAssembly("POC.Web"));
        }
    }
}