using Microsoft.EntityFrameworkCore;

namespace Session05.Crud.UI.Entities
{
    public class CourseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=Session05; integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasQueryFilter(c => c.Fired == false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
