using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CRMercury.Data.Models;

namespace CRMercury.Data.Context
{
    public class CRMContextSeed
    {
        public static void Initialize(CRMContext context)
        {
            context.Database.EnsureCreated();

            if (DbEmpty(context))
            {
                SeedDb(context);
            }
        }
        private static bool DbEmpty(CRMContext context)
        {
            return !context.Roles.Any()
                && !context.Permissions.Any()
                && !context.RolePermissions.Any();
        }
        private static void SeedDb(CRMContext context)
        {
            AddRoles(context);
            AddPermissions(context);
            AddRolePermissions(context);
        }
        private static void AddRoles(CRMContext context)
        {
            var roles = new Role[]{
                new Role{ Title = "Programmer net core", Description = "Programming web applications with dotnet core c#"},
                new Role{ Title = "Manager", Description = "Planning, directing and overseeing the operations."},
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
        private static void AddPermissions(CRMContext context)
        {
            var permissions = new Permission[]{
                new Permission{ SelfActionOnly = true, ActionCreate = false
                    , ActionRead = true , ActionDelete = false, ActionUpdate = false
                    , ActionRole = context.Roles.FirstOrDefault(s => s.RoleId == 1) },
                new Permission{ SelfActionOnly = false, ActionCreate = true
                    , ActionRead = true , ActionDelete = true, ActionUpdate = true
                    , ActionRole = context.Roles.FirstOrDefault(s => s.RoleId == 2) },
                new Permission{ SelfActionOnly = false, ActionCreate = true
                    , ActionRead = true , ActionDelete = true, ActionUpdate = true
                    , ActionRole = context.Roles.FirstOrDefault(s => s.RoleId == 1) },
            };

            context.Permissions.AddRange(permissions);
            context.SaveChanges();
        }
        private static void AddRolePermissions(CRMContext context)
        {
            var rolePermissions = new RolePermission[]{
                new RolePermission{ RoleId = 1, PermissionId = 1 },
                new RolePermission{ RoleId = 2, PermissionId = 2 },
                new RolePermission{ RoleId = 2, PermissionId = 3 },
            };

            context.RolePermissions.AddRange(rolePermissions);
            context.SaveChanges();
        }
    }
}
