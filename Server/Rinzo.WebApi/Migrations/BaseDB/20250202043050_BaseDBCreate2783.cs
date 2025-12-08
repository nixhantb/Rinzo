using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobLeet.WebApi.Migrations.BaseDB
{
    /// <inheritdoc />
    public partial class BaseDBCreate2783 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationDate",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DecisionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    EmailType = table.Column<int>(type: "integer", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jblt_education",
                columns: table => new
                {
                    educationid = table.Column<string>(name: "education_id", type: "text", nullable: false),
                    educationdegree = table.Column<string>(name: "education_degree", type: "text", nullable: false),
                    educationmajor = table.Column<string>(name: "education_major", type: "text", nullable: false),
                    educationnstitution = table.Column<string>(name: "education_nstitution", type: "text", nullable: false),
                    educationgraduationdate = table.Column<DateOnly>(name: "education_graduationdate", type: "date", nullable: false),
                    educationcgpa = table.Column<decimal>(name: "education_cgpa", type: "numeric", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_education", x => x.educationid);
                });

            migrationBuilder.CreateTable(
                name: "jblt_industryType",
                columns: table => new
                {
                    industryid = table.Column<string>(name: "industry_id", type: "text", nullable: false),
                    industrytype = table.Column<int>(name: "industry_type", type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_industryType", x => x.industryid);
                });

            migrationBuilder.CreateTable(
                name: "jblt_personName",
                columns: table => new
                {
                    personnameid = table.Column<string>(name: "personname_id", type: "text", nullable: false),
                    personNamefirstname = table.Column<string>(name: "personName_firstname", type: "text", nullable: true),
                    personNamemiddlename = table.Column<string>(name: "personName_middlename", type: "text", nullable: true),
                    personNamelastname = table.Column<string>(name: "personName_lastname", type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_personName", x => x.personnameid);
                });

            migrationBuilder.CreateTable(
                name: "jblt_phone",
                columns: table => new
                {
                    jbltphoneid = table.Column<string>(name: "jblt_phoneid", type: "text", nullable: false),
                    jbltcountrycode = table.Column<int>(name: "jblt_countrycode", type: "integer", nullable: false),
                    jbltphonenumber = table.Column<string>(name: "jblt_phonenumber", type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_phone", x => x.jbltphoneid);
                });

            migrationBuilder.CreateTable(
                name: "jblt_qualification",
                columns: table => new
                {
                    qualificationid = table.Column<string>(name: "qualification_id", type: "text", nullable: false),
                    qualificationtype = table.Column<int>(name: "qualification_type", type: "integer", nullable: false),
                    qualificationinformation = table.Column<string>(name: "qualification_information", type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_qualification", x => x.qualificationid);
                });

            migrationBuilder.CreateTable(
                name: "jblt_skill",
                columns: table => new
                {
                    skillid = table.Column<string>(name: "skill_id", type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_skill", x => x.skillid);
                });

            migrationBuilder.CreateTable(
                name: "jblt_userAddress",
                columns: table => new
                {
                    addressid = table.Column<string>(name: "address_id", type: "text", nullable: false),
                    addressstreet = table.Column<string>(name: "address_street", type: "text", nullable: true),
                    addresscity = table.Column<string>(name: "address_city", type: "text", nullable: true),
                    addressstate = table.Column<string>(name: "address_state", type: "text", nullable: true),
                    addresspostalCode = table.Column<string>(name: "address_postalCode", type: "text", nullable: true),
                    addresscountry = table.Column<string>(name: "address_country", type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_userAddress", x => x.addressid);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Responsibilities = table.Column<List<string>>(type: "text[]", nullable: false),
                    TechnologiesUsed = table.Column<List<string>>(type: "text[]", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ProjectUrl = table.Column<string>(type: "text", nullable: true),
                    GitHubUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    StatusName = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jblt_companyprofile",
                columns: table => new
                {
                    companyprofileid = table.Column<string>(name: "companyprofile_id", type: "text", nullable: false),
                    ProfileInfo = table.Column<string>(type: "text", nullable: true),
                    CompanyAddressId = table.Column<string>(type: "text", nullable: true),
                    ContactPhoneId = table.Column<string>(type: "text", nullable: true),
                    ContactEmailId = table.Column<string>(type: "text", nullable: true),
                    companywebsite = table.Column<string>(name: "company_website", type: "text", nullable: true),
                    IndustryTypesId = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_companyprofile", x => x.companyprofileid);
                    table.ForeignKey(
                        name: "FK_jblt_companyprofile_Emails_ContactEmailId",
                        column: x => x.ContactEmailId,
                        principalTable: "Emails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_jblt_companyprofile_jblt_industryType_IndustryTypesId",
                        column: x => x.IndustryTypesId,
                        principalTable: "jblt_industryType",
                        principalColumn: "industry_id");
                    table.ForeignKey(
                        name: "FK_jblt_companyprofile_jblt_phone_ContactPhoneId",
                        column: x => x.ContactPhoneId,
                        principalTable: "jblt_phone",
                        principalColumn: "jblt_phoneid");
                    table.ForeignKey(
                        name: "FK_jblt_companyprofile_jblt_userAddress_CompanyAddressId",
                        column: x => x.CompanyAddressId,
                        principalTable: "jblt_userAddress",
                        principalColumn: "address_id");
                });

            migrationBuilder.CreateTable(
                name: "jblt_company",
                columns: table => new
                {
                    companyid = table.Column<string>(name: "company_id", type: "text", nullable: false),
                    companyname = table.Column<string>(name: "company_name", type: "text", nullable: true),
                    ProfileId = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_company", x => x.companyid);
                    table.ForeignKey(
                        name: "FK_jblt_company_jblt_companyprofile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "jblt_companyprofile",
                        principalColumn: "companyprofile_id");
                });

            migrationBuilder.CreateTable(
                name: "jblt_employer",
                columns: table => new
                {
                    employerid = table.Column<string>(name: "employer_id", type: "text", nullable: false),
                    NameId = table.Column<string>(type: "text", nullable: true),
                    AddressId = table.Column<string>(type: "text", nullable: true),
                    PhoneId = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<string>(type: "text", nullable: true),
                    IndustryTypeId = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_employer", x => x.employerid);
                    table.ForeignKey(
                        name: "FK_jblt_employer_jblt_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "jblt_company",
                        principalColumn: "company_id");
                    table.ForeignKey(
                        name: "FK_jblt_employer_jblt_industryType_IndustryTypeId",
                        column: x => x.IndustryTypeId,
                        principalTable: "jblt_industryType",
                        principalColumn: "industry_id");
                    table.ForeignKey(
                        name: "FK_jblt_employer_jblt_personName_NameId",
                        column: x => x.NameId,
                        principalTable: "jblt_personName",
                        principalColumn: "personname_id");
                    table.ForeignKey(
                        name: "FK_jblt_employer_jblt_phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "jblt_phone",
                        principalColumn: "jblt_phoneid");
                    table.ForeignKey(
                        name: "FK_jblt_employer_jblt_userAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "jblt_userAddress",
                        principalColumn: "address_id");
                });

            migrationBuilder.CreateTable(
                name: "jblt_experience",
                columns: table => new
                {
                    experienceid = table.Column<string>(name: "experience_id", type: "text", nullable: false),
                    experiencetype = table.Column<int>(name: "experience_type", type: "integer", nullable: false),
                    CompanyId = table.Column<string>(type: "text", nullable: true),
                    ExperienceDateFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExperienceDateTill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_experience", x => x.experienceid);
                    table.ForeignKey(
                        name: "FK_jblt_experience_jblt_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "jblt_company",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "jblt_job",
                columns: table => new
                {
                    jobid = table.Column<string>(name: "job_id", type: "text", nullable: false),
                    CompanyDescriptionId = table.Column<string>(type: "text", nullable: true),
                    jobtitle = table.Column<string>(name: "job_title", type: "text", nullable: true),
                    jobdescription = table.Column<string>(name: "job_description", type: "text", nullable: true),
                    jobtype = table.Column<string>(name: "job_type", type: "text", nullable: true),
                    JobAddressId = table.Column<string>(type: "text", nullable: true),
                    jobvacancies = table.Column<int>(name: "job_vacancies", type: "integer", nullable: true),
                    jobbasicpay = table.Column<string>(name: "job_basic_pay", type: "text", nullable: true),
                    jobfunctionalarea = table.Column<string>(name: "job_functional_area", type: "text", nullable: true),
                    SkillsRequiredId = table.Column<string>(type: "text", nullable: true),
                    RequiredQualificationId = table.Column<string>(type: "text", nullable: true),
                    RequiredExperienceId = table.Column<string>(type: "text", nullable: true),
                    preferredqualifications = table.Column<string>(name: "preferred_qualifications", type: "text", nullable: true),
                    jobresponsibility = table.Column<string>(name: "job_responsibility", type: "text", nullable: true),
                    jobbenefits = table.Column<string>(name: "job_benefits", type: "text", nullable: true),
                    jobtags = table.Column<string>(name: "job_tags", type: "text", nullable: true),
                    jobworkenvironment = table.Column<string>(name: "job_workenvironment", type: "text", nullable: true),
                    jobpostingdate = table.Column<DateTime>(name: "job_posting_date", type: "timestamp with time zone", nullable: true),
                    jobapplicationdeadline = table.Column<DateTime>(name: "job_applicationdeadline", type: "timestamp with time zone", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_job", x => x.jobid);
                    table.ForeignKey(
                        name: "FK_jblt_job_jblt_company_CompanyDescriptionId",
                        column: x => x.CompanyDescriptionId,
                        principalTable: "jblt_company",
                        principalColumn: "company_id");
                    table.ForeignKey(
                        name: "FK_jblt_job_jblt_experience_RequiredExperienceId",
                        column: x => x.RequiredExperienceId,
                        principalTable: "jblt_experience",
                        principalColumn: "experience_id");
                    table.ForeignKey(
                        name: "FK_jblt_job_jblt_qualification_RequiredQualificationId",
                        column: x => x.RequiredQualificationId,
                        principalTable: "jblt_qualification",
                        principalColumn: "qualification_id");
                    table.ForeignKey(
                        name: "FK_jblt_job_jblt_skill_SkillsRequiredId",
                        column: x => x.SkillsRequiredId,
                        principalTable: "jblt_skill",
                        principalColumn: "skill_id");
                    table.ForeignKey(
                        name: "FK_jblt_job_jblt_userAddress_JobAddressId",
                        column: x => x.JobAddressId,
                        principalTable: "jblt_userAddress",
                        principalColumn: "address_id");
                });

            migrationBuilder.CreateTable(
                name: "jblt_seeker",
                columns: table => new
                {
                    seekerid = table.Column<string>(name: "seeker_id", type: "text", nullable: false),
                    PersonNameId = table.Column<string>(type: "text", nullable: true),
                    PhoneId = table.Column<string>(type: "text", nullable: true),
                    AddressId = table.Column<string>(type: "text", nullable: true),
                    SkillsId = table.Column<string>(type: "text", nullable: true),
                    EducationId = table.Column<string>(type: "text", nullable: true),
                    ExperienceId = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    QualificationsId = table.Column<string>(type: "text", nullable: true),
                    ProfileSummary = table.Column<string>(type: "text", nullable: true),
                    Interests = table.Column<List<string>>(type: "text[]", nullable: true),
                    Achievements = table.Column<List<string>>(type: "text[]", nullable: true),
                    ProjectsId = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_seeker", x => x.seekerid);
                    table.ForeignKey(
                        name: "FK_jblt_seeker_Project_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_jblt_seeker_jblt_education_EducationId",
                        column: x => x.EducationId,
                        principalTable: "jblt_education",
                        principalColumn: "education_id");
                    table.ForeignKey(
                        name: "FK_jblt_seeker_jblt_experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "jblt_experience",
                        principalColumn: "experience_id");
                    table.ForeignKey(
                        name: "FK_jblt_seeker_jblt_personName_PersonNameId",
                        column: x => x.PersonNameId,
                        principalTable: "jblt_personName",
                        principalColumn: "personname_id");
                    table.ForeignKey(
                        name: "FK_jblt_seeker_jblt_phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "jblt_phone",
                        principalColumn: "jblt_phoneid");
                    table.ForeignKey(
                        name: "FK_jblt_seeker_jblt_qualification_QualificationsId",
                        column: x => x.QualificationsId,
                        principalTable: "jblt_qualification",
                        principalColumn: "qualification_id");
                    table.ForeignKey(
                        name: "FK_jblt_seeker_jblt_skill_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "jblt_skill",
                        principalColumn: "skill_id");
                    table.ForeignKey(
                        name: "FK_jblt_seeker_jblt_userAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "jblt_userAddress",
                        principalColumn: "address_id");
                });

            migrationBuilder.CreateTable(
                name: "jblt_application",
                columns: table => new
                {
                    applicationid = table.Column<string>(name: "application_id", type: "text", nullable: false),
                    SeekerId = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<string>(type: "text", nullable: false),
                    JobsId = table.Column<string>(type: "text", nullable: false),
                    ApplicationDateId = table.Column<string>(type: "text", nullable: true),
                    StatusId = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jblt_application", x => x.applicationid);
                    table.ForeignKey(
                        name: "FK_jblt_application_ApplicationDate_ApplicationDateId",
                        column: x => x.ApplicationDateId,
                        principalTable: "ApplicationDate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_jblt_application_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_jblt_application_jblt_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "jblt_company",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jblt_application_jblt_job_JobsId",
                        column: x => x.JobsId,
                        principalTable: "jblt_job",
                        principalColumn: "job_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jblt_application_jblt_seeker_SeekerId",
                        column: x => x.SeekerId,
                        principalTable: "jblt_seeker",
                        principalColumn: "seeker_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    SeekerId = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedia_jblt_seeker_SeekerId",
                        column: x => x.SeekerId,
                        principalTable: "jblt_seeker",
                        principalColumn: "seeker_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_jblt_application_ApplicationDateId",
                table: "jblt_application",
                column: "ApplicationDateId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_application_CompanyId",
                table: "jblt_application",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_application_JobsId",
                table: "jblt_application",
                column: "JobsId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_application_SeekerId",
                table: "jblt_application",
                column: "SeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_application_StatusId",
                table: "jblt_application",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_company_ProfileId",
                table: "jblt_company",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_companyprofile_CompanyAddressId",
                table: "jblt_companyprofile",
                column: "CompanyAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_companyprofile_ContactEmailId",
                table: "jblt_companyprofile",
                column: "ContactEmailId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_companyprofile_ContactPhoneId",
                table: "jblt_companyprofile",
                column: "ContactPhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_companyprofile_IndustryTypesId",
                table: "jblt_companyprofile",
                column: "IndustryTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_employer_AddressId",
                table: "jblt_employer",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_employer_CompanyId",
                table: "jblt_employer",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_employer_IndustryTypeId",
                table: "jblt_employer",
                column: "IndustryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_employer_NameId",
                table: "jblt_employer",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_employer_PhoneId",
                table: "jblt_employer",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_experience_CompanyId",
                table: "jblt_experience",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_job_CompanyDescriptionId",
                table: "jblt_job",
                column: "CompanyDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_job_JobAddressId",
                table: "jblt_job",
                column: "JobAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_job_RequiredExperienceId",
                table: "jblt_job",
                column: "RequiredExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_job_RequiredQualificationId",
                table: "jblt_job",
                column: "RequiredQualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_job_SkillsRequiredId",
                table: "jblt_job",
                column: "SkillsRequiredId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_seeker_AddressId",
                table: "jblt_seeker",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_seeker_EducationId",
                table: "jblt_seeker",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_seeker_ExperienceId",
                table: "jblt_seeker",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_seeker_PersonNameId",
                table: "jblt_seeker",
                column: "PersonNameId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_seeker_PhoneId",
                table: "jblt_seeker",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_seeker_ProjectsId",
                table: "jblt_seeker",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_seeker_QualificationsId",
                table: "jblt_seeker",
                column: "QualificationsId");

            migrationBuilder.CreateIndex(
                name: "IX_jblt_seeker_SkillsId",
                table: "jblt_seeker",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedia_SeekerId",
                table: "SocialMedia",
                column: "SeekerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jblt_application");

            migrationBuilder.DropTable(
                name: "jblt_employer");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "ApplicationDate");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "jblt_job");

            migrationBuilder.DropTable(
                name: "jblt_seeker");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "jblt_education");

            migrationBuilder.DropTable(
                name: "jblt_experience");

            migrationBuilder.DropTable(
                name: "jblt_personName");

            migrationBuilder.DropTable(
                name: "jblt_qualification");

            migrationBuilder.DropTable(
                name: "jblt_skill");

            migrationBuilder.DropTable(
                name: "jblt_company");

            migrationBuilder.DropTable(
                name: "jblt_companyprofile");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "jblt_industryType");

            migrationBuilder.DropTable(
                name: "jblt_phone");

            migrationBuilder.DropTable(
                name: "jblt_userAddress");
        }
    }
}
