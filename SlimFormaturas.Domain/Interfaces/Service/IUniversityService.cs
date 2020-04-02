using SlimFormaturas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service
{
    public interface IUniversityService : IService<University>
    {
        Task<University> Insert(University university);
        Task<University> Update(University university);
    }
}
