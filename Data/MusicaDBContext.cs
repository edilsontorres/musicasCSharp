using Microsoft.EntityFrameworkCore;
using Musica.Models;


namespace Musica.Data 
{
    public class MusicaDBContext : DbContext
    {
        public MusicaDBContext(DbContextOptions<MusicaDBContext> options) : base(options)
        {
        }
        
        public DbSet<MusicaModel> ?musicas { get; set; }
    }
}