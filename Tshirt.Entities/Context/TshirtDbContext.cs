using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tshirt.Entities.Entities;

#nullable disable

namespace Tshirt.Entities.Context
{
    public partial class TshirtDbContext : DbContext
    {
        public TshirtDbContext()
        {
        }

        public TshirtDbContext(DbContextOptions<TshirtDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EnmColor> EnmColors { get; set; }
        public virtual DbSet<EnmFabric> EnmFabrics { get; set; }
        public virtual DbSet<Tshirt.Entities.Entities.Tshirt> Tshirts { get; set; }
        public virtual DbSet<TshirtImage> TshirtImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DMGK25P;Database=TshirtApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<EnmColor>(entity =>
            {
                entity.ToTable("enmColors");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnmFabric>(entity =>
            {
                entity.ToTable("enmFabrics");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tshirt.Entities.Entities.Tshirt>(entity =>
            {
                entity.ToTable("Tshirt");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TshirtImage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.TshirtImages)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TshirtImages_enmColors");

                entity.HasOne(d => d.Fabric)
                    .WithMany(p => p.TshirtImages)
                    .HasForeignKey(d => d.FabricId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TshirtImages_enmFabrics");

                entity.HasOne(d => d.Tshirt)
                    .WithMany(p => p.TshirtImages)
                    .HasForeignKey(d => d.TshirtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TshirtImages_Tshirt");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
