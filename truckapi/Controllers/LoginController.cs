using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using truckapi.Models;

namespace truckapi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoginController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login(String userId, String password)
        {
            User user = _context.User.Where(u => u.UserId == userId).Where(u => u.Password == password).SingleOrDefault();

            if (user != null)
            {
                return Ok(user);
            }

            return NoContent();
        }

    }
}
