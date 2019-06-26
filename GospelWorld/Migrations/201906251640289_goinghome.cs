namespace GospelWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class goinghome : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "ETId", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "ETId" });
            AlterColumn("dbo.Events", "ETId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "ETId");
            AddForeignKey("dbo.Events", "ETId", "dbo.EventTypes", "ETId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "ETId", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "ETId" });
            AlterColumn("dbo.Events", "ETId", c => c.Int());
            CreateIndex("dbo.Events", "ETId");
            AddForeignKey("dbo.Events", "ETId", "dbo.EventTypes", "ETId");
        }
    }
}
