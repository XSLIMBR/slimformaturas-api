using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using AutoMapper;
using SlimFormaturas.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Validators.Extensions;
using SlimFormaturas.Domain.Validators;
using SlimFormaturas.Domain.Dto.Seller;
using SlimFormaturas.Domain.Dto.Seller.Response;

namespace SlimFormaturas.Service.Services
{
    public class SellerService : BaseService<Seller>, ISellerService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISellerRepository _sellerRepository;
        protected readonly NotificationHandler _notifications;
        protected readonly ITypeGenericRepository _typeGenericRepository;
        readonly IMapper _mapper;

        public SellerService(
            ISellerRepository sellerRepository,
            UserManager<ApplicationUser> userManager,
            NotificationHandler notifications,
            IMapper mapper,
            ITypeGenericRepository typeGenericRepository) : base(sellerRepository)
        {
            _sellerRepository = sellerRepository;
            _userManager = userManager;
            _notifications = notifications;
            _typeGenericRepository = typeGenericRepository;
            _mapper = mapper;
        }

        public async Task<string> CreateUser(string cpf, string email)
        {
            var user = new ApplicationUser
            {
                UserName = cpf,
                Email = email,
                EmailConfirmed = true,
                User_Type = user_type.Vendedor
            };

            var result = await _userManager.CreateAsync(user, cpf);

            if (!result.Succeeded)
            {
                _notifications.AddIdentityErrors(result);
                return null;
            }

            return user.Id;
        }

        public async Task<SellerResponse> Insert(Seller obj)
        {

            if (await _sellerRepository.FirstOrDefault(a => a.Cpf == obj.Cpf) != null)
            {
                _notifications.AddNotification("404", "CPF", "Esse CPF já está cadastrado!");
            }

            obj.Validate(obj, new SellerValidator());
            _notifications.AddNotifications(obj.ValidationResult);

            foreach (var item in obj.Address)
            {
                item.Validate(item, new AddressValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            foreach (var item in obj.Phone)
            {
                item.Validate(item, new PhoneValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            if (!_notifications.HasNotifications)
            {
                obj.AddUser(await CreateUser(obj.Cpf, obj.Email).ConfigureAwait(false));
            }


            //NOTA# adicionar uma condição para se caso der errado para adiconar um novo usuario apagar o usuario criado
            if (!_notifications.HasNotifications)
            {
                await Post(obj);
            }

            return _mapper.Map<SellerResponse>(obj);
        }

        public async Task<SellerResponse> Update(SellerDto sellerDto)
        {

            Seller seller = await _sellerRepository.GetAllById(sellerDto.SellerId);

            _mapper.Map(sellerDto, seller);

            seller.Validate(seller, new SellerValidator());
            _notifications.AddNotifications(seller.ValidationResult);

            foreach (var item in seller.Address)
            {
                item.Validate(item, new AddressValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            foreach (var item in seller.Phone)
            {
                item.Validate(item, new PhoneValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            if (!_notifications.HasNotifications)
            {
                await Put(seller);
            }

            return _mapper.Map<SellerResponse>(seller);
        }

        public async Task<Seller> GetAllById(string id)
        {
            return await _sellerRepository.GetAllById(id);
        }
    }
}
