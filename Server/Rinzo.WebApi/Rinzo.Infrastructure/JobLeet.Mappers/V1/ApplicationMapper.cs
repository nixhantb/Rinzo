using JobLeet.WebApi.JobLeet.Api.Models.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1;

namespace JobLeet.WebApi.JobLeet.Mappers.V1
{
    public static class ApplicationMapper
    {
        public static Application? ToApplicationDataBase(Application? entity, string userId)
        {
            if (entity == null || string.IsNullOrEmpty(userId))
            {
                return null;
            }
            return new Application
            {
                Id = entity.Id,
                SeekerId = entity.SeekerId,
                CompanyId = entity.CompanyId,
                Seekers =
                    entity.Seekers != null
                        ? SeekersMapper.ToSeekerDataBase(entity.Seekers, userId)
                        : null,
                Company =
                    entity.Company != null ? CompanyMapper.ToCompanyDataBase(entity.Company) : null,
                Jobs = entity.Jobs != null ? JobsMapper.ToJobDatabase(entity.Jobs) : null,
                ApplicationDate =
                    entity.ApplicationDate != null
                        ? new ApplicationDate
                        {
                            Id = Guid.NewGuid().ToString(),
                            SubmitDate = entity.ApplicationDate.SubmitDate,
                            ReviewDate = entity.ApplicationDate.ReviewDate,
                            DecisionDate = entity.ApplicationDate.DecisionDate,
                            Comments = entity.ApplicationDate.Comments,
                        }
                        : null,
                Status =
                    entity.Status != null
                        ? new Status { Id = entity.Id, StatusName = entity.Status.StatusName }
                        : null,
            };
        }

        public static ApplicationModel ToApplicationModel(Application model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ApplicationModel
            {
                Id = model.Id,
                SeekerId = model.SeekerId,
                CompanyId = model.CompanyId,
                JobId = model.JobsId,
                Seekers = model.Seekers != null ? SeekersMapper.ToSeekerModel(model.Seekers) : null,
                Company =
                    model.Company != null ? CompanyMapper.ToCompanyModel(model.Company) : null,
                Jobs = model.Jobs != null ? JobsMapper.ToJobModel(model.Jobs) : null,
                ApplicationDate =
                    model.ApplicationDate != null
                        ? new ApplicationDateModel
                        {
                            Id = model.Id,
                            SubmitDate = model.ApplicationDate.SubmitDate,
                            ReviewDate = model.ApplicationDate.ReviewDate,
                            DecisionDate = model.ApplicationDate.DecisionDate,
                            Comments = model.ApplicationDate.Comments,
                        }
                        : null,
                Status =
                    model.Status != null
                        ? new StatusModel
                        {
                            Id = model.Id,
                            StatusName = (Api.Models.Jobs.V1.StatusName)model.Status.StatusName,
                        }
                        : null,
            };
        }
    }
}
