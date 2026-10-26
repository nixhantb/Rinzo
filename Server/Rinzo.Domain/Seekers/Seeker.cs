using Rinzo.Domain.Common;
using Rinzo.Domain.Common.ValueObjects;

namespace Rinzo.Domain.Seekers;

public sealed class Seeker : BaseEntity
{
    public PersonName PersonName { get; private set; } = null!;
    public Phone? Phone { get; private set; }
    public Address? Address { get; private set; }
    public DateOnly? DateOfBirth { get; private set; }
    public string? ProfileSummary { get; private set; }
    public List<Skill> Skills { get; private set; } = [];
    public List<Education> Education { get; private set; } = [];
    public List<Experience> Experience { get; private set; } = [];
    public List<Qualification> Qualifications { get; private set; } = [];
    public List<SocialMedia> SocialMedias { get; private set; } = [];
    public List<Project> Projects { get; private set; } = [];
    public List<string> Interests { get; private set; } = [];
    public List<string> Achievements { get; private set; } = [];

    private Seeker() { }

    public static Seeker Create(
        PersonName personName,
        Phone? phone,
        Address? address,
        DateOnly? dateOfBirth,
        string? profileSummary,
        List<Skill> skills,
        List<Education> education,
        List<Experience> experience,
        List<Qualification> qualifications,
        List<SocialMedia> socialMedias,
        List<Project> projects,
        List<string> interests,
        List<string> achievements
    )
    {
        ArgumentNullException.ThrowIfNull(personName);

        var seeker = new Seeker
        {
            PersonName = personName,
            Phone = phone,
            Address = address,
            DateOfBirth = dateOfBirth,
            ProfileSummary = profileSummary?.Trim(),
            Skills = skills,
            Education = education,
            Experience = experience,
            Qualifications = qualifications,
            SocialMedias = socialMedias,
            Projects = projects,
            Interests = interests,
            Achievements = achievements,
        };

        seeker.AddDomainEvent(new SeekerCreatedEvent(seeker.Id));
        return seeker;
    }

    public void Update(
        PersonName personName,
        Phone? phone,
        Address? address,
        DateOnly? dateOfBirth,
        string? profileSummary,
        List<Skill> skills,
        List<Education> education,
        List<Experience> experience,
        List<Qualification> qualifications,
        List<SocialMedia> socialMedias,
        List<Project> projects,
        List<string> interests,
        List<string> achievements
    )
    {
        ArgumentNullException.ThrowIfNull(personName);

        PersonName = personName;
        Phone = phone;
        Address = address;
        DateOfBirth = dateOfBirth;
        ProfileSummary = profileSummary?.Trim();
        Skills = skills;
        Education = education;
        Experience = experience;
        Qualifications = qualifications;
        SocialMedias = socialMedias;
        Projects = projects;
        Interests = interests;
        Achievements = achievements;
        MarkAsUpdated();
    }
}
