using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SlimFormaturas.Domain.Dto.Employee;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Domain.Validators;
using SlimFormaturas.Infra.Data.Repository;
using AutoMapper;
using SlimFormaturas.Infra.CrossCutting.Identity.Models;

namespace SlimFormaturas.Service.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmployeeRepository _EmployeeRepository;
        protected readonly NotificationHandler _notifications;
        protected readonly ITypeGenericRepository _typeGenericRepository;
        readonly IMapper _mapper;

        public EmployeeService(
            IEmployeeRepository EmployeeRepository,
            UserManager<ApplicationUser> userManager,
            NotificationHandler notifications,
             IMapper mapper,
            ITypeGenericRepository typeGenericRepository) : base(EmployeeRepository) {
            _EmployeeRepository = EmployeeRepository;
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

        public async Task<Employee> Insert(Employee obj) {

            obj.Validate(obj, new EmployeeValidator());
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

        public async Task<Employee> Update(EmployeeDto EmployeeDto) {

            Employee Employee = await _EmployeeRepository.GetAllById(EmployeeDto.EmployeeId);

            _mapper.Map(EmployeeDto, Employee);

            Employee.Validate(Employee, new EmployeeValidator());
            _notifications.AddNotifications(Employee.ValidationResult);

            foreach (var item in Employee.Address) {
                item.Validate(item, new AddressValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }
          
            foreach (var item in Employee.Phone) {
                item.Validate(item, new PhoneValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            if (!_notifications.HasNotifications) {
                await Put(Employee);
            }

            return Employee;
        }

        public async Task<Employee> GetAllById (string id) {
            return await _EmployeeRepository.GetAllById(id);
        }

    }
}
