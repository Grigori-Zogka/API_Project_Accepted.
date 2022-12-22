using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

/// <summary>
/// Createsd with
/// Scaffold-DbContext “Server=MSI\SQLEXPRESS;Database=Accepted_Api;Integrated Security=True” Microsoft.EntityFrameworkCore.SqlServer
/// Create Table Match_(
//////    ID Int Identity(1,1) Primary Key,
//////    Descreption Varchar(100),
//////MatchDate Date,--'2021-08-13'
//////MatchTime Time,--'07:16:30'
//////TeamA Varchar(100),
//////TeamB Varchar(100),
//////Sport bit Not Null,
//////)
//////GO
//////Create Table MatchOdds(
//////ID Int Identity(1,1) Not null Primary Key,
//////MatchId Int Not null,
//////Specifier Varchar(10) Not null,
//////Odd decimal (8,2) Not null,
//////FOREIGN KEY(MatchId) REFERENCES MAtch_(ID)
//////)
//////GO
/// </summary>
namespace API_Project_Accepted.Models
{
    
    public partial class Accepted_ApiContext : DbContext
    {
        ////public Accepted_ApiContext()
        ////{
        ////}

        public Accepted_ApiContext(DbContextOptions<Accepted_ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<MatchOdds> MatchOdds { get; set; }

////        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
////        {
////            if (!optionsBuilder.IsConfigured)
////            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
////                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=Accepted_Api;Integrated Security=True");
////            }
////        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match_");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descreption)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MatchDate).HasColumnType("date");

                entity.Property(e => e.TeamA)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TeamB)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MatchOdds>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Odd).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Specifier)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchOdds)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MatchOdds__Match__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
