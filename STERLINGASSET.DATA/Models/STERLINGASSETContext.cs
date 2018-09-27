using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace STERLINGASSET.DATA.Models
{
    public partial class STERLINGASSETContext : DbContext
    {
        public STERLINGASSETContext()
        {
        }
        public STERLINGASSETContext(DbContextOptions<STERLINGASSETContext> options)
             : base(options)
        {
        }
        public virtual DbSet<TblAssetCustomer> TblAssetCustomer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.\FINTRAKSQL;Database=STERLINGASSET;Trusted_Connection=True; User ID=sa;Password=sqluser10$;MultipleActiveResultSets=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAssetCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("tbl_AssetCustomer");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.CustomerAddress)
                    .HasColumnName("Customer_Address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerDob)
                    .HasColumnName("Customer_DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerFirstName)
                    .HasColumnName("Customer_FirstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerLastName)
                    .HasColumnName("Customer_LastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPhoneNo)
                    .HasColumnName("Customer_PhoneNo")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerSex)
                    .HasColumnName("Customer_Sex")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerStatus)
                    .HasColumnName("Customer_Status")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
