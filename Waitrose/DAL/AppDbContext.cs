using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Waitrose.Models;

namespace Waitrose.DAL
{
    public class AppDbContext : IdentityDbContext<AppEmployee>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassSection> ClassSections { get; set; }
        public DbSet<Parent > Parents { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<StudentParent> StudentParents { get; set; }
    }
}
