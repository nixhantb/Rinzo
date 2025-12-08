using System.Text.Json;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts.V1
{
    public class JobConfiguration : IEntityTypeConfiguration<JobEntity>
    {
        public void Configure(EntityTypeBuilder<JobEntity> builder)
        {
            builder.ToTable("jblt_job");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("job_id");

            builder.Property(e => e.JobTitle).HasColumnName("job_title");
            builder.Property(e => e.JobDescription).HasColumnName("job_description");
            builder.Property(e => e.JobType).HasColumnName("job_type");
            builder.Property(e => e.Vacancies).HasColumnName("job_vacancies");
            builder.Property(e => e.FunctionalArea).HasColumnName("job_functional_area");
            builder.Property(e => e.PostingDate).HasColumnName("job_posting_date");
            builder.Property(e => e.WorkEnvironment).HasColumnName("job_workenvironment");
            builder.Property(e => e.ApplicationDeadline).HasColumnName("job_applicationdeadline");

            var valueComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()
            );

            var basicPayConverter = new ValueConverter<BasicPay, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<BasicPay>(v, (JsonSerializerOptions)null)
            );

            builder
                .Property(e => e.PreferredQualifications)
                .HasColumnName("preferred_qualifications")
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
                )
                .Metadata.SetValueComparer(valueComparer);

            builder
                .Property(e => e.BasicPay)
                .HasColumnName("job_basic_pay")
                .HasConversion(basicPayConverter);

            builder
                .Property(e => e.JobResponsibilities)
                .HasColumnName("job_responsibility")
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
                )
                .Metadata.SetValueComparer(valueComparer);

            builder
                .Property(e => e.Benefits)
                .HasColumnName("job_benefits")
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
                )
                .Metadata.SetValueComparer(valueComparer);

            builder
                .Property(e => e.Tags)
                .HasColumnName("job_tags")
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
                )
                .Metadata.SetValueComparer(valueComparer);
        }
    }
}
