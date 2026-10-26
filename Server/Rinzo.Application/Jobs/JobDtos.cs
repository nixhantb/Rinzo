using Rinzo.Application.Common;
using Rinzo.Domain.Common.ValueObjects;

namespace Rinzo.Application.Jobs;

public sealed record JobRequest(
    Guid CompanyId,
    string JobTitle,
    string JobDescription,
    string JobType,
    AddressDto? JobAddress,
    int Vacancies,
    BasicPayDto? BasicPay,
    string? FunctionalArea,
    List<SkillDto> RequiredSkills,
    List<QualificationDto> RequiredQualifications,
    ExperienceLevel? RequiredExperienceLevel,
    List<string> PreferredQualifications,
    List<string> JobResponsibilities,
    List<string> Benefits,
    List<string> Tags,
    string? WorkEnvironment,
    DateTime? ApplicationDeadline
);

public sealed record JobResponse(
    Guid Id,
    Guid CompanyId,
    string JobTitle,
    string JobDescription,
    string JobType,
    AddressDto? JobAddress,
    int Vacancies,
    BasicPayDto? BasicPay,
    string? FunctionalArea,
    List<SkillDto> RequiredSkills,
    List<QualificationDto> RequiredQualifications,
    ExperienceLevel? RequiredExperienceLevel,
    List<string> PreferredQualifications,
    List<string> JobResponsibilities,
    List<string> Benefits,
    List<string> Tags,
    string? WorkEnvironment,
    DateTime PostingDate,
    DateTime? ApplicationDeadline,
    DateTime CreatedOn,
    DateTime? UpdatedOn
);
