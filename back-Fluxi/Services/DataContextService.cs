using back_Fluxi.Models;
using Microsoft.EntityFrameworkCore;

namespace back_Fluxi.Services
{

    public class DataContextService : DbContext
    {
        //public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public List<Video> Include { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\fluxi;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoActeur>().HasKey(sc => new { sc.VideoID, sc.ActeurId });
        }
    }
}
