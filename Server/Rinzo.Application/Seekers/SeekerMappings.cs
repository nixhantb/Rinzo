using Rinzo.Application.Common;
using Rinzo.Domain.Seekers;

namespace Rinzo.Application.Seekers;

public static class SeekerMappings
{
    public static SeekerResponse ToResponse(this Seeker seeker) =>
        new(
            seeker.Id,
            seeker.PersonName.ToDto(),
            seeker.Phone?.ToDto(),
            seeker.Address?.ToDto(),
            seeker.DateOfBirth,
            seeker.ProfileSummary,
            seeker.Skills.Select(s => s.ToDto()).ToList(),
            seeker.Education.Select(e => e.ToDto()).ToList(),
            seeker.Experience.Select(e => e.ToDto()).ToList(),
            seeker.Qualifications.Select(q => q.ToDto()).ToList(),
            seeker.SocialMedias.Select(s => s.ToDto()).ToList(),
            seeker.Projects.Select(p => p.ToDto()).ToList(),
            seeker.Interests,
            seeker.Achievements,
            seeker.CreatedOn,
            seeker.UpdatedOn
        );
}
