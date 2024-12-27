using Microsoft.EntityFrameworkCore;
using StreamingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Data
{
    public class StreamingAppContext : DbContext
    {
        public StreamingAppContext(DbContextOptions<StreamingAppContext> options) : base(options)
        {

        }

        public DbSet<Producer> Producers { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region "Tables"
            modelBuilder.Entity<Producer>().ToTable("Producers");
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            #endregion

            #region "Primary Keys"

            modelBuilder.Entity<Serie>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Producer>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Genre>()
                .HasKey(g => g.Id);

            #endregion

            #region "RelationShips"

            modelBuilder.Entity<Serie>()
                .HasOne(s => s.Producer)
                .WithMany(p => p.Series)
                .HasForeignKey(s => s.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
                .HasOne(s => s.PrimaryGenre)
                .WithMany(g => g.PrimarySeries)
                .HasForeignKey(s => s.PrimaryGenreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
                .HasOne(s => s.SecondaryGenre)
                .WithMany(g => g.SecondarySeries)
                .HasForeignKey(s => s.SecondaryGenreId)
                .OnDelete(DeleteBehavior.NoAction);


            #endregion

            #region "Table Property Settings"

            #region "Serie"
            modelBuilder.Entity<Serie>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Serie>()
                .Property(s => s.CoverImage)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Serie>()
                .Property(s => s.VideoLink)
                .HasMaxLength(500)
                .IsRequired();

            #endregion

            #region "Producer"

            modelBuilder.Entity<Producer>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            #endregion

            #region "Genre"

            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .HasMaxLength(50)
                .IsRequired();

            #endregion

            #endregion
        }
    }
}
