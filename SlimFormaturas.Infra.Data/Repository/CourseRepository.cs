using Microsoft.AspNetCore.Identity;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.CrossCutting.Identity.Models;
using SlimFormaturas.Infra.Data.Context;


namespace SlimFormaturas.Infra.Data.Repository
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(MssqlContext context) : base(context)
        {
        }
    }      
}
