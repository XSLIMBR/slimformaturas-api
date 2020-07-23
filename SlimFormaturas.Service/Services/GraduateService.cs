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
        protected readonly IPhoneRepository _phoneRepository;
        readonly IImageUploadService _imageUploadService;
        readonly IMapper _mapper;

        public GraduateService(
            IGraduateRepository graduateRepository,
            UserManager<ApplicationUser> userManager,
            NotificationHandler notifications,
            IPhoneRepository phoneRepository,
            IImageUploadService imageUploadService,
            IMapper mapper,
            ITypeGenericRepository typeGenericRepository) : base(graduateRepository) {
            _graduateRepository = graduateRepository;
            _userManager = userManager;
            _imageUploadService = imageUploadService;
            _phoneRepository = phoneRepository;
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

        public async Task<Graduate> Insert(GraduateForCreationDto graduateDto) {

            var graduate = _mapper.Map<Graduate>(graduateDto);

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
                graduate.AddUser(await CreateUser(graduate.Cpf, graduate.Email));
            }

            //NOTA# adicionar uma condição para se caso der errado para adiconar um novo usuario apagar o usuario criado
            if (!_notifications.HasNotifications) {
                //graduate.Photo = await _imageUploadService.SingleFile("Uploads/Images/Profile", graduateDto.Photo);
                await Post(graduate);
            }

            return graduate;
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

        public async Task<IList<Graduate>> Search(GraduateSearch search) {

            var graduates = await _graduateRepository.GetWhere(
                c => c.Name.ToUpper().Contains(search.Name.ToUpper())           &&
                c.Cpf.ToUpper().Contains(search.Cpf.ToUpper())                  &&
                c.Rg.ToUpper().Contains(search.Rg.ToUpper())                    &&
                c.DadName.ToUpper().Contains(search.DadName.ToUpper())          &&
                c.MotherName.ToUpper().Contains(search.MotherName.ToUpper())    &&
                c.Email.ToUpper().Contains(search.Email.ToUpper())
                );

            foreach (var graduate in graduates) {
                graduate.Phone = await _phoneRepository.GetWhere(p => p.GraduateId == graduate.GraduateId && p.Default);
            }
           
            //var GraduatesResponse = _mapper.Map<IList<GraduateSearchResponse>>(Graduates);
            
            return graduates;
        }
    }
}
