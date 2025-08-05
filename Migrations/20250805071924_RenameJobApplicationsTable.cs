using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sharp_recruit.Migrations
{
    /// <inheritdoc />
    public partial class RenameJobApplicationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications");

            migrationBuilder.RenameTable(
                name: "JobApplications",
                newName: "job_applications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_job_applications",
                table: "job_applications",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_job_applications",
                table: "job_applications");

            migrationBuilder.RenameTable(
                name: "job_applications",
                newName: "JobApplications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications",
                column: "Id");
        }
    }
}
