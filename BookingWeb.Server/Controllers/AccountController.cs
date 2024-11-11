using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingWeb.Server.Models;
using BookingWeb.Server.Services;

namespace BookingWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/Account
        [HttpGet]
        public IActionResult GetAccounts()
        {
            return Ok();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            return Ok();
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public IActionResult PutAccount(int id)
        {
            return Ok();
        }

        // POST: api/Account
        [HttpPost]
        public IActionResult PostAccount()
        {
            return Ok();
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            return Ok();
        }


    }
}
