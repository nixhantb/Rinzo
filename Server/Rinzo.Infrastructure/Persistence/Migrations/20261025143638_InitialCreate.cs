using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rinzo.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_name = table.Column<string>(
                        type: "character varying(100)",
                        maxLength: 100,
                        nullable: false
                    ),
                    profile_info = table.Column<string>(type: "text", nullable: true),
                    website = table.Column<string>(
                        type: "character varying(200)",
                        maxLength: 200,
                        nullable: true
                    ),
                    industry = table.Column<int>(type: "integer", nullable: true),
                    company_address_street = table.Column<string>(type: "text", nullable: true),
                    company_address_city = table.Column<string>(type: "text", nullable: true),
                    company_address_state = table.Column<string>(type: "text", nullable: true),
                    company_address_postal_code = table.Column<string>(
                        type: "text",
                        nullable: true
                    ),
                    company_address_country = table.Column<string>(type: "text", nullable: true),
                    contact_phone_country_code = table.Column<int>(type: "integer", nullable: true),
                    contact_phone_phone_number = table.Column<string>(type: "text", nullable: true),
                    contact_email_address = table.Column<string>(type: "text", nullable: true),
                    contact_email_type = table.Column<int>(type: "integer", nullable: true),
                    created_on = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    updated_on = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companies", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "employers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name_first_name = table.Column<string>(type: "text", nullable: false),
                    name_middle_name = table.Column<string>(type: "text", nullable: true),
                    name_last_name = table.Column<string>(type: "text", nullable: false),
                    employer_address_street = table.Column<string>(type: "text", nullable: true),
                    employer_address_city = table.Column<string>(type: "text", nullable: true),
                    employer_address_state = table.Column<string>(type: "text", nullable: true),
                    employer_address_postal_code = table.Column<string>(
                        type: "text",
                        nullable: true
                    ),
                    employer_address_country = table.Column<string>(type: "text", nullable: true),
                    employer_phone_country_code = table.Column<int>(
                        type: "integer",
                        nullable: true
                    ),
                    employer_phone_phone_number = table.Column<string>(
                        type: "text",
                        nullable: true
                    ),
                    employer_type = table.Column<int>(type: "integer", nullable: false),
                    industry_type = table.Column<int>(type: "integer", nullable: true),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    updated_on = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employers", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "job_applications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    seeker_id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    job_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    submitted_on = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    reviewed_on = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                    decided_on = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                    comments = table.Column<string>(type: "text", nullable: true),
                    created_on = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    updated_on = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_applications", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    job_title = table.Column<string>(
                        type: "character varying(150)",
                        maxLength: 150,
                        nullable: false
                    ),
                    job_description = table.Column<string>(type: "text", nullable: false),
                    job_type = table.Column<string>(
                        type: "character varying(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                    job_address_street = table.Column<string>(type: "text", nullable: true),
                    job_address_city = table.Column<string>(type: "text", nullable: true),
                    job_address_state = table.Column<string>(type: "text", nullable: true),
                    job_address_postal_code = table.Column<string>(type: "text", nullable: true),
                    job_address_country = table.Column<string>(type: "text", nullable: true),
                    vacancies = table.Column<int>(type: "integer", nullable: false),
                    basic_pay_minimum_pay = table.Column<decimal>(type: "numeric", nullable: true),
                    basic_pay_maximum_pay = table.Column<decimal>(type: "numeric", nullable: true),
                    basic_pay_currency = table.Column<string>(type: "text", nullable: true),
                    functional_area = table.Column<string>(type: "text", nullable: true),
                    required_experience_level = table.Column<int>(type: "integer", nullable: true),
                    preferred_qualifications = table.Column<List<string>>(
                        type: "text[]",
                        nullable: false
                    ),
                    job_responsibilities = table.Column<List<string>>(
                        type: "text[]",
                        nullable: false
                    ),
                    benefits = table.Column<List<string>>(type: "text[]", nullable: false),
                    tags = table.Column<List<string>>(type: "text[]", nullable: false),
                    work_environment = table.Column<string>(type: "text", nullable: true),
                    posting_date = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    application_deadline = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                    created_on = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    updated_on = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_jobs", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "seekers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    person_name_first_name = table.Column<string>(type: "text", nullable: false),
                    person_name_middle_name = table.Column<string>(type: "text", nullable: true),
                    person_name_last_name = table.Column<string>(type: "text", nullable: false),
                    phone_country_code = table.Column<int>(type: "integer", nullable: true),
                    phone_phone_number = table.Column<string>(type: "text", nullable: true),
                    address_street = table.Column<string>(type: "text", nullable: true),
                    address_city = table.Column<string>(type: "text", nullable: true),
                    address_state = table.Column<string>(type: "text", nullable: true),
                    address_postal_code = table.Column<string>(type: "text", nullable: true),
                    address_country = table.Column<string>(type: "text", nullable: true),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    profile_summary = table.Column<string>(type: "text", nullable: true),
                    interests = table.Column<List<string>>(type: "text[]", nullable: false),
                    achievements = table.Column<List<string>>(type: "text[]", nullable: false),
                    created_on = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    updated_on = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_seekers", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "job_required_qualifications",
                columns: table => new
                {
                    job_id = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    type = table.Column<int>(type: "integer", nullable: false),
                    information = table.Column<string>(type: "text", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_required_qualifications", x => new { x.job_id, x.id });
                    table.ForeignKey(
                        name: "fk_job_required_qualifications_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "job_required_skills",
                columns: table => new
                {
                    job_id = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_required_skills", x => new { x.job_id, x.id });
                    table.ForeignKey(
                        name: "fk_job_required_skills_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "seeker_education",
                columns: table => new
                {
                    seeker_id = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    degree = table.Column<string>(type: "text", nullable: false),
                    major = table.Column<string>(type: "text", nullable: false),
                    institution = table.Column<string>(type: "text", nullable: false),
                    graduation_date = table.Column<DateOnly>(type: "date", nullable: false),
                    cgpa = table.Column<decimal>(type: "numeric", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_seeker_education", x => new { x.seeker_id, x.id });
                    table.ForeignKey(
                        name: "fk_seeker_education_seekers_seeker_id",
                        column: x => x.seeker_id,
                        principalTable: "seekers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "seeker_experience",
                columns: table => new
                {
                    seeker_id = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    level = table.Column<int>(type: "integer", nullable: false),
                    company = table.Column<string>(type: "text", nullable: false),
                    responsibilities = table.Column<List<string>>(type: "text[]", nullable: false),
                    from_date = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    till_date = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_seeker_experience", x => new { x.seeker_id, x.id });
                    table.ForeignKey(
                        name: "fk_seeker_experience_seekers_seeker_id",
                        column: x => x.seeker_id,
                        principalTable: "seekers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "seeker_projects",
                columns: table => new
                {
                    seeker_id = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    title = table.Column<string>(type: "text", nullable: false),
                    responsibilities = table.Column<List<string>>(type: "text[]", nullable: false),
                    technologies_used = table.Column<List<string>>(type: "text[]", nullable: false),
                    role = table.Column<string>(type: "text", nullable: true),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true),
                    project_url = table.Column<string>(type: "text", nullable: true),
                    git_hub_url = table.Column<string>(type: "text", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_seeker_projects", x => new { x.seeker_id, x.id });
                    table.ForeignKey(
                        name: "fk_seeker_projects_seekers_seeker_id",
                        column: x => x.seeker_id,
                        principalTable: "seekers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "seeker_qualifications",
                columns: table => new
                {
                    seeker_id = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    type = table.Column<int>(type: "integer", nullable: false),
                    information = table.Column<string>(type: "text", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_seeker_qualifications", x => new { x.seeker_id, x.id });
                    table.ForeignKey(
                        name: "fk_seeker_qualifications_seekers_seeker_id",
                        column: x => x.seeker_id,
                        principalTable: "seekers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "seeker_skills",
                columns: table => new
                {
                    seeker_id = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_seeker_skills", x => new { x.seeker_id, x.id });
                    table.ForeignKey(
                        name: "fk_seeker_skills_seekers_seeker_id",
                        column: x => x.seeker_id,
                        principalTable: "seekers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "seeker_social_medias",
                columns: table => new
                {
                    seeker_id = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    title = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_seeker_social_medias", x => new { x.seeker_id, x.id });
                    table.ForeignKey(
                        name: "fk_seeker_social_medias_seekers_seeker_id",
                        column: x => x.seeker_id,
                        principalTable: "seekers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "ix_companies_company_name",
                table: "companies",
                column: "company_name",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_employers_company_id",
                table: "employers",
                column: "company_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_job_applications_seeker_id_job_id",
                table: "job_applications",
                columns: new[] { "seeker_id", "job_id" },
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_jobs_company_id",
                table: "jobs",
                column: "company_id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "companies");

            migrationBuilder.DropTable(name: "employers");

            migrationBuilder.DropTable(name: "job_applications");

            migrationBuilder.DropTable(name: "job_required_qualifications");

            migrationBuilder.DropTable(name: "job_required_skills");

            migrationBuilder.DropTable(name: "seeker_education");

            migrationBuilder.DropTable(name: "seeker_experience");

            migrationBuilder.DropTable(name: "seeker_projects");

            migrationBuilder.DropTable(name: "seeker_qualifications");

            migrationBuilder.DropTable(name: "seeker_skills");

            migrationBuilder.DropTable(name: "seeker_social_medias");

            migrationBuilder.DropTable(name: "jobs");

            migrationBuilder.DropTable(name: "seekers");
        }
    }
}
