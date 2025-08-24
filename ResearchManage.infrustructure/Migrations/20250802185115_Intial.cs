using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchManage.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Researchers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Supervisors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Supervisors_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Researches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Abestract = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearcherID = table.Column<int>(type: "int", nullable: false),
                    SupervisorID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Researches_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Researches_Researchers_ResearcherID",
                        column: x => x.ResearcherID,
                        principalTable: "Researchers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Researches_Supervisors_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "Supervisors",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Researchers_DepartmentID",
                table: "Researchers",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_DepartmentID",
                table: "Researches",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_ResearcherID",
                table: "Researches",
                column: "ResearcherID");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_SupervisorID",
                table: "Researches",
                column: "SupervisorID");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisors_DepartmentID",
                table: "Supervisors",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Researches");

            migrationBuilder.DropTable(
                name: "Researchers");

            migrationBuilder.DropTable(
                name: "Supervisors");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
