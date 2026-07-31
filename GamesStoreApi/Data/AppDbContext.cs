using GamesStoreApi.Models;
using Microsoft.EntityFrameworkCore;
namespace GamesStoreApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
    }
}
