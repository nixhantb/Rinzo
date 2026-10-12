using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;

namespace Rinzo.Infrastructure.Mappers.V1
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
                    ExperienceLevel = ex.ExperienceLevel,
                    ExperienceDateTill = ex.ExperienceDateTill,
                })
                .ToList();
        }
    }
}
