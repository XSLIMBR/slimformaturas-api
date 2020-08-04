using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Dto.Graduate;
using SlimFormaturas.Domain.Dto.Graduate.Response;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IGraduateService : IService<Graduate> {
        Task<string> CreateUser(string cpf, string email);
        Task<GraduateResponse> Insert(GraduateForCreationDto graduateDto);
        Task<GraduateResponse> Update(GraduateDto graduateDto);
        Task<Graduate> GetAllById (string id);
        Task<IList<Graduate>> Search(GraduateSearch data);
    }
}
