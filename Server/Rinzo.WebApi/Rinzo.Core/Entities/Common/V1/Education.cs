using System.ComponentModel.DataAnnotations;

namespace JobLeet.WebApi.JobLeet.Core.Entities.Common.V1
{
    public class Education : BaseEntity
    {
        public string Degree { get; set; }

        public string Major { get; set; }

        public string Institution { get; set; }

        public DateOnly GraduationDate { get; set; }

        public decimal Cgpa { get; set; }
    }
}
