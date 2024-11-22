using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualityApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCaseNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaseNumber",
                table: "cases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CaseNumber",
                table: "cases",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
