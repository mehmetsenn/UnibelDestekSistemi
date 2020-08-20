using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UnibelDestekSistemi.Models.DBHandler
{
    public partial class unibeldestekContext : DbContext
    {
        public unibeldestekContext()
        {
        }

        public unibeldestekContext(DbContextOptions<unibeldestekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bilet> Bilet { get; set; }
        public virtual DbSet<Departman> Departman { get; set; }
        public virtual DbSet<Durum> Durum { get; set; }
        public virtual DbSet<Duyuru> Duyuru { get; set; }
        public virtual DbSet<Haklar> Haklar { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Oncelik> Oncelik { get; set; }
        public virtual DbSet<Roller> Roller { get; set; }
        public virtual DbSet<Sirketler> Sirketler { get; set; }
        public virtual DbSet<Tip> Tip { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<Yanit> Yanit { get; set; }
        public virtual DbSet<Yetkiler> Yetkiler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LTCUDR3;Database=unibeldestek;User=q;Password=12345;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bilet>(entity =>
            {
                entity.Property(e => e.BiletId).HasColumnName("BiletID");

                entity.Property(e => e.BiletBasligi)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.BiletGonderimTarihi).HasColumnType("datetime");

                entity.Property(e => e.BiletIcerik).HasMaxLength(500);

                entity.Property(e => e.BiletKapanisTarihi).HasColumnType("datetime");

                entity.Property(e => e.BiletTahminiKapanısTarihi).HasColumnType("datetime");

                entity.Property(e => e.FkBiletDepartmanId).HasColumnName("FK_BiletDepartmanID");

                entity.Property(e => e.FkBiletDurumId).HasColumnName("FK_BiletDurumID");

                entity.Property(e => e.FkBiletGonderenId).HasColumnName("FK_BiletGonderenID");

                entity.Property(e => e.FkBiletTurId).HasColumnName("FK_BiletTurID");

                entity.Property(e => e.FkCalisanKullaniciId).HasColumnName("FK_CalisanKullaniciID");

                entity.Property(e => e.FkOncelikId).HasColumnName("FK_OncelikID");

                entity.Property(e => e.FkSirketId).HasColumnName("FK_SirketId");

                entity.Property(e => e.FkUrunId).HasColumnName("FK_UrunID");

                entity.HasOne(d => d.FkBiletDepartman)
                    .WithMany(p => p.Bilet)
                    .HasForeignKey(d => d.FkBiletDepartmanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Department");

                entity.HasOne(d => d.FkBiletDurum)
                    .WithMany(p => p.Bilet)
                    .HasForeignKey(d => d.FkBiletDurumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Status");

                entity.HasOne(d => d.FkBiletGonderen)
                    .WithMany(p => p.BiletFkBiletGonderen)
                    .HasForeignKey(d => d.FkBiletGonderenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_User3");

                entity.HasOne(d => d.FkBiletTur)
                    .WithMany(p => p.Bilet)
                    .HasForeignKey(d => d.FkBiletTurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Type");

                entity.HasOne(d => d.FkCalisanKullanici)
                    .WithMany(p => p.BiletFkCalisanKullanici)
                    .HasForeignKey(d => d.FkCalisanKullaniciId)
                    .HasConstraintName("FK_Ticket_User2");

                entity.HasOne(d => d.FkOncelik)
                    .WithMany(p => p.Bilet)
                    .HasForeignKey(d => d.FkOncelikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bilet_Oncelik");

                entity.HasOne(d => d.FkSirket)
                    .WithMany(p => p.Bilet)
                    .HasForeignKey(d => d.FkSirketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bilet_Sirketler");

                entity.HasOne(d => d.FkUrun)
                    .WithMany(p => p.Bilet)
                    .HasForeignKey(d => d.FkUrunId)
                    .HasConstraintName("FK_Bilet_Urun");
            });

            modelBuilder.Entity<Departman>(entity =>
            {
                entity.Property(e => e.DepartmanId).HasColumnName("DepartmanID");

                entity.Property(e => e.DepartmanAdi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DepartmanTel).HasMaxLength(50);
            });

            modelBuilder.Entity<Durum>(entity =>
            {
                entity.Property(e => e.DurumId).HasColumnName("DurumID");

                entity.Property(e => e.DurumAdi)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Duyuru>(entity =>
            {
                entity.Property(e => e.DuyuruId)
                    .HasColumnName("DuyuruID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DuyuruBasligi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DuyuruIcerigi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KullaniciId).HasColumnName("KullaniciID");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.Duyuru)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_User");
            });

            modelBuilder.Entity<Haklar>(entity =>
            {
                entity.HasKey(e => e.HakId);

                entity.Property(e => e.HakId).HasColumnName("HakID");

                entity.Property(e => e.RolId).HasColumnName("RolID");

                entity.Property(e => e.YetkiId).HasColumnName("YetkiID");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Haklar)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Haklar_Roller");

                entity.HasOne(d => d.Yetki)
                    .WithMany(p => p.Haklar)
                    .HasForeignKey(d => d.YetkiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Haklar_Yetkiler");
            });

            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.HasIndex(e => e.KullaniciAdi)
                    .HasName("KullaniciAdi")
                    .IsUnique();

                entity.Property(e => e.KullaniciId).HasColumnName("KullaniciID");

                entity.Property(e => e.Eposta).HasMaxLength(50);

                entity.Property(e => e.EpostaSilmeZamani)
                    .HasColumnName("Eposta_Silme_Zamani")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkDepartmanId).HasColumnName("FK_DepartmanID");

                entity.Property(e => e.FkRolId).HasColumnName("FK_RolID");

                entity.Property(e => e.FkSirketId).HasColumnName("FK_SirketID");

                entity.Property(e => e.KullaniciAdi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KullaniciTel).HasMaxLength(20);

                entity.Property(e => e.Link).HasMaxLength(100);

                entity.Property(e => e.ProfilFotografi).HasColumnType("image");

                entity.Property(e => e.Sifre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TamIsim).HasMaxLength(50);

                entity.Property(e => e.Unvan).HasMaxLength(50);

                entity.HasOne(d => d.FkDepartman)
                    .WithMany(p => p.Kullanici)
                    .HasForeignKey(d => d.FkDepartmanId)
                    .HasConstraintName("FK_Kullanici_Departman");

                entity.HasOne(d => d.FkRol)
                    .WithMany(p => p.Kullanici)
                    .HasForeignKey(d => d.FkRolId)
                    .HasConstraintName("FK_Kullanici_Roller");

                entity.HasOne(d => d.FkSirket)
                    .WithMany(p => p.Kullanici)
                    .HasForeignKey(d => d.FkSirketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kullanici_Sirketler");
            });

            modelBuilder.Entity<Oncelik>(entity =>
            {
                entity.Property(e => e.OncelikId).HasColumnName("OncelikID");

                entity.Property(e => e.OncelikAdi).HasMaxLength(50);
            });

            modelBuilder.Entity<Roller>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.Property(e => e.RolId).HasColumnName("RolID");

                entity.Property(e => e.RolAdi).HasMaxLength(50);
            });

            modelBuilder.Entity<Sirketler>(entity =>
            {
                entity.HasKey(e => e.SirketId);

                entity.Property(e => e.SirketId).HasColumnName("SirketID");

                entity.Property(e => e.SirketAdi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SirketTel).HasMaxLength(50);
            });

            modelBuilder.Entity<Tip>(entity =>
            {
                entity.Property(e => e.TipId).HasColumnName("TipID");

                entity.Property(e => e.TipAdi)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Urun>(entity =>
            {
                entity.Property(e => e.UrunId)
                    .HasColumnName("UrunID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArizaTanimi).HasMaxLength(50);

                entity.Property(e => e.Demirbas).HasMaxLength(50);

                entity.Property(e => e.SeriNo).HasMaxLength(50);

                entity.Property(e => e.UrunAdi).HasMaxLength(50);
            });

            modelBuilder.Entity<Yanit>(entity =>
            {
                entity.HasKey(e => e.YanıtId);

                entity.Property(e => e.YanıtId).HasColumnName("YanıtID");

                entity.Property(e => e.FkBiletId).HasColumnName("FK_BiletID");

                entity.Property(e => e.FkKullaniciId).HasColumnName("FK_KullaniciID");

                entity.Property(e => e.YanitGonderimTarihi).HasColumnType("datetime");

                entity.Property(e => e.YanıtIcerigi)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.FkBilet)
                    .WithMany(p => p.Yanit)
                    .HasForeignKey(d => d.FkBiletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reply_Ticket");

                entity.HasOne(d => d.FkKullanici)
                    .WithMany(p => p.Yanit)
                    .HasForeignKey(d => d.FkKullaniciId)
                    .HasConstraintName("FK_Yanit_Kullanici");
            });

            modelBuilder.Entity<Yetkiler>(entity =>
            {
                entity.HasKey(e => e.YetkiId);

                entity.Property(e => e.YetkiId).HasColumnName("YetkiID");

                entity.Property(e => e.YetkiAdi)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
