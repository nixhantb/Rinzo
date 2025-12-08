using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Mappers.V1
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
