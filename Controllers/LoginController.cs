using AutoMapper;
using DistribuidoraALM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DistribuidoraALM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DistribuidoraAlmContext _ctx;

        private readonly IMapper _mapper;

        private readonly string _secretKey;

        public LoginController(DistribuidoraAlmContext ctx, IMapper maper, IConfiguration config)
        {
            _ctx = ctx;
            _mapper = maper;

            _secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
        }
        // POST api/<LoginController>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UsuarioViewModel usuario)
        {
            try
            {
                var usuarioLogin = await _ctx.Usuarios.Where(p => p.Usuario1 == usuario.Usuario && p.Password == usuario.Password).FirstOrDefaultAsync();
                if (usuarioLogin != null)
                {
                    var keyBytes = Encoding.ASCII.GetBytes(_secretKey);
                    var claims = new ClaimsIdentity();

                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Usuario));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                    var token = tokenHandler.WriteToken(tokenConfig);

                    return Ok(new { token = token });

                }
                else
                    return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
