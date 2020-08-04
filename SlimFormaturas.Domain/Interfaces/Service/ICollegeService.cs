using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Dto.College;
using SlimFormaturas.Domain.Dto.College.Response;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface ICollegeService : IService<College> {
        Task<CollegeResponse> Insert(CollegeForCreationDto collegeForCreationDto);
        Task<CollegeResponse> Update(CollegeDto CollegeDto);
        Task<College> GetAllById (string id);
    }
}
