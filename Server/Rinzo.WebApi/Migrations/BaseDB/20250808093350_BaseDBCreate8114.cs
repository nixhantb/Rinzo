using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobLeet.WebApi.Migrations.BaseDB
{
    /// <inheritdoc />
    public partial class BaseDBCreate8114 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jblt_experience_jblt_company_CompanyId",
                table: "jblt_experience"
            );

            migrationBuilder.DropIndex(
                name: "IX_jblt_experience_CompanyId",
                table: "jblt_experience"
            );

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "jblt_experience",
                newName: "Company"
            );

            migrationBuilder.AddColumn<List<string>>(
                name: "Responsibilities",
                table: "jblt_experience",
                type: "text[]",
                nullable: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Responsibilities", table: "jblt_experience");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "jblt_experience",
                newName: "CompanyId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_jblt_experience_CompanyId",
                table: "jblt_experience",
                column: "CompanyId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_jblt_experience_jblt_company_CompanyId",
                table: "jblt_experience",
                column: "CompanyId",
                principalTable: "jblt_company",
                principalColumn: "company_id"
            );
        }
    }
}
