using System.Collections.Generic;
namespace CRMercury.Data.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public bool SelfActionOnly { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
        public bool ActionCreate { get; set; }
        public bool ActionRead { get; set; }
        public bool ActionUpdate { get; set; }
        public bool ActionDelete { get; set; }
    }
}