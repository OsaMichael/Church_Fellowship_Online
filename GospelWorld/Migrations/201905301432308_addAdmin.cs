namespace GospelWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAdmin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                        Description = c.String(),
                        DeptLocation = c.String(),
                        ImageUrl = c.String(),
                        DeptLeaderName = c.String(),
                        DeptMeeting = c.String(),
                        LeaderImageUrl = c.String(),
                        LeaderImageThumbnailUrl = c.String(),
                        ImageThumbnailUrl = c.String(),
                        Done = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkId = c.Int(nullable: false, identity: true),
                        DeptId = c.Int(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        OtherName = c.String(),
                        WorkerName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        ImageUrl = c.String(),
                        ImageThumbnailUrl = c.String(),
                    })
                .PrimaryKey(t => t.WorkId)
                .ForeignKey("dbo.Departments", t => t.DeptId)
                .Index(t => t.DeptId);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AtendId = c.Int(nullable: false, identity: true),
                        WorkId = c.Int(),
                        IsChecked = c.Boolean(nullable: false),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.AtendId)
                .ForeignKey("dbo.Workers", t => t.WorkId)
                .Index(t => t.WorkId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        ETId = c.Int(),
                        EventName = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        EventTheme = c.String(),
                        EventLocation = c.String(),
                        EventImageThumbnailUrl = c.String(),
                        EventImageUrl = c.String(),
                        EventDescription = c.String(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.EventTypes", t => t.ETId)
                .Index(t => t.ETId);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        ETId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ETId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MembId = c.Int(nullable: false, identity: true),
                        MemberName = c.String(),
                        DateOfBirth = c.DateTime(),
                        MemberImageUrl = c.String(),
                        MemeberImageThumbnailUrl = c.String(),
                        Profession = c.String(),
                        Married = c.Boolean(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        OtherName = c.String(),
                        SpouseName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.MembId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SermonCategories",
                c => new
                    {
                        CatId = c.Int(nullable: false, identity: true),
                        SermonName = c.String(),
                        SermonType = c.String(),
                        SermonCat = c.String(),
                        SermonDescription = c.String(),
                    })
                .PrimaryKey(t => t.CatId);
            
            CreateTable(
                "dbo.Sermons",
                c => new
                    {
                        SermId = c.Int(nullable: false, identity: true),
                        CatId = c.Int(),
                        PreacherName = c.String(),
                        SermonText = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        SermonTitle = c.String(),
                        SermonDate = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        ImageThumbnailUrl = c.String(),
                        IsLiked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SermId)
                .ForeignKey("dbo.SermonCategories", t => t.CatId)
                .Index(t => t.CatId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sermons", "CatId", "dbo.SermonCategories");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Events", "ETId", "dbo.EventTypes");
            DropForeignKey("dbo.Workers", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Attendances", "WorkId", "dbo.Workers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Sermons", new[] { "CatId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Events", new[] { "ETId" });
            DropIndex("dbo.Attendances", new[] { "WorkId" });
            DropIndex("dbo.Workers", new[] { "DeptId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Sermons");
            DropTable("dbo.SermonCategories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Members");
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
            DropTable("dbo.Attendances");
            DropTable("dbo.Workers");
            DropTable("dbo.Departments");
        }
    }
}
