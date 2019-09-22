using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRMercury.Data.Dto;

namespace CRMercury.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
			var permissions = new PermissionDto[]{
				new PermissionDto{
					PermissionId = 1,
					SelfActionOnly = true,
					ActionCreate = false,
					ActionRead = true,
					ActionUpdate = false,
					ActionDelete = false,
					ActionRoleId = 1,
					ActionRoleName = "Programmer",
				},
				new PermissionDto{
					PermissionId = 2,
					SelfActionOnly = false,
					ActionCreate = false,
					ActionRead = true,
					ActionUpdate = true,
					ActionDelete = false,
					ActionRoleId = 1,
					ActionRoleName = "Programmer",
				},
				new PermissionDto{
					PermissionId = 3,
					SelfActionOnly = true,
					ActionCreate = false,
					ActionRead = true,
					ActionUpdate = false,
					ActionDelete = false,
					ActionRoleId = 2,
					ActionRoleName = "Manager",
				},
				new PermissionDto{
					PermissionId = 4,
					SelfActionOnly = true,
					ActionCreate = false,
					ActionRead = true,
					ActionUpdate = false,
					ActionDelete = false,
					ActionRoleId = 3,
					ActionRoleName = "Designer",
				},
				new PermissionDto{
					PermissionId = 5,
					SelfActionOnly = false,
					ActionCreate = true,
					ActionRead = true,
					ActionUpdate = true,
					ActionDelete = true,
					ActionRoleId = 3,
					ActionRoleName = "Designer",
				},
			};
			
			var roles = new RoleDto[]{
                new RoleDto{RoleId = 1, Title="Programmer", Description="Programming web api with .Net core", PermissionsDto= new List<PermissionDto>(){permissions[0]} },
                new RoleDto{RoleId = 2, Title="Manager", Description="Planning, directing and overseeing the operations.", PermissionsDto= new List<PermissionDto>(){permissions[1],permissions[2],permissions[4]} },
                new RoleDto{RoleId = 3, Title="Designer", Description="Graphic and web designer plus css", PermissionsDto= new List <PermissionDto>(){permissions[3]} },
				};

            return Ok(roles);
        }
    }
}