using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Controllers
{
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/Role
        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok();
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public IActionResult GetRole(int id)
        {
            return Ok();
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public IActionResult PutRole(int id)
        {
            return Ok();
        }

        // POST: api/Role
        [HttpPost]
        public IActionResult PostRole()
        {
            return Ok();
        }

        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            return Ok();
        }



    }
}
