using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LearnAPI.Models
{
    public partial class quanlycanbohumgContext : DbContext
    {
        public quanlycanbohumgContext()
        {
        }

        public quanlycanbohumgContext(DbContextOptions<quanlycanbohumgContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bomon> Bomons { get; set; }
        public virtual DbSet<Canbo> Canbos { get; set; }
        public virtual DbSet<Chucvu> Chucvus { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server='DESKTOP-GB8U56B';Database='quanlycanbohumg';Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<Bomon>(entity =>
            {
                entity.HasKey(e => e.IdBoMon);

                entity.ToTable("Bomon");

                entity.Property(e => e.NgaythanhlapBoMon).HasColumnType("datetime");

                entity.Property(e => e.TenBoMon).HasMaxLength(250);

                entity.HasOne(d => d.IdKhoaNavigation)
                    .WithMany(p => p.Bomons)
                    .HasForeignKey(d => d.IdKhoa)
                    .HasConstraintName("FK_Bomon_Khoa");
            });

            modelBuilder.Entity<Canbo>(entity =>
            {
                entity.HasKey(e => e.Idcb)
                    .HasName("PK__Canbo__9DB7B2683C3F8EDB");

                entity.ToTable("Canbo");

                entity.Property(e => e.Idcb).HasColumnName("idcb");

                entity.Property(e => e.Diachicb).HasMaxLength(400);

                entity.Property(e => e.Fullnamecb).HasMaxLength(255);

                entity.Property(e => e.Hocvancb).HasMaxLength(255);

                entity.Property(e => e.Ngaybatdaulamcb).HasColumnType("datetime");

                entity.Property(e => e.Sdtcb).HasMaxLength(255);

                entity.Property(e => e.Sinhnhatcb).HasColumnType("datetime");

                entity.HasOne(d => d.IdBoMonNavigation)
                    .WithMany(p => p.Canbos)
                    .HasForeignKey(d => d.IdBoMon)
                    .HasConstraintName("FK__Canbo__IdBoMon__36B12243");

                entity.HasOne(d => d.IdchucvuNavigation)
                    .WithMany(p => p.Canbos)
                    .HasForeignKey(d => d.Idchucvu)
                    .HasConstraintName("FK__Canbo__Idchucvu__37A5467C");
            });

            modelBuilder.Entity<Chucvu>(entity =>
            {
                entity.HasKey(e => e.Idchucvucanbo);

                entity.ToTable("Chucvu");

                entity.Property(e => e.Idchucvucanbo).ValueGeneratedNever();

                entity.Property(e => e.Tenchucvucanbo)
                    .HasMaxLength(250)
                    .HasColumnName("tenchucvucanbo");
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.IdKhoa);

                entity.ToTable("Khoa");

                entity.Property(e => e.IdKhoa).ValueGeneratedNever();

                entity.Property(e => e.NgaythanhlapKhoa).HasColumnType("datetime");

                entity.Property(e => e.TenKhoa).HasMaxLength(2500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
