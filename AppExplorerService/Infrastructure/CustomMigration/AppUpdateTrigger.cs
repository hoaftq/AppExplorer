using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.CustomMigration
{
    class AppUpdateTrigger
    {
        public static void Up(MigrationBuilder migrationBuilder)
        {
            const string UpdatedDateTriggerStr = @"
            CREATE TRIGGER [dbo].[AppUpdate] ON [dbo].[App]
                AFTER UPDATE
            AS
            BEGIN
                SET NOCOUNT ON;
                    
                IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                DECLARE @Id INT

                SELECT @Id = INSERTED.Id
                FROM INSERTED

                UPDATE dbo.Apps
                SET UpdatedDate = GETDATE()
                WHERE Id = @Id
            END";
            migrationBuilder.Sql(UpdatedDateTriggerStr);
        }

        public static void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER [dbo].[AppUpdate]");
        }
    }
}