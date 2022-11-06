using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.CustomMigration
{
    internal class CustomMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            AppUpdateTrigger.Up(migrationBuilder);
            InitialData.Up(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            InitialData.Down(migrationBuilder);
            AppUpdateTrigger.Down(migrationBuilder);
        }
    }
}