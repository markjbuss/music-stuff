using System.Data.Entity;

namespace MarkMusic.Db
{
    public class MarkMusicContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}