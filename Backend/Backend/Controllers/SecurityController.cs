using Backend.Models;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public SecurityController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel createUserModel)
        {
            try
            {
                var result = await _userManager.CreateAsync(new Models.User
                {
                    Email = createUserModel.Email,
                    UserName = createUserModel.UserName,

                    Name = createUserModel.Name,
                    PLastName = createUserModel.PLastName,
                    MLastName = createUserModel.MLastName,
                    BirthDate = createUserModel.BirthDate,
                    Street = createUserModel.Street,
                    NoExt = createUserModel.NoExt,
                    NoInt = createUserModel.NoInt,
                    PostalCode = createUserModel.PostalCode,
                    CiudadId = createUserModel.CiudadId
                    
                    

                }, createUserModel.Password);

                if (!result.Succeeded)
                    return StatusCode(500, "Error al crear usuario");

                return Ok("Usuario creado correctamente");
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginView)
        {
            try
            {
                //1. Revisar que username exista.
                User user = await _userManager.FindByNameAsync(loginView.Username);
                if (user != null)
                {
                    //2. Verificar que contraseña esté correcta.
                    var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, loginView.Password, false);
                    if (passwordCheck.Succeeded)
                    {
                        //3. Generar  token
                        var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey"));

                        var claims = new[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                            new Claim(ClaimTypes.Name, user.UserName)
                        };

                        var identityClaim = new ClaimsIdentity(claims);

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = identityClaim,
                            Expires = DateTime.UtcNow.AddDays(1),
                            SigningCredentials = new SigningCredentials(
                                new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256Signature
                                )
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();

                        var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                        return Ok(tokenHandler.WriteToken(createdToken));

                    }
                    else
                        return StatusCode(404, "Credenciales inválidas");
                }

                return StatusCode(404, "Usuario no existe");
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
