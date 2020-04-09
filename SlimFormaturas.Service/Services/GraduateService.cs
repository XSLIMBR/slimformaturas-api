using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Domain.Validators;
using SlimFormaturas.Infra.Data.Repository;

namespace SlimFormaturas.Service.Services
{
    public class GraduateService : BaseService<Graduate>, IGraduateService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IGraduateRepository _graduateRepository;
        protected readonly NotificationHandler _notifications;
        protected readonly ITypeGenericRepository _typeGenericRepository;

        public GraduateService(
            IGraduateRepository graduateRepository,
            UserManager<IdentityUser> userManager,
            NotificationHandler notifications,
            ITypeGenericRepository typeGenericRepository) : base(graduateRepository) {
            _graduateRepository = graduateRepository;
            _userManager = userManager;
            _notifications = notifications;
            _typeGenericRepository = typeGenericRepository;
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
            Graduate graduate = new Graduate(obj.Name, obj.Cpf, obj.Rg, obj.Sex, obj.BirthDate, obj.DadName, obj.MotherName, obj.Email, obj.Photo, obj.Bank, obj.Agency, obj.CheckingAccount);

            if (obj.Address != null) {
                foreach (var address in obj.Address) {
                    var addressValid = new Address(address.Cep, address.Street, address.Number, address.Complement, address.Neighborhood, address.City, address.Uf, await _typeGenericRepository.GetById(address.TypeGenericId));
                    if (addressValid.Invalid) {
                        _notifications.AddNotifications(addressValid.ValidationResult);
                    } else {
                        graduate.Address.Add(addressValid);
                    }
                }
            }

            if (obj.Phone != null) {
                foreach (var phone in obj.Phone) {
                    var PhoneValid = new Phone(phone.Ddd, phone.PhoneNumber, await _typeGenericRepository.GetById(phone.TypeGenericId));
                    if (PhoneValid.Invalid) {
                        _notifications.AddNotifications(PhoneValid.ValidationResult);
                    } else {
                        graduate.Phone.Add(PhoneValid);
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

            Graduate graduate = await _graduateRepository.GetById(obj.GraduateId);

            if (graduate != null) {

                graduate.Name = obj.Name;
                graduate.Cpf = obj.Cpf;
                graduate.Rg = obj.Rg;
                graduate.Sex = obj.Sex;
                graduate.BirthDate = obj.BirthDate;
                graduate.DadName = obj.DadName;
                graduate.MotherName = obj.MotherName;
                graduate.Email = obj.Email;
                graduate.Photo = obj.Photo;
                graduate.Bank = obj.Bank;
                graduate.Agency = obj.Agency;
                graduate.CheckingAccount = obj.CheckingAccount;

                graduate.Validate(graduate, new GraduateValidator());

                if (graduate.Valid) {
                    await Put(graduate);
                } else {
                    _notifications.AddNotifications(graduate.ValidationResult);
                }
            } else {
                _notifications.AddNotification("404", "GraduateId", "Graduate with id = " + obj.GraduateId + " not found");
            }

            return graduate;
        }
    }
}
