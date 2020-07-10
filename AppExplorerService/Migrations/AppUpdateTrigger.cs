using Microsoft.EntityFrameworkCore.Migrations;

// No need to drop the trigger since droping the table also drops its triggers
class AppCreatedDateTrigger
{
    private const string UpdatedDateTriggerStr = @"
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

    public static void AddTrigger(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(UpdatedDateTriggerStr);
    }
}