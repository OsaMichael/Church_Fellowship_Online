namespace GospelWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "ETId", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "ETId" });
            RenameColumn(table: "dbo.Events", name: "ETId", newName: "EventType_ETId");
            AddColumn("dbo.Events", "EventType", c => c.String());
            AlterColumn("dbo.Events", "EventType_ETId", c => c.Int());
            CreateIndex("dbo.Events", "EventType_ETId");
            AddForeignKey("dbo.Events", "EventType_ETId", "dbo.EventTypes", "ETId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventType_ETId", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "EventType_ETId" });
            AlterColumn("dbo.Events", "EventType_ETId", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "EventType");
            RenameColumn(table: "dbo.Events", name: "EventType_ETId", newName: "ETId");
            CreateIndex("dbo.Events", "ETId");
            AddForeignKey("dbo.Events", "ETId", "dbo.EventTypes", "ETId", cascadeDelete: true);
        }
    }
}
