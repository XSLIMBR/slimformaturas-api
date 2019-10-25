using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IGraduateService : IService<Graduate> {
        Task<string> CreateUser(string cpf, string email);
        Task<Graduate> Insert(Graduate obj);
        Task<Graduate> Update(Graduate graduate);
    }
}
