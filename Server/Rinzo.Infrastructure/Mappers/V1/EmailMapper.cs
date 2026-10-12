using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;

namespace Rinzo.Infrastructure.Mappers.V1
{
    public static class EmailMapper
    {
        public static Email ToEmailDatabase(Email entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Email
            {
                Id = entity.Id,
                EmailAddress = entity.EmailAddress,
                EmailType = entity.EmailType,
            };
        }

        public static EmailModel ToEmailModel(Email model)
        {
            if (model == null)
            {
                return null;
            }

            return new EmailModel
            {
                Id = model.Id,
                EmailAddress = model.EmailAddress,
                EmailType = (Rinzo.Core.Models.Common.V1.EmailCategory)model.EmailType,
            };
        }
    }
}
