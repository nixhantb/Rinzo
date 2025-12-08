using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Api.Models.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1;

namespace JobLeet.WebApi.JobLeet.Mappers.V1
{
    public static class JobsMapper
    {
        public static JobEntity ToJobDatabase(JobEntity entity)
        {
            if (entity == null)
                return null;

            return new JobEntity
            {
                Id = entity.Id,
                CompanyDescription = CompanyMapper.ToCompanyDataBase(entity.CompanyDescription),
                JobTitle = entity.JobTitle,
                JobDescription = entity.JobDescription,
                JobType = entity.JobType,
                JobAddress = AddressMapper.ToAddressDatabase(entity.JobAddress),
                Vacancies = entity.Vacancies,
                BasicPay =
                    entity.BasicPay != null
                        ? new()
                        {
                            MinmumPay = entity.BasicPay.MinmumPay,
                            MaximumPay = entity.BasicPay.MaximumPay,
                            Currency = entity.BasicPay.Currency,
                        }
                        : null,
                FunctionalArea = entity.FunctionalArea,
                SkillsRequired = SkillsMapper.ToSkillsDB(entity.SkillsRequired),
                RequiredQualification = new()
                {
                    QualificationType = entity.RequiredQualification!.QualificationType,
                    QualificationInformation = entity
                        .RequiredQualification
                        .QualificationInformation,
                },

                RequiredExperience =
                    entity.RequiredExperience != null
                        ? new() { ExperienceLevel = entity.RequiredExperience.ExperienceLevel }
                        : null,
                PreferredQualifications = entity.PreferredQualifications,
                JobResponsibilities = entity.JobResponsibilities,
                Benefits = entity.Benefits,
                Tags = entity.Tags,
                WorkEnvironment = entity.WorkEnvironment,
                PostingDate = entity.PostingDate,
                ApplicationDeadline = entity.ApplicationDeadline,
            };
        }

        public static JobModel ToJobModel(JobEntity model)
        {
            if (model == null)
                return null;

            return new JobModel
            {
                Id = model.Id,
                CompanyDescription = CompanyMapper.ToCompanyModel(model.CompanyDescription),
                JobTitle = model.JobTitle,
                JobDescription = model.JobDescription,
                JobType = model.JobType,
                JobAddress = AddressMapper.ToAddressModel(model.JobAddress),
                Vacancies = model.Vacancies,
                BasicPay =
                    model.BasicPay != null
                        ? new()
                        {
                            MinmumPay = model.BasicPay.MinmumPay,
                            MaximumPay = model.BasicPay.MaximumPay,
                            Currency = model.BasicPay.Currency,
                        }
                        : null,
                FunctionalArea = model.FunctionalArea,
                SkillsRequired = SkillsMapper.ToSkillModel(model.SkillsRequired),
                RequiredQualification =
                    model.RequiredQualification != null
                        ? new QualificationModel
                        {
                            QualificationType = (Api.Models.Common.V1.QualificationCategory)
                                model.RequiredQualification.QualificationType,
                            QualificationInformation = model
                                .RequiredQualification
                                .QualificationInformation,
                        }
                        : null,
                RequiredExperience =
                    model.RequiredExperience != null
                        ? new()
                        {
                            ExperienceLevel = (Api.Models.Common.V1.ExperienceLevel)
                                model.RequiredExperience.ExperienceLevel,
                        }
                        : null,
                PreferredQualifications = model.PreferredQualifications,
                JobResponsibilities = model.JobResponsibilities,
                Benefits = model.Benefits,
                Tags = model.Tags,
                WorkEnvironment = model.WorkEnvironment,
                PostingDate = model.PostingDate,
                ApplicationDeadline = model.ApplicationDeadline,
            };
        }
    }
}
