using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CRMercury.Data.Models;


namespace CRMercury.Data.Context
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions<CRMContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Permission>().ToTable("Permission");
            modelBuilder.Entity<RolePermission>().ToTable("RolePermission");
            SetRolePermissionRelationship(modelBuilder);
        }
        private void SetRolePermissionRelationship(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolePermission>()
                .HasKey(r => new { r.RoleId, r.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(r => r.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(r => r.Permission)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(r => r.PermissionId);
        }
    }
}
