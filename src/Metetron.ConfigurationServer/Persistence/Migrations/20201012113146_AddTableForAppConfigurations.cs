using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metetron.ConfigurationServer.Persistence.Migrations
{
    public partial class AddTableForAppConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppId = table.Column<int>(nullable: false),
                    HostName = table.Column<string>(nullable: true),
                    Environment = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EditedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppConfiguration_App_AppId",
                        column: x => x.AppId,
                        principalTable: "App",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppConfiguration_AppId",
                table: "AppConfiguration",
                column: "AppId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfiguration");
        }
    }
}
