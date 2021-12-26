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

            modelBuilder.Entity<PermissionType>().HasData(
                new PermissionType
                {
                    Id = 1,
                    Description = "Administrator"
                },

                new PermissionType
                {
                    Id = 2,
                    Description = "Project Manager"
                },

                new PermissionType
                {
                    Id = 3,
                    Description = "Scrum Master"
                },

                new PermissionType
                {
                    Id = 4,
                    Description = "Product Owner"
                },

                new PermissionType
                {
                    Id = 5,
                    Description = "Developer"
                }
            );

            modelBuilder.Entity<Permission>().HasData(
                
                new Permission
                {
                    Id = 1,
                    EmployeeForename = "Matías",
                    EmployeeSurname = "Salinas",
                    PermissionTypeId = 5,
                    PermissionDate = DateTime.Now.Date
                },

                new Permission
                {
                    Id = 2,
                    EmployeeForename = "Jose Luís",
                    EmployeeSurname = "Fernández",
                    PermissionTypeId = 5,
                    PermissionDate = DateTime.Now.Date
                },

                new Permission
                {
                    Id = 3,
                    EmployeeForename = "Rodrigo",
                    EmployeeSurname = "Lago",
                    PermissionTypeId = 3,
                    PermissionDate = DateTime.Now.Date
                },

                new Permission
                {
                    Id = 4,
                    EmployeeForename = "Lucas",
                    EmployeeSurname = "Olivera",
                    PermissionTypeId = 3,
                    PermissionDate = DateTime.Now.Date
                },

                new Permission
                {
                    Id = 5,
                    EmployeeForename = "Camilo",
                    EmployeeSurname = "Ñañez",
                    PermissionTypeId = 1,
                    PermissionDate = DateTime.Now.Date
                },

                new Permission
                {
                    Id = 6,
                    EmployeeForename = "Waldo",
                    EmployeeSurname = "Hasperué",
                    PermissionTypeId = 1,
                    PermissionDate = DateTime.Now.Date
                }
            );
        }

        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionType> PermissionTypes { get; set; }
    }
}
