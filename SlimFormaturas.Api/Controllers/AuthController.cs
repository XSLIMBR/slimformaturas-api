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
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
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
        readonly IGraduateService _graduateService;
        readonly IEmployeeService _employeeService;
        readonly ISellerService _sellerService;

        public AuthController(SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager,
            IGraduateService graduateService,
            IEmployeeService employeeService,
            NotificationHandler notifications,
            ISellerService sellerService,
            IOptions<AppSettings> appSettings) : base(notifications){
            _signInManager = signInManager;
            _userManager = userManager;
            _graduateService = graduateService;
            _sellerService = sellerService;
            _employeeService = employeeService;

            _notifications = notifications;
            _appSettings = appSettings.Value;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(Login loginUser){
            var result = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, false, true);

            if (result.Succeeded) {
                var user = await _userManager.FindByNameAsync(loginUser.UserName);
                var token = await GetJwt(user).ConfigureAwait(false);

                string photo = "";
                string name = "";

                switch (user.User_Type) {
                    case user_type.Colaborador:

                        //var employee = (await _employeeService.GetWhere(a => a.UserId == user.Id)).FirstOrDefault();
                        //if (employee != null) {
                        //    photo = employee.Photo;
                        //    name = employee.GetShortName();
                        //}

                        break;
                    case user_type.Formando:
                        var graduate = (await _graduateService.GetWhere(a => a.UserId == user.Id)).FirstOrDefault();
                        if (graduate != null) {
                            photo = graduate.Photo;
                            name = graduate.GetShortName();
                        }
                        break;
                    case user_type.Vendedor:
                        //var seller = (await _sellerService.GetWhere(a => a.UserId == user.Id)).FirstOrDefault();
                        //if (seller != null) {
                        //    photo = seller.Photo;
                        //   name = seller.GetShortName();
                        //}
                        break;
                }

                var data = new {
                    userData = new {
                        uid = user.Id,
                        displayName = name,
                        photoURL = photo,
                        userType = user.User_Type
                    },
                    accessToken = token
                };

                return Response(data);
            }

            _notifications.AddNotification("UserName/PassWord","User", "Usuário ou senha inválidos");
            return Response();
        }

        async Task<string> GetJwt(ApplicationUser user) {

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