using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchManage.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFiledsToScholar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Scholars",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Scholars");
        }
    }
}
