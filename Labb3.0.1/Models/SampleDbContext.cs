using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3._0._1.Models
{
    public partial class SampleDbContext : DbContext
    {
        public SampleDbContext()
        {
        }

        public SampleDbContext(DbContextOptions<SampleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Betyg> TblBetyg { get; set; }
        public virtual DbSet<Elev> TblElev { get; set; }
        public virtual DbSet<Kurs> TblKurs { get; set; }
        public virtual DbSet<KursLista> TblKursLista { get; set; }
        public virtual DbSet<Personal> TblPersonal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-GVBM1500; Initial Catalog = GymnasieSkola; Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Betyg>(entity =>
            {
                entity.Property(e => e.BetygId).HasColumnName("BetygID");

                entity.Property(e => e.Betyg1).HasColumnName("Betyg");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.FkElevId).HasColumnName("FK_ElevID");

                entity.Property(e => e.FkKursId).HasColumnName("FK_KursID");

                entity.Property(e => e.FkPersonalId).HasColumnName("FK_PersonalID");

                entity.HasOne(d => d.FkElev)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.FkElevId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBetyg_tblElev");

                entity.HasOne(d => d.FkKurs)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.FkKursId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBetyg_tblKurs");

                entity.HasOne(d => d.FkPersonal)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.FkPersonalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBetyg_tblPersonal");
            });

            modelBuilder.Entity<Elev>(entity =>
            {
                entity.Property(e => e.ElevId).HasColumnName("ElevID");

                entity.Property(e => e.Efternamn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FkGenderId).HasColumnName("FK_GenderID");

                entity.Property(e => e.Förnamn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Klass)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Personnummer)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Kurs>(entity =>
            {
                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.KursNamn)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<KursLista>(entity =>
            {
                entity.Property(e => e.KursListaId).HasColumnName("KursListaID");

                entity.Property(e => e.FkElevId).HasColumnName("FK_ElevID");

                entity.Property(e => e.FkKursId).HasColumnName("FK_KursID");

                entity.HasOne(d => d.FkElev)
                    .WithMany(p => p.KursLista)
                    .HasForeignKey(d => d.FkElevId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblKursLista_tblElev");

                entity.HasOne(d => d.FkKurs)
                    .WithMany(p => p.KursLista)
                    .HasForeignKey(d => d.FkKursId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblKursLista_tblKurs");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.Property(e => e.Befattning)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Namn)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
