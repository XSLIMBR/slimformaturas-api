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

            if (!result.Succeeded) {
                _notifications.AddIdentityErrors(result);
                return null;
            }

            return user.Id;
        }

        public async Task<Graduate> Insert(Graduate obj) {

            Graduate graduate = new Graduate(obj.GraduateId, obj.Name, obj.Cpf, obj.Rg, obj.Sex, obj.BirthDate, obj.DadName, obj.MotherName, obj.Committee, obj.Email, obj.Photo, obj.Bank, obj.Agency, obj.CheckingAccount);
            
            if(obj.Address != null) {
                graduate.AddAddress(obj.Address);
                foreach (var address in graduate.Address) {
                    if (address.Invalid) {
                        _notifications.AddNotifications(address.ValidationResult);
                    }
                }
            }

            if(obj.Phone != null) {
                graduate.AddPhone(obj.Phone);
                foreach (var phone in graduate.Phone) {
                    if (phone.Invalid) {
                        _notifications.AddNotifications(phone.ValidationResult);
                    }
                }
            }

            if (graduate.Invalid) {
                _notifications.AddNotifications(graduate.ValidationResult);
            }


            if (!_notifications.HasNotifications) {
                //graduate.AddUser(await CreateUser(graduate.Cpf, graduate.Email));
            }

            if (!_notifications.HasNotifications) {
                await Post(graduate);
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
