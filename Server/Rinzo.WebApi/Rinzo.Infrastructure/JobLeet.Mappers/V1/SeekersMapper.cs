using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Api.Models.Seekers.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Seekers.V1;

namespace JobLeet.WebApi.JobLeet.Mappers.V1
{
    public static class SeekersMapper
    {
        public static Seeker ToSeekerDataBase(Seeker entity, string UserId)
        {
            if (entity == null)
            {
                return null;
            }

            return new Seeker
            {
                Id = UserId,
                PersonName = new()
                {
                    Id = entity.PersonName.Id,
                    FirstName = entity.PersonName.FirstName,
                    MiddleName = entity.PersonName.MiddleName,
                    LastName = entity.PersonName.LastName,
                },

                Projects = ProjectsMapper.ToProjectDatabase(entity.Projects),

                Phone = PhoneMapper.ToPhoneDatabase(entity.Phone),
                Address = AddressMapper.ToAddressDatabase(entity.Address),
                Skills = SkillsMapper.ToSkillsDB(entity.Skills),
                Education = EducationMapper.ToEducationDatabase(entity.Education),
                Experience = ExperienceMapper.ToExperienceDatabase(entity.Experience),
                DateOfBirth = entity.DateOfBirth,

                Qualifications = entity
                    .Qualifications?.Select(q => new Core.Entities.Common.V1.Qualification
                    {
                        Id = q.Id,
                        QualificationType = (Core.Entities.Common.V1.QualificationCategory)
                            q.QualificationType,
                        QualificationInformation = q.QualificationInformation,
                    })
                    .ToList(),

                ProfileSummary = entity.ProfileSummary,
                SocialMedias = entity
                    .SocialMedias?.Select(sm => new Core.Entities.Seekers.V1.SocialMedia
                    {
                        Id = sm.Id,
                        Title = sm.Title,
                        Url = sm.Url,
                    })
                    .ToList(),

                Interests = entity.Interests,
                Achievements = entity.Achievements,
            };
        }

        // API Response
        public static SeekerModel ToSeekerModel(Seeker model)
        {
            if (model == null)
            {
                return null;
            }

            return new SeekerModel
            {
                Id = model.Id,
                personNameModel = new()
                {
                    Id = model.PersonName.Id,
                    FirstName = model.PersonName.FirstName,
                    MiddleName = model.PersonName.MiddleName,
                    LastName = model.PersonName.LastName,
                },
                Projects =
                    model.Projects != null ? ProjectsMapper.ToProjectModel(model.Projects) : null,
                Phone = model.Phone != null ? PhoneMapper.ToPhoneModel(model.Phone) : null,
                Address =
                    model.Address != null ? AddressMapper.ToAddressModel(model.Address) : null,
                Skills = model.Skills != null ? SkillsMapper.ToSkillModel(model.Skills) : null,
                Education =
                    model.Education != null
                        ? EducationMapper.ToEducationModel(model.Education)
                        : null,

                Experience =
                    model.Experience != null
                        ? ExperienceMapper.ToExperienceModel(model.Experience)
                        : null,
                DateOfBirth = model.DateOfBirth,
                Qualifications = model
                    .Qualifications?.Select(q => new QualificationModel
                    {
                        Id = q.Id,
                        QualificationType = (Api.Models.Common.V1.QualificationCategory)
                            q.QualificationType,
                        QualificationInformation = q.QualificationInformation,
                    })
                    .ToList(),

                ProfileSummary = model.ProfileSummary,
                SocialMedias =
                    model?.SocialMedias != null
                        ? model
                            .SocialMedias.Select(sm => new Api.Models.Seekers.V1.SocialMedia
                            {
                                Id = sm.Id,
                                Title = sm.Title,
                                Url = sm.Url,
                            })
                            .ToList()
                        : new List<Api.Models.Seekers.V1.SocialMedia>(),

                Interests = model.Interests,
                Achievements = model.Achievements,
            };
        }
    }
}
