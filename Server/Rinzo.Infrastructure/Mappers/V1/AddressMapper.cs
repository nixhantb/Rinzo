using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;

namespace Rinzo.Infrastructure.Mappers.V1
{
    public static class AddressMapper
    {
        public static Address ToAddressDatabase(Address entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Address
            {
                Id = entity.Id,
                Street = entity.Street,
                State = entity.State,
                City = entity.City,
                PostalCode = entity.PostalCode,
                Country = entity.Country,
            };
        }

        public static AddressModel ToAddressModel(Address model)
        {
            if (model == null)
            {
                return null;
            }

            return new AddressModel
            {
                Id = model.Id,
                Street = model.Street,
                State = model.State,
                City = model.City,
                PostalCode = model.PostalCode,
                Country = model.Country,
            };
        }
    }
}
