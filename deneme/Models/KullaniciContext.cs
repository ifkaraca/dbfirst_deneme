using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace deneme.Models
{
    public partial class KullaniciContext : DbContext
    {
        public KullaniciContext()
        {
        }

        public KullaniciContext(DbContextOptions<KullaniciContext> options)
            : base(options)
        {
        }

        public virtual DbSet<KullaniciTbl> KullaniciTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=localhost;Database=kullanici;User Id=sa;Password=Karaca.25;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KullaniciTbl>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__kullanic__3213E83F7DE57635");

                entity.ToTable("kullanici_tbl");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.KullaniciAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_adi");
                entity.Property(e => e.KullaniciSehir)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_sehir");
                entity.Property(e => e.KullaniciSoyad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_soyad");
                entity.Property(e => e.KullaniciTlf)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_tlf");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
