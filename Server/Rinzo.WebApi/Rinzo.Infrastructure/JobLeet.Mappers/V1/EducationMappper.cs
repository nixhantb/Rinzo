using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Mappers.V1
{
    public static class EducationMapper
    {
        public static List<Education> ToEducationDatabase(List<Education> entity)
        {
            return entity
                .Select(e => new Education
                {
                    Id = e.Id,
                    Degree = e.Degree,
                    Major = e.Major,
                    Institution = e.Institution,
                    GraduationDate = e.GraduationDate,
                    Cgpa = e.Cgpa,
                })
                .ToList();
        }

        public static List<EducationModel> ToEducationModel(List<Education> model)
        {
            return model
                .Select(e => new EducationModel
                {
                    Id = e.Id,
                    Degree = e.Degree,
                    Major = e.Major,
                    Institution = e.Institution,
                    GraduationDate = e.GraduationDate,
                    Cgpa = e.Cgpa,
                })
                .ToList();
        }
    }
}
