using Microsoft.EntityFrameworkCore;
using place.Models;

namespace place.Data
{
    public class PlaceContext : DbContext
    {
        public PlaceContext(DbContextOptions<PlaceContext> options): base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Publication> Publications { get; set; }


        //Pour que le nom des tables soient au singulier dans la B.D.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilisateur>().ToTable("Utilisateur");
            modelBuilder.Entity<Categorie>().ToTable("Categorie");
            modelBuilder.Entity<Publication>().ToTable("Publication");
        }
    }
}
