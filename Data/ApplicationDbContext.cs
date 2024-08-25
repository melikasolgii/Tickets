using Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Tickets.Domains;

namespace Tickets.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Ctor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        { }

        #endregion

        #region Db sets

        public DbSet<User> Users { get; set; }
 

        #endregion

        #region Model creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
        }

        #endregion
    }
}
