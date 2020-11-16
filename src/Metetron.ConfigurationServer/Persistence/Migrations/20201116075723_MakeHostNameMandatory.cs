using Microsoft.EntityFrameworkCore.Migrations;

namespace Metetron.ConfigurationServer.Persistence.Migrations
{
    public partial class MakeHostNameMandatory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppConfiguration_App_AppId",
                table: "AppConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_AppSetting_AppConfiguration_AppConfigurationId",
                table: "AppSetting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppSetting",
                table: "AppSetting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppConfiguration",
                table: "AppConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_App",
                table: "App");

            migrationBuilder.RenameTable(
                name: "AppSetting",
                newName: "AppSettings");

            migrationBuilder.RenameTable(
                name: "AppConfiguration",
                newName: "AppConfigurations");

            migrationBuilder.RenameTable(
                name: "App",
                newName: "Apps");

            migrationBuilder.RenameIndex(
                name: "IX_AppSetting_AppConfigurationId",
                table: "AppSettings",
                newName: "IX_AppSettings_AppConfigurationId");

            migrationBuilder.RenameIndex(
                name: "IX_AppConfiguration_AppId",
                table: "AppConfigurations",
                newName: "IX_AppConfigurations_AppId");

            migrationBuilder.RenameIndex(
                name: "IX_App_AppName",
                table: "Apps",
                newName: "IX_Apps_AppName");

            migrationBuilder.AlterColumn<string>(
                name: "HostName",
                table: "AppConfigurations",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppSettings",
                table: "AppSettings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppConfigurations",
                table: "AppConfigurations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apps",
                table: "Apps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppConfigurations_Apps_AppId",
                table: "AppConfigurations",
                column: "AppId",
                principalTable: "Apps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppSettings_AppConfigurations_AppConfigurationId",
                table: "AppSettings",
                column: "AppConfigurationId",
                principalTable: "AppConfigurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppConfigurations_Apps_AppId",
                table: "AppConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_AppSettings_AppConfigurations_AppConfigurationId",
                table: "AppSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppSettings",
                table: "AppSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apps",
                table: "Apps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppConfigurations",
                table: "AppConfigurations");

            migrationBuilder.RenameTable(
                name: "AppSettings",
                newName: "AppSetting");

            migrationBuilder.RenameTable(
                name: "Apps",
                newName: "App");

            migrationBuilder.RenameTable(
                name: "AppConfigurations",
                newName: "AppConfiguration");

            migrationBuilder.RenameIndex(
                name: "IX_AppSettings_AppConfigurationId",
                table: "AppSetting",
                newName: "IX_AppSetting_AppConfigurationId");

            migrationBuilder.RenameIndex(
                name: "IX_Apps_AppName",
                table: "App",
                newName: "IX_App_AppName");

            migrationBuilder.RenameIndex(
                name: "IX_AppConfigurations_AppId",
                table: "AppConfiguration",
                newName: "IX_AppConfiguration_AppId");

            migrationBuilder.AlterColumn<string>(
                name: "HostName",
                table: "AppConfiguration",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppSetting",
                table: "AppSetting",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_App",
                table: "App",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppConfiguration",
                table: "AppConfiguration",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppConfiguration_App_AppId",
                table: "AppConfiguration",
                column: "AppId",
                principalTable: "App",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppSetting_AppConfiguration_AppConfigurationId",
                table: "AppSetting",
                column: "AppConfigurationId",
                principalTable: "AppConfiguration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
