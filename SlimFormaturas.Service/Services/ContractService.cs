using AutoMapper;
using SlimFormaturas.Domain.Dto.Contract;
using SlimFormaturas.Domain.Dto.Contract.Response;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Domain.Validators;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ContractResponse> Insert(ContractForCreationDto contractDto) {
            var contract = _mapper.Map<Contract>(contractDto);

            contract.Validate(contract, new ContractValidator());
            _notifications.AddNotifications(contract.ValidationResult);

            if (!_notifications.HasNotifications) {
                await Post(contract);
            }

            return _mapper.Map<ContractResponse>(contract);
        }

        public async Task<ContractResponse> Update(ContractDto contractDto) {

            var contract = await _contractRepository.GetAllById(contractDto.ContractId);

            _mapper.Map(contractDto, contract);

            contract.Validate(contract, new ContractValidator());
            _notifications.AddNotifications(contract.ValidationResult);

            if (!_notifications.HasNotifications) {
                await Put(contract);
            }

            return _mapper.Map<ContractResponse>(contract);
        }

        public Task<Contract> GetAllById(string id) {
            return _contractRepository.GetAllById(id);
        }

        public Task<IList<ContractSearchResponse>> Search(ContractSearch data) {
            throw new System.NotImplementedException();
        }

        public async Task<IList<ContractSearchResponse>> GetByAnyKey(string key) {
            var contracts = await _contractRepository.GetWhere(c => c.Code.ToUpper().Contains(key.ToUpper()));
            return _mapper.Map<IList<ContractSearchResponse>>(contracts);
        }
    }
}
