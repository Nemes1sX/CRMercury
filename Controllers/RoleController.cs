using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRMercury.Data.Models;
using CRMercury.Data.Context;
using CRMercury.Data.Dto;

namespace megaprojektas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly CRMContext _context;

        public RoleController(CRMContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var query = from role in _context.Roles
                        where role.Permissions.All(p => p.RolePermissions.Contains(p.RolePermissions.FirstOrDefault()))
                        select role;

            RoleDto roleDto = new RoleDto
            {
                RoleId = query.ToList().FirstOrDefault().RoleId,
                Title = query.ToList().FirstOrDefault().Title,
                Description = query.ToList().FirstOrDefault().Description,
            };

            return Ok(roleDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return NoContent();
        }
    }

}
