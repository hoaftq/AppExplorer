using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.CustomMigration
{
    internal class InitialData
    {
        public static void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Name" },
                values: new List<string>
                {
                    "Java",
                    "Spring",
                    "Spring Boot",
                    "C#",
                    "Javascript",
                    "Typescript",
                    "HTML",
                    "CSS",
                    "SCSS",
                    "Angular",
                    "Reactjs",
                    "JQuery",
                    "Bootstrap",
                    "Asp.Net Core API",
                    "Asp.Net Core MVC",
                    "Asp.Net Core Razor",
                    "Entity Framework Core"
                }.OrderBy(l => l).ToArray());
        }

        public static void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Language");
        }
    }
}
