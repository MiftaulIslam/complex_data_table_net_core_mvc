using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class initilize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionalOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionalStore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DscCtgA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DscCtgAarray = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DscCtgB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DscCtgBarray = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UscCtgB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UscCtgBarray = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tests");
        }
    }
}
