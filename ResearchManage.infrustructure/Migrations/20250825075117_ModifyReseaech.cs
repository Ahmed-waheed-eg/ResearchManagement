using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchManage.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyReseaech : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Researches_Scholars_ResearcherID",
                table: "Researches");

            migrationBuilder.RenameColumn(
                name: "ResearcherID",
                table: "Researches",
                newName: "ScholarID");

            migrationBuilder.RenameIndex(
                name: "IX_Researches_ResearcherID",
                table: "Researches",
                newName: "IX_Researches_ScholarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_Scholars_ScholarID",
                table: "Researches",
                column: "ScholarID",
                principalTable: "Scholars",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Researches_Scholars_ScholarID",
                table: "Researches");

            migrationBuilder.RenameColumn(
                name: "ScholarID",
                table: "Researches",
                newName: "ResearcherID");

            migrationBuilder.RenameIndex(
                name: "IX_Researches_ScholarID",
                table: "Researches",
                newName: "IX_Researches_ResearcherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_Scholars_ResearcherID",
                table: "Researches",
                column: "ResearcherID",
                principalTable: "Scholars",
                principalColumn: "ID");
        }
    }
}
