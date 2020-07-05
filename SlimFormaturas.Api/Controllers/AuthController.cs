using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Infra.CrossCutting.Identity.Models;

namespace SlimFormaturas.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController {

         readonly SignInManager<ApplicationUser> _signInManager;
         readonly UserManager<ApplicationUser> _userManager;
         readonly AppSettings _appSettings;
        protected readonly NotificationHandler _notifications;

        public AuthController(SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager,
            NotificationHandler notifications,
            IOptions<AppSettings> appSettings) : base(notifications){
            _signInManager = signInManager;
            _userManager = userManager;
            _notifications = notifications;
            _appSettings = appSettings.Value;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(Login loginUser){
            //if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var result = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, false, true);

            var token = await GetJWT(loginUser.UserName);

            if (result.Succeeded) {
                var data = new {
                    userData = new {
                        displayName = "Julio Rodrigues",
                        photoURL = @"/assets/images/portrait/small/avatar-s-11.jpg"
                    },
                    accessToken = token
                };

                return Response(data);
            }

            _notifications.AddNotification("UserName/PassWord","User", "Usuário ou senha inválidos");
            return Response();
        }

        async Task<string> GetJWT(string username) {

            var user = await _userManager.FindByNameAsync(username);

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(await _userManager.GetClaimsAsync(user));

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {

                Subject = identityClaims,
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

    }
}