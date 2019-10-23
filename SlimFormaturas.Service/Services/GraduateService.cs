using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;

namespace SlimFormaturas.Service.Services {
    public class GraduateService : BaseService<Graduate>, IGraduateService {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IGraduateRepository _graduateRepository;

        public GraduateService(
            IGraduateRepository graduateRepository,
            UserManager<IdentityUser> userManager,
             NotificationHandler notifications) : base(graduateRepository, notifications) {
            _graduateRepository = graduateRepository;
            _userManager = userManager;
        }

        public async Task<string> CreateUser(string cpf, string email) {
            var user = new IdentityUser {
                UserName = cpf,
                Email = email,
                EmailConfirmed = true
            };
            
            await _userManager.CreateAsync(user, cpf);

            return user.Id;
        }

    }
}
