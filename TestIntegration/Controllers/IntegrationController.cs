using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestIntegration.Models;

namespace TestIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public IntegrationController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize]
        [HttpGet("TestAuth")]
        public IActionResult TestAuth()
        {
            var token = Request.Headers.Authorization.FirstOrDefault();
            var userClaims = User.Claims.ToList();
            return Ok("User authenticated");
        }
    }
}
