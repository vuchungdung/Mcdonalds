using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class version_100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    UserName = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "NVARCHAR(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
