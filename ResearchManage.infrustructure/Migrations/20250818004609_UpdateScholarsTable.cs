using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchManage.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScholarsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Researches_Researchers_ResearcherID",
                table: "Researches");

            migrationBuilder.DropTable(
                name: "Researchers");

            migrationBuilder.CreateTable(
                name: "Scholars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scholars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Scholars_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scholars_DepartmentID",
                table: "Scholars",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_Scholars_ResearcherID",
                table: "Researches",
                column: "ResearcherID",
                principalTable: "Scholars",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Researches_Scholars_ResearcherID",
                table: "Researches");

            migrationBuilder.DropTable(
                name: "Scholars");

            migrationBuilder.CreateTable(
                name: "Researchers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researchers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Researchers_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Researchers_DepartmentID",
                table: "Researchers",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_Researchers_ResearcherID",
                table: "Researches",
                column: "ResearcherID",
                principalTable: "Researchers",
                principalColumn: "ID");
        }
    }
}
