using Rinzo.Domain.Common.ValueObjects;

namespace Rinzo.Application.Common;

// Shared DTOs for the value objects that several resources embed. Unlike an aggregate
// root, a value object has no server-generated fields, so one shape works for both
// what the client sends and what it gets back.
public sealed record AddressDto(
    string Street,
    string City,
    string State,
    string PostalCode,
    string Country
);

public sealed record PhoneDto(int CountryCode, string PhoneNumber);

public sealed record EmailDto(string Address, EmailType Type);

public sealed record PersonNameDto(string FirstName, string? MiddleName, string LastName);

public sealed record BasicPayDto(decimal MinimumPay, decimal MaximumPay, string Currency);

public sealed record SkillDto(string Title, string? Description);

public sealed record QualificationDto(QualificationType Type, string Information);

public sealed record EducationDto(
    string Degree,
    string Major,
    string Institution,
    DateOnly GraduationDate,
    decimal Cgpa
);

public sealed record ExperienceDto(
    ExperienceLevel Level,
    string Company,
    List<string> Responsibilities,
    DateTime FromDate,
    DateTime? TillDate
);

public sealed record ProjectDto(
    string Title,
    List<string> Responsibilities,
    List<string> TechnologiesUsed,
    string? Role,
    DateOnly StartDate,
    DateOnly? EndDate,
    string? ProjectUrl,
    string? GitHubUrl
);

public sealed record SocialMediaDto(string Title, string Url);

public static class ValueObjectMappings
{
    public static AddressDto ToDto(this Address address) =>
        new(address.Street, address.City, address.State, address.PostalCode, address.Country);

    public static Address ToDomain(this AddressDto dto) =>
        Address.Create(dto.Street, dto.City, dto.State, dto.PostalCode, dto.Country);

    public static PhoneDto ToDto(this Phone phone) => new(phone.CountryCode, phone.PhoneNumber);

    public static Phone ToDomain(this PhoneDto dto) =>
        Phone.Create(dto.CountryCode, dto.PhoneNumber);

    public static EmailDto ToDto(this Email email) => new(email.Address, email.Type);

    public static Email ToDomain(this EmailDto dto) => Email.Create(dto.Address, dto.Type);

    public static PersonNameDto ToDto(this PersonName name) =>
        new(name.FirstName, name.MiddleName, name.LastName);

    public static PersonName ToDomain(this PersonNameDto dto) =>
        PersonName.Create(dto.FirstName, dto.MiddleName, dto.LastName);

    public static BasicPayDto ToDto(this BasicPay pay) =>
        new(pay.MinimumPay, pay.MaximumPay, pay.Currency);

    public static BasicPay ToDomain(this BasicPayDto dto) =>
        BasicPay.Create(dto.MinimumPay, dto.MaximumPay, dto.Currency);

    public static SkillDto ToDto(this Skill skill) => new(skill.Title, skill.Description);

    public static Skill ToDomain(this SkillDto dto) => Skill.Create(dto.Title, dto.Description);

    public static QualificationDto ToDto(this Qualification qualification) =>
        new(qualification.Type, qualification.Information);

    public static Qualification ToDomain(this QualificationDto dto) =>
        Qualification.Create(dto.Type, dto.Information);

    public static EducationDto ToDto(this Education education) =>
        new(
            education.Degree,
            education.Major,
            education.Institution,
            education.GraduationDate,
            education.Cgpa
        );

    public static Education ToDomain(this EducationDto dto) =>
        Education.Create(dto.Degree, dto.Major, dto.Institution, dto.GraduationDate, dto.Cgpa);

    public static ExperienceDto ToDto(this Experience experience) =>
        new(
            experience.Level,
            experience.Company,
            experience.Responsibilities,
            experience.FromDate,
            experience.TillDate
        );

    public static Experience ToDomain(this ExperienceDto dto) =>
        Experience.Create(dto.Level, dto.Company, dto.Responsibilities, dto.FromDate, dto.TillDate);

    public static ProjectDto ToDto(this Project project) =>
        new(
            project.Title,
            project.Responsibilities,
            project.TechnologiesUsed,
            project.Role,
            project.StartDate,
            project.EndDate,
            project.ProjectUrl,
            project.GitHubUrl
        );

    public static Project ToDomain(this ProjectDto dto) =>
        Project.Create(
            dto.Title,
            dto.Responsibilities,
            dto.TechnologiesUsed,
            dto.Role,
            dto.StartDate,
            dto.EndDate,
            dto.ProjectUrl,
            dto.GitHubUrl
        );

    public static SocialMediaDto ToDto(this SocialMedia socialMedia) =>
        new(socialMedia.Title, socialMedia.Url);

    public static SocialMedia ToDomain(this SocialMediaDto dto) =>
        SocialMedia.Create(dto.Title, dto.Url);
}
