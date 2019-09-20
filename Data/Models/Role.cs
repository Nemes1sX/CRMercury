using System.Collections.Generic;
namespace CRMercury.Data.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}