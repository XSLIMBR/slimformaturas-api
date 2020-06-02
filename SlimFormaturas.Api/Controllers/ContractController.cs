using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Collections.Generic;
using SlimFormaturas.Domain.Dto.Graduate;

namespace SlimFormaturas.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ApiController {

        readonly IMapper _mapper;

        public ContractController (
            NotificationHandler notifications,
            IMapper mapper
            ) : base(notifications) {
            _mapper = mapper;
        }

    }
}