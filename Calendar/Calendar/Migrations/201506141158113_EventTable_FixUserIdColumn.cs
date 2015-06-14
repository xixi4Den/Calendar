namespace Calendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventTable_FixUserIdColumn : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.Events", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Events", name: "ApplicationUserId", newName: "ApplicationUser_Id");
        }
    }
}
