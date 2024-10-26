using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JWTtest.Models;
using JWTtest.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWTtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authServices.RegisteraAsync(model);
            if(!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(new {token = result.Token , expireson = result.ExpiresOn ,
                user_Email = result.Email , user_name = result.UserName});
        }

        [HttpPost("Token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authServices.GetTokenAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(new
            {
                token = result.Token,
                expireson = result.ExpiresOn,
                user_Email = result.Email,
                user_name = result.UserName
            });
        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authServices.AddRoleAsync(model);
            if (!string.IsNullOrEmpty(result))
            {
                return BadRequest(result);
            }
            return Ok(model);
        }

        [HttpPost("SendUserData")]
        public async Task<IActionResult> SendUserData()
        {
            var user = await _authServices.GetUserData("ah.mohsen");
            var jsonData = JsonSerializer.Serialize(user);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await httpClient.PostAsync("https://localhost:7233/WeatherForecast/GetUserData", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (Exception ex) {
                throw ex;
            }
            return Ok();
        }
    }
}
