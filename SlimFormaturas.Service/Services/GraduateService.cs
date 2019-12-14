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
        protected readonly NotificationHandler _notifications;

        public GraduateService(
            IGraduateRepository graduateRepository,
            UserManager<IdentityUser> userManager,
             NotificationHandler notifications) : base(graduateRepository) {
            _graduateRepository = graduateRepository;
            _userManager = userManager;
            _notifications = notifications;
        }

        public async Task<string> CreateUser(string cpf, string email) {
            var user = new IdentityUser {
                UserName = cpf,
                Email = email,
                EmailConfirmed = true
            };
            
            var result = await _userManager.CreateAsync(user, cpf);

            if (!result.Succeeded) return null;

            return user.Id;
        }

        public async Task<Graduate> Insert(Graduate obj) {
            Graduate graduate = new Graduate(obj.GraduateId, obj.Name, obj.Cpf, obj.Rg, obj.Sex, obj.BirthDate, obj.DadName, obj.MotherName, obj.Committee, obj.Email, obj.Photo, obj.Bank, obj.Agency, obj.CheckingAccount);
            if(obj.Address != null) {
                graduate.AddAddress(obj.Address);
            }
            if(obj.Phone != null) {
                graduate.AddPhone(obj.Phone);
            }
            if (graduate.Valid) {
                //graduate.AddUser(await CreateUser(graduate.Cpf, graduate.Email));
                //if (graduate.UserId != null) {
                    await Post(graduate);
                //} else {
                //    throw new Exception("Erro ao criar usuário para o formando!");
                //}
            } else {
                _notifications.AddNotifications(graduate.ValidationResult);
            }
           
            return obj;
        }

        public async Task<Graduate> Update(Graduate obj) {
            Graduate graduate = new Graduate(obj.GraduateId, obj.Name, obj.Cpf, obj.Rg, obj.Sex, obj.BirthDate, obj.DadName, obj.MotherName, obj.Committee, obj.Email, obj.Photo, obj.Bank, obj.Agency, obj.CheckingAccount);
            if (graduate.Valid) {
                await Put(graduate);
            } else {
                _notifications.AddNotifications(graduate.ValidationResult);
            }

            return graduate;
        }

    }
}
