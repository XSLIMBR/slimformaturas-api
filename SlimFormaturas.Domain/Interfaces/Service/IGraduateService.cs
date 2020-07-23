using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Dto.Graduate;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IGraduateService : IService<Graduate> {
        Task<string> CreateUser(string cpf, string email);
        Task<Graduate> Insert(GraduateForCreationDto graduateDto);
        Task<Graduate> Update(GraduateDto graduateDto);
        Task<Graduate> GetAllById (string id);
        Task<IList<Graduate>> Search(GraduateSearch search);
    }
}
