using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP_Praktikum.Models
{
    public partial class TugasAkhirContext : DbContext
    {
        public TugasAkhirContext()
        {
        }

        public TugasAkhirContext(DbContextOptions<TugasAkhirContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Borrow> Borrows { get; set; }
        public virtual DbSet<Buku> Bukus { get; set; }
        public virtual DbSet<Person> People { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-GTRP6JSV;Initial Catalog=TugasAkhir;Integrated Security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("admin");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("idAdmin");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Borrow>(entity =>
            {
                entity.HasKey(e => e.IdBorrow);

                entity.ToTable("borrow");

                entity.Property(e => e.IdBorrow).HasColumnName("idBorrow");

                entity.Property(e => e.BorrowDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("borrowDate");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnName("dueDate");

                entity.Property(e => e.IdBuku).HasColumnName("idBuku");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.ReturnDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("returnDate");

                entity.HasOne(d => d.IdBukuNavigation)
                    .WithMany(p => p.Borrows)
                    .HasForeignKey(d => d.IdBuku)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_borrow_buku");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Borrows)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_borrow_borrow");
            });

            modelBuilder.Entity<Buku>(entity =>
            {
                entity.HasKey(e => e.IdBuku);

                entity.ToTable("buku");

                entity.Property(e => e.IdBuku).HasColumnName("idBuku");

                entity.Property(e => e.Halaman).HasColumnName("halaman");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("isbn");

                entity.Property(e => e.JudulBuku)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("judulBuku");

                entity.Property(e => e.Kategori)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kategori");

                entity.Property(e => e.Penerbit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("penerbit");

                entity.Property(e => e.Penulis)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("penulis");

                entity.Property(e => e.ThTerbit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("thTerbit");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPerson);

                entity.ToTable("person");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("alamat");

                entity.Property(e => e.Gender)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.NmPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nmPerson");

                entity.Property(e => e.NoTelp)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("noTelp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
