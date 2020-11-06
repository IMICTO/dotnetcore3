using Microsoft.EntityFrameworkCore;
using Session06.NoneRelational.Entities;
using System;

namespace Session06.NoneRelational.DAL
{
    public class BlogContext:DbContext
    {
        public DbSet<Blog> Blogs{ get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Initial catalog=BlogContext;Integrated Security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
