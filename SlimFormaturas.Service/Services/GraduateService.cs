using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SlimFormaturas.Domain.Dto.Graduate;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Domain.Validators;
using SlimFormaturas.Infra.Data.Repository;
using AutoMapper;
using SlimFormaturas.Infra.CrossCutting.Identity.Models;
using System.Collections.Generic;

namespace SlimFormaturas.Service.Services
{
    public class GraduateService : BaseService<Graduate>, IGraduateService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGraduateRepository _graduateRepository;
        protected readonly NotificationHandler _notifications;
        protected readonly ITypeGenericRepository _typeGenericRepository;
        readonly IMapper _mapper;

        public GraduateService(
            IGraduateRepository graduateRepository,
            UserManager<ApplicationUser> userManager,
            NotificationHandler notifications,
             IMapper mapper,
            ITypeGenericRepository typeGenericRepository) : base(graduateRepository) {
            _graduateRepository = graduateRepository;
            _userManager = userManager;
            _notifications = notifications;
            _typeGenericRepository = typeGenericRepository;
            _mapper = mapper;
        }

        public async Task<string> CreateUser(string cpf, string email) {
            var user = new ApplicationUser {
                UserName = cpf,
                Email = email,
                EmailConfirmed = true,
                User_Type = user_type.Formando
            };

            var result = await _userManager.CreateAsync(user, cpf);

            if (!result.Succeeded) {
                _notifications.AddIdentityErrors(result);
                return null;
            }

            return user.Id;
        }

        public async Task<Graduate> Insert(Graduate obj) {

            obj.Validate(obj, new GraduateValidator());
            _notifications.AddNotifications(obj.ValidationResult);

            foreach (var item in obj.Address) {
                item.Validate(item, new AddressValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            foreach (var item in obj.Phone) {
                item.Validate(item, new PhoneValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            if (!_notifications.HasNotifications) {
                obj.AddUser(await CreateUser(obj.Cpf, obj.Email));
            }


            //NOTA# adicionar uma condição para se caso der errado para adiconar um novo usuario apagar o usuario criado
            if (!_notifications.HasNotifications) {
                await Post(obj);
            }

            return obj;
        }

        public async Task<Graduate> Update(GraduateDto graduateDto) {

            Graduate graduate = await _graduateRepository.GetAllById(graduateDto.GraduateId);

            _mapper.Map(graduateDto, graduate);

            graduate.Validate(graduate, new GraduateValidator());
            _notifications.AddNotifications(graduate.ValidationResult);

            foreach (var item in graduate.Address) {
                item.Validate(item, new AddressValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }
          
            foreach (var item in graduate.Phone) {
                item.Validate(item, new PhoneValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            if (!_notifications.HasNotifications) {
                await Put(graduate);
            }

            return graduate;
        }

        public async Task<Graduate> GetAllById (string id) {
            return await _graduateRepository.GetAllById(id);
        }

        public async Task<IList<GraduateSearchResponse>> Search(GraduateSearch search) {

            var Graduates = await _graduateRepository.GetWhere(
                c => c.Name.ToUpper().Contains(search.Name.ToUpper())           &&
                c.Cpf.ToUpper().Contains(search.Cpf.ToUpper())                  &&
                c.Rg.ToUpper().Contains(search.Rg.ToUpper())                    &&
                c.DadName.ToUpper().Contains(search.DadName.ToUpper())          &&
                c.MotherName.ToUpper().Contains(search.MotherName.ToUpper())    &&
                c.Email.ToUpper().Contains(search.Email.ToUpper())
                );

            var GraduatesResponse = _mapper.Map<IList<GraduateSearchResponse>>(Graduates);

            //public string PhoneNumber { get; set; }
            
            return GraduatesResponse;
        }
    }
}
