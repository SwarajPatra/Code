using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSorting.Api.Migrations
{
    public partial class MigrationV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SortJobs",
                columns: table => new
                {
                    JobId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobInput = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobOutput = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDuration = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortJobs", x => x.JobId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SortJobs");
        }
    }
}
