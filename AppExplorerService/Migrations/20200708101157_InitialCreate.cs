using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppExplorerService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "App",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 1000, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Level = table.Column<int>(nullable: false),
                    DeployedUrl = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    SourceUrl = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    LibUrl = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    DownloadUrl = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    ArticleUrl = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppLanguage",
                columns: table => new
                {
                    AppId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLanguage", x => new { x.AppId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_AppLanguage_App_AppId",
                        column: x => x.AppId,
                        principalTable: "App",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Java" },
                    { 3, "Javascript" },
                    { 4, "Typescript" },
                    { 5, "HTML" },
                    { 6, "CSS" },
                    { 7, "SCSS" },
                    { 8, "Angular" },
                    { 9, "JQuery" },
                    { 10, "Bootstrap" },
                    { 11, "Asp.Net Core API" },
                    { 12, "Asp.Net Core MVC" },
                    { 13, "Asp.Net Core Razor" },
                    { 14, "Entity Framework Core" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Password" },
                values: new object[] { "admin", "password" });

            migrationBuilder.CreateIndex(
                name: "IX_App_CategoryId",
                table: "App",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Name",
                table: "App",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppLanguage_LanguageId",
                table: "AppLanguage",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppLanguage");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "App");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
