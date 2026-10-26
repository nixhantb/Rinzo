using Rinzo.Application.Common;

namespace Rinzo.Application.Seekers;

public sealed record SeekerRequest(
    PersonNameDto PersonName,
    PhoneDto? Phone,
    AddressDto? Address,
    DateOnly? DateOfBirth,
    string? ProfileSummary,
    List<SkillDto> Skills,
    List<EducationDto> Education,
    List<ExperienceDto> Experience,
    List<QualificationDto> Qualifications,
    List<SocialMediaDto> SocialMedias,
    List<ProjectDto> Projects,
    List<string> Interests,
    List<string> Achievements
);

public sealed record SeekerResponse(
    Guid Id,
    PersonNameDto PersonName,
    PhoneDto? Phone,
    AddressDto? Address,
    DateOnly? DateOfBirth,
    string? ProfileSummary,
    List<SkillDto> Skills,
    List<EducationDto> Education,
    List<ExperienceDto> Experience,
    List<QualificationDto> Qualifications,
    List<SocialMediaDto> SocialMedias,
    List<ProjectDto> Projects,
    List<string> Interests,
    List<string> Achievements,
    DateTime CreatedOn,
    DateTime? UpdatedOn
);
