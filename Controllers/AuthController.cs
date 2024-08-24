using crud_dotnet_api.Data;
using crud_dotnet_api.Model;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace crud_dotnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly JwtOption _options;

        public AuthController(UserRepository userRepository, IOptions<JwtOption> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }

        [HttpPost("register")]
         public async Task<ActionResult> Register([FromBody] User model)
            {
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user != null)
            {
                return BadRequest(new { error = "Email has already existed!" });
            }
            await _userRepository.RegisterAsync(model);
                return Ok(new { message = "Register successfully!"});
            }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user is null)
            {
                return BadRequest(new { error = "Email does not exist" });
            }
            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return BadRequest(new { error = "email/password is incorrect." });
            }
            var token = GetJWTToken(user.Username,model.Email);
            return Ok(new { token = token });
        }

        private string GetJWTToken(string username, string email)
        {
            var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var crendential = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Username", username),
                new Claim("Email",email)
            };
            var sToken = new JwtSecurityToken(_options.Key, _options.Issuer, claims, expires: DateTime.Now.AddHours(5), signingCredentials: crendential);
            var token = new JwtSecurityTokenHandler().WriteToken(sToken);
            return token;
        }

    }
}
