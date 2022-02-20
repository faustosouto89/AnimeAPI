using Microsoft.EntityFrameworkCore;

namespace AnimeAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet <Anime> Animes { get; set; }
    }
}
