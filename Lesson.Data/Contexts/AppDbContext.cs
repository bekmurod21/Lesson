using Lesson.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lesson.Data.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        DbSet<User> Users { get; set; }
    }
}
