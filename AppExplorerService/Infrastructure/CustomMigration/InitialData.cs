using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.CustomMigration
{
    internal class InitialData
    {
        public static void Up(MigrationBuilder migrationBuilder)
        {
            var popularLanguages = new[] { "Javascript", "Python", "Go", "Java", "Kotlin", "PHP", "C#", "Swift", "R", "Ruby", "C/C++", "TypeScript", "Scala" };
            var now = DateTime.UtcNow;
            foreach (var language in popularLanguages)
            {
                migrationBuilder.InsertData(
                    table: "Language",
                    columns: new[] { "Name", "CreatedDate", "UpdatedDate" },
                    values: new object[] { language, now, now }
                );
            }
        }

        public static void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Language");
        }
    }
}
