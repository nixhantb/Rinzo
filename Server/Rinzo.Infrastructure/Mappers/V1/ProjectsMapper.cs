using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;

namespace Rinzo.Infrastructure.Mappers.V1
{
    public static class ProjectsMapper
    {
        public static List<Project> ToProjectDatabase(List<Project> entity)
        {
            return entity
                .Select(p => new Project
                {
                    Id = p.Id,
                    Title = p.Title,
                    Responsibilities = p.Responsibilities,
                    TechnologiesUsed = p.TechnologiesUsed,
                    Role = p.Role,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    ProjectUrl = p.ProjectUrl,
                    GitHubUrl = p.GitHubUrl,
                })
                .ToList();
        }

        public static List<ProjectModel> ToProjectModel(List<Project> model)
        {
            return model
                .Select(p => new ProjectModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Responsibilities = p.Responsibilities,
                    TechnologiesUsed = p.TechnologiesUsed,
                    Role = p.Role,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    ProjectUrl = p.ProjectUrl,
                    GitHubUrl = p.GitHubUrl,
                })
                .ToList();
        }
    }
}
