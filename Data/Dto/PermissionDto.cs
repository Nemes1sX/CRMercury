namespace CRMercury.Data.Dto
{
    public class PermissionDto
    {
        public int PermissionId { get; set; }
        public bool SelfActionOnly { get; set; }
        public bool ActionCreate { get; set; }
        public bool ActionRead { get; set; }
        public bool ActionUpdate { get; set; }
        public bool ActionDelete { get; set; }
		
		
        public int ActionRoleId { get; set; }
        public string ActionRoleName { get; set; }
    }
}