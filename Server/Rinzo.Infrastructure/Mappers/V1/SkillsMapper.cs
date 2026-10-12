using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;

namespace Rinzo.Infrastructure.Mappers.V1
{
    public static class SkillsMapper
    {
        public static Skill ToSkillsDB(Skill entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Skill
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
            };
        }

        public static SkillModel ToSkillModel(Skill model)
        {
            if (model == null)
            {
                return null;
            }

            return new SkillModel
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
            };
        }
    }
}
