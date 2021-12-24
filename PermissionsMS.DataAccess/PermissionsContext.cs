using Microsoft.EntityFrameworkCore;
using PermissionsMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionsMS.DataAccess
{
    public class PermissionsContext : DbContext
    {
        public PermissionsContext(){}
        public PermissionsContext(DbContextOptions<PermissionsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionType>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Description)
                      .IsRequired()
                      .HasMaxLength(255);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.EmployeeForename)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.EmployeeSurname)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.PermissionDate)
                      .IsRequired()
                      .HasColumnType("date");

                entity.Property(e => e.PermissionTypeId)
                      .HasColumnName("PermissionType");

                entity.HasOne(p => p.PermissionType)
                      .WithMany(Permissions => Permissions.Permissions)
                      .HasForeignKey(p => p.PermissionTypeId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }

        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionType> PermissionTypes { get; set; }
    }
}
