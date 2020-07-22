using AutoMapper;
using SlimFormaturas.Domain.Dto.Contract;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Domain.Validators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlimFormaturas.Service.Services {
    public class ContractService : BaseService<Contract>, IContractService {
        private readonly IContractRepository _contractRepository;
        protected readonly NotificationHandler _notifications;
        protected readonly ITypeGenericRepository _typeGenericRepository;
        readonly IMapper _mapper;
        public ContractService(
            IContractRepository contractRepository,
            NotificationHandler notifications,
             IMapper mapper,
            ITypeGenericRepository typeGenericRepository) : base(contractRepository)
        {
            _contractRepository = contractRepository;
            _notifications = notifications;
            _typeGenericRepository = typeGenericRepository;
            _mapper = mapper;
        }

        public async Task<Contract> Insert(ContractForCreationDto contractDto) {
            var contract = _mapper.Map<Contract>(contractDto);

            contract.Validate(contract, new ContractValidator());
            _notifications.AddNotifications(contract.ValidationResult);

            if (!_notifications.HasNotifications) {
                await Post(contract);
            }

            return contract;
        }

        public async Task<Contract> Update(ContractDto contractDto) {

            Contract contract = await _contractRepository.GetAllById(contractDto.ContractId);

            _mapper.Map(contractDto, contract);

            contract.Validate(contract, new ContractValidator());
            _notifications.AddNotifications(contract.ValidationResult);

            if (!_notifications.HasNotifications) {
                await Put(contract);
            }

            return contract;
        }

        public Task<Contract> GetAllById(string id) {
            throw new System.NotImplementedException();
        }

        public Task<IList<ContractSearchResponse>> Search(ContractSearch search) {
            throw new System.NotImplementedException();
        }
    }
}
