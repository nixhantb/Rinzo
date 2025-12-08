using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Mappers.V1
{
    public static class ExperienceMapper
    {
        public static List<Experience> ToExperienceDatabase(List<Experience> entity)
        {
            return entity
                .Select(ex => new Experience
                {
                    Id = ex.Id,
                    Company = ex.Company,
                    Responsibilities = ex.Responsibilities,
                    ExperienceLevel = ex.ExperienceLevel,
                    ExperienceDateFrom = ex.ExperienceDateFrom,
                })
                .ToList();
        }

        public static List<ExperienceModel> ToExperienceModel(List<Experience> model)
        {
            return model
                .Select(ex => new ExperienceModel
                {
                    Id = ex.Id,
                    CompanyNameModel = ex.Company,
                    Responsibilities = ex.Responsibilities,
                    ExperienceLevel = (Api.Models.Common.V1.ExperienceLevel)ex.ExperienceLevel,
                    ExperienceDateTill = ex.ExperienceDateTill,
                })
                .ToList();
        }
    }
}
