using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lib.Core.Domain
{
    public partial class employeedbContext : DbContext
    {
        public employeedbContext()
        {
        }

        public employeedbContext(DbContextOptions<employeedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeDetail> EmployeeDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LOCALHOST;Database=employeedb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateOn)
                    .HasColumnName("createON")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastupdateOn)
                    .HasColumnName("lastupdateON")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
