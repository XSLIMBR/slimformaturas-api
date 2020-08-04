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
using SlimFormaturas.Domain.Dto.Graduate.Response;

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

            await _userManager.CreateAsync(user, cpf);

            return user.Id;
        }

        public async Task<GraduateResponse> Insert(GraduateForCreationDto graduateDto) {

            var graduate = _mapper.Map<Graduate>(graduateDto);

            if(await _graduateRepository.FirstOrDefault(a => a.Cpf == graduate.Cpf) != null) {
                _notifications.AddNotification("404","CPF","Esse CPF já está cadastrado!");
            }

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
                graduate.AddUser(await CreateUser(graduate.Cpf, graduate.Email).ConfigureAwait(false));
                graduate.Photo = await _imageUploadService.SingleFile(@"Uploads\Images\Profile\", graduateDto.Photo);
                await Post(graduate);
            }

            return _mapper.Map<GraduateResponse>(graduate);
        }

        public async Task<GraduateResponse> Update(GraduateDto graduateDto) {

            Graduate graduate = await _graduateRepository.GetAllById(graduateDto.GraduateId);

            if (graduate == null) {
                _notifications.AddNotification("404", "GraduateId", "Graduate with id = " + graduateDto.GraduateId + " not found");
                return null;
            }

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

            return _mapper.Map<GraduateResponse>(graduate);
        }

        public async Task<Graduate> GetAllById (string id) {
            return await _graduateRepository.GetAllById(id);
        }

        public async Task<IList<Graduate>> Search(GraduateSearch data) {

            var graduates = await _graduateRepository.GetWhere(
                c => c.Name.ToUpper().Contains(data.Name.ToUpper())           &&
                c.Cpf.ToUpper().Contains(data.Cpf.ToUpper())                  &&
                c.Rg.ToUpper().Contains(data.Rg.ToUpper())                    &&
                c.DadName.ToUpper().Contains(data.DadName.ToUpper())          &&
                c.MotherName.ToUpper().Contains(data.MotherName.ToUpper())    &&
                c.Email.ToUpper().Contains(data.Email.ToUpper())
                );

            foreach (var graduate in graduates) {
                graduate.Phone = await _phoneRepository.GetWhere(p => p.GraduateId == graduate.GraduateId && p.Default);
            }


            return graduates;
        }
    }
}
