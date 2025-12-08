using JobLeet.WebApi.JobLeet.Api.Models.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobLeet.WebApi.JobLeet.Mappers.V1
{
    public static class CompanyMapper
    {
        public static Company ToCompanyDataBase(Company entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Company
            {
                Id = entity.Id,
                CompanyName = entity.CompanyName,

                Profile =
                    entity.Profile == null
                        ? null
                        : new CompanyProfile
                        {
                            Id = entity.Profile.Id,
                            ProfileInfo = entity.Profile.ProfileInfo,
                            ContactPhone =
                                entity.Profile.ContactPhone != null
                                    ? PhoneMapper.ToPhoneDatabase(entity.Profile.ContactPhone)
                                    : null,
                            CompanyAddress =
                                entity.Profile.CompanyAddress != null
                                    ? AddressMapper.ToAddressDatabase(entity.Profile.CompanyAddress)
                                    : null,
                            ContactEmail =
                                entity.Profile.ContactEmail != null
                                    ? EmailMapper.ToEmailDatabase(entity.Profile.ContactEmail)
                                    : null,
                            IndustryTypes = new()
                            {
                                Id = entity.Profile.IndustryTypes.Id,
                                IndustryType = entity.Profile.IndustryTypes.IndustryType,
                            },
                            Website = entity.Profile.Website,
                        },
            };
        }

        public static CompanyModel ToCompanyModel(Company entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new CompanyModel
            {
                Id = entity.Id,
                CompanyName = entity.CompanyName,
                Profile =
                    entity.Profile == null
                        ? null
                        : new CompanyProfileModel
                        {
                            Id = entity.Profile.Id,
                            ProfileInfo = entity.Profile.ProfileInfo,
                            ContactPhone =
                                entity.Profile.ContactPhone != null
                                    ? PhoneMapper.ToPhoneModel(entity.Profile.ContactPhone)
                                    : null,
                            CompanyAddress =
                                entity.Profile.CompanyAddress != null
                                    ? AddressMapper.ToAddressModel(entity.Profile.CompanyAddress)
                                    : null,
                            ContactEmail =
                                entity.Profile.ContactEmail != null
                                    ? EmailMapper.ToEmailModel(entity.Profile.ContactEmail)
                                    : null,
                            IndustryType =
                                entity.Profile.IndustryTypes != null
                                    ? new Api.Models.Companies.V1.IndustryModel
                                    {
                                        Id = entity.Profile.IndustryTypes.Id,
                                        IndustryType =
                                            entity?.Profile.IndustryTypes.IndustryType != null
                                                ? (Api.Models.Companies.V1.IndustryCategory)(
                                                    entity.Profile.IndustryTypes.IndustryType
                                                )
                                                : default(Api.Models.Companies.V1.IndustryCategory),
                                    }
                                    : null,
                            Website = entity?.Profile.Website,
                        },
            };
        }
    }
}
