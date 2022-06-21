using Common.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Common.Data
{
    public class BaseDataContext : DbContext
    {
        public DbSet<Parent> Parents { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public BaseDataContext(DbContextOptions<BaseDataContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Column names are lowercase in PostgreSQL
            builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .ToList()
                .ForEach(p => p.SetColumnName(p.Name.ToLower()));
        }
        
    }
}
