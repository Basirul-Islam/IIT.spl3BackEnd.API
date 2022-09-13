using System.Reflection;
using IIT.spl3Backend.DB.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IIT.spl3Backend.DB.Models
{
    //use dbcontext
    public class DatabaseContext : DbContext
    {
        public readonly object entity;

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}
