namespace Calendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDescriptionColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Description", c => c.String());
            DropColumn("dbo.Events", "Descriiption");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Descriiption", c => c.String());
            DropColumn("dbo.Events", "Description");
        }
    }
}
