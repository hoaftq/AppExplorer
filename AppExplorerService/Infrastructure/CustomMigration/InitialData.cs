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
                values: new object[,]
                {
                    { "Javascript" },
                    { "Python" },
                    { "Go" },
                    { "Java" },
                    { "Kotlin" },
                    { "PHP" },
                    { "C#" },
                    { "Swift" },
                    { "R" },
                    { "Ruby" },
                    { "C/C++" },
                    { "TypeScript" },
                    { "Scala" }
                });
        }

        public static void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Language");
        }
    }
}
