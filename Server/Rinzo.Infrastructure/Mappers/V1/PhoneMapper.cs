using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;

namespace Rinzo.Infrastructure.Mappers.V1
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
