using ITICDE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITICDE.Data
{
    public class CDEDBContext:DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<View> Views { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Team> Teams { get; set; }


        public CDEDBContext(DbContextOptions<CDEDBContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>().HasMany(f => f.InnerFolders).WithOne();

        }


    }
}
