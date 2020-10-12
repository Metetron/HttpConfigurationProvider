using Microsoft.EntityFrameworkCore.Migrations;

namespace Metetron.ConfigurationServer.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_AppName",
                table: "App",
                column: "AppName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App");
        }
    }
}
