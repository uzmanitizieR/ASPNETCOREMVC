using Microsoft.EntityFrameworkCore;
using ASPNETCOREMVCPROJE.Models;

namespace ASPNETCOREMVCPROJE.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        // DbSet<User> özelliği ile Users tablosu oluşturulacak
        public DbSet<User> Users { get; set; }
    }
}
