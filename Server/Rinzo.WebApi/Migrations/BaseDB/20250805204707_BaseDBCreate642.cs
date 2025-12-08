using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobLeet.WebApi.Migrations.BaseDB
{
    /// <inheritdoc />
    public partial class BaseDBCreate642 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jblt_seeker_Project_ProjectsId",
                table: "jblt_seeker"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_jblt_seeker_jblt_education_EducationId",
                table: "jblt_seeker"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_jblt_seeker_jblt_experience_ExperienceId",
                table: "jblt_seeker"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_jblt_seeker_jblt_qualification_QualificationsId",
                table: "jblt_seeker"
            );

            migrationBuilder.DropIndex(name: "IX_jblt_seeker_EducationId", table: "jblt_seeker");

            migrationBuilder.DropIndex(name: "IX_jblt_seeker_ExperienceId", table: "jblt_seeker");

            migrationBuilder.DropIndex(name: "IX_jblt_seeker_ProjectsId", table: "jblt_seeker");

            migrationBuilder.DropIndex(
                name: "IX_jblt_seeker_QualificationsId",
                table: "jblt_seeker"
            );

            migrationBuilder.DropColumn(name: "EducationId", table: "jblt_seeker");

            migrationBuilder.DropColumn(name: "ExperienceId", table: "jblt_seeker");

            migrationBuilder.DropColumn(name: "ProjectsId", table: "jblt_seeker");

            migrationBuilder.DropColumn(name: "QualificationsId", table: "jblt_seeker");

            migrationBuilder.AddColumn<string>(
                name: "SeekerId",
                table: "Project",
                type: "text",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "SeekerId",
                table: "jblt_qualification",
                type: "text",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "SeekerId",
                table: "jblt_experience",
                type: "text",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "SeekerId",
                table: "jblt_education",
                type: "text",
                nullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_Project_SeekerId",
                table: "Project",
                column: "SeekerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_jblt_qualification_SeekerId",
                table: "jblt_qualification",
                column: "SeekerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_jblt_experience_SeekerId",
                table: "jblt_experience",
                column: "SeekerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_jblt_education_SeekerId",
                table: "jblt_education",
                column: "SeekerId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_jblt_education_jblt_seeker_SeekerId",
                table: "jblt_education",
                column: "SeekerId",
                principalTable: "jblt_seeker",
                principalColumn: "seeker_id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_jblt_experience_jblt_seeker_SeekerId",
                table: "jblt_experience",
                column: "SeekerId",
                principalTable: "jblt_seeker",
                principalColumn: "seeker_id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_jblt_qualification_jblt_seeker_SeekerId",
                table: "jblt_qualification",
                column: "SeekerId",
                principalTable: "jblt_seeker",
                principalColumn: "seeker_id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Project_jblt_seeker_SeekerId",
                table: "Project",
                column: "SeekerId",
                principalTable: "jblt_seeker",
                principalColumn: "seeker_id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jblt_education_jblt_seeker_SeekerId",
                table: "jblt_education"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_jblt_experience_jblt_seeker_SeekerId",
                table: "jblt_experience"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_jblt_qualification_jblt_seeker_SeekerId",
                table: "jblt_qualification"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_Project_jblt_seeker_SeekerId",
                table: "Project"
            );

            migrationBuilder.DropIndex(name: "IX_Project_SeekerId", table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_jblt_qualification_SeekerId",
                table: "jblt_qualification"
            );

            migrationBuilder.DropIndex(
                name: "IX_jblt_experience_SeekerId",
                table: "jblt_experience"
            );

            migrationBuilder.DropIndex(name: "IX_jblt_education_SeekerId", table: "jblt_education");

            migrationBuilder.DropColumn(name: "SeekerId", table: "Project");

            migrationBuilder.DropColumn(name: "SeekerId", table: "jblt_qualification");

            migrationBuilder.DropColumn(name: "SeekerId", table: "jblt_experience");

            migrationBuilder.DropColumn(name: "SeekerId", table: "jblt_education");

            migrationBuilder.AddColumn<string>(
                name: "EducationId",
                table: "jblt_seeker",
                type: "text",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "ExperienceId",
                table: "jblt_seeker",
                type: "text",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "ProjectsId",
                table: "jblt_seeker",
                type: "text",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "QualificationsId",
                table: "jblt_seeker",
                type: "text",
                nullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_jblt_seeker_EducationId",
                table: "jblt_seeker",
                column: "EducationId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_jblt_seeker_ExperienceId",
                table: "jblt_seeker",
                column: "ExperienceId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_jblt_seeker_ProjectsId",
                table: "jblt_seeker",
                column: "ProjectsId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_jblt_seeker_QualificationsId",
                table: "jblt_seeker",
                column: "QualificationsId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_jblt_seeker_Project_ProjectsId",
                table: "jblt_seeker",
                column: "ProjectsId",
                principalTable: "Project",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_jblt_seeker_jblt_education_EducationId",
                table: "jblt_seeker",
                column: "EducationId",
                principalTable: "jblt_education",
                principalColumn: "education_id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_jblt_seeker_jblt_experience_ExperienceId",
                table: "jblt_seeker",
                column: "ExperienceId",
                principalTable: "jblt_experience",
                principalColumn: "experience_id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_jblt_seeker_jblt_qualification_QualificationsId",
                table: "jblt_seeker",
                column: "QualificationsId",
                principalTable: "jblt_qualification",
                principalColumn: "qualification_id"
            );
        }
    }
}
