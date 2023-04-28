using LessonTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LessonTask.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
    }
}
