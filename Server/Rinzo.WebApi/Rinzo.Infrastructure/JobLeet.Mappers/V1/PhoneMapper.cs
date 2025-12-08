using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Mappers.V1
{
    public static class PhoneMapper
    {
        public static Phone ToPhoneDatabase(Phone entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Phone
            {
                Id = entity.Id,
                CountryCode = entity.CountryCode,
                PhoneNumber = entity.PhoneNumber,
            };
        }

        public static PhoneModel ToPhoneModel(Phone model)
        {
            if (model == null)
            {
                return null;
            }

            return new PhoneModel
            {
                Id = model.Id,
                CountryCode = model.CountryCode,
                PhoneNumber = model.PhoneNumber,
            };
        }
    }
}
