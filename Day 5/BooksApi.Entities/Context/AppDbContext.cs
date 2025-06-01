using Microsoft.EntityFrameworkCore;
using BooksApi.Entities.Entities;

namespace BooksApi.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } // This maps to the Users table
    }
}