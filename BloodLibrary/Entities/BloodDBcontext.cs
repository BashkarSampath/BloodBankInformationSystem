using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLibrary.Entities
{
    public partial class BloodDBcontext : DbContext
    {
        public BloodDBcontext()
        {
        }

        public BloodDBcontext(DbContextOptions<BloodDBcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<BloodBank> Bank { get; set; }
        public virtual DbSet<BloodStock> Stock { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Data Source=relationaldbforawsfinalproject.database.windows.net;Initial Catalog=BloodBankDb;User ID=live;Password=Selvi$123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<BloodBank>(entity =>
            {
                entity.Property(e => e.address).HasMaxLength(50);

                entity.Property(e => e.bloodBankName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BloodStock>(entity =>
            {
                entity.HasIndex(e => e.bloodBankId);

                entity.Property(e => e.status).HasMaxLength(10);

                entity.Property(e => e.bloodType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.quantity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.bloodType)
                    .IsRequired()
                    .HasMaxLength(50);

                //entity.HasOne(d => d.bank)
                //    .WithMany(p => p.)
                //    .HasForeignKey(d => d.bloodBankId);
            });
        }

    }//end public partial class BloodDBcontext : DbContext
}
