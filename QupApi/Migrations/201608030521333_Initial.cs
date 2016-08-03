namespace QupApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeatureModels",
                c => new
                    {
                        FeatureId = c.Int(nullable: false, identity: true),
                        FeatureDescription = c.String(),
                    })
                .PrimaryKey(t => t.FeatureId);
            
            CreateTable(
                "dbo.FileResults",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreatedTimestamp = c.DateTime(nullable: false),
                        UpdatedTimestamp = c.DateTime(nullable: false),
                        DownloadLink = c.String(),
                        FeatureModel_FeatureId = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.FeatureModels", t => t.FeatureModel_FeatureId)
                .Index(t => t.FeatureModel_FeatureId);
            
            CreateTable(
                "dbo.SprintModels",
                c => new
                    {
                        SprintId = c.Int(nullable: false, identity: true),
                        SprintName = c.String(),
                        SprintStartDate = c.DateTime(nullable: false),
                        SprintEndDate = c.DateTime(nullable: false),
                        ProjectModel_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.SprintId)
                .ForeignKey("dbo.ProjectModels", t => t.ProjectModel_ProjectId)
                .Index(t => t.ProjectModel_ProjectId);
            
            CreateTable(
                "dbo.FeatureStoryModels",
                c => new
                    {
                        FeatureStoryId = c.Int(nullable: false, identity: true),
                        FeatureStory = c.String(),
                        FeatureModel_FeatureId = c.Int(),
                    })
                .PrimaryKey(t => t.FeatureStoryId)
                .ForeignKey("dbo.FeatureModels", t => t.FeatureModel_FeatureId)
                .Index(t => t.FeatureModel_FeatureId);
            
            CreateTable(
                "dbo.UserStoryModels",
                c => new
                    {
                        UserStoryId = c.Int(nullable: false, identity: true),
                        UserStory = c.String(),
                        FeatureStoryModel_FeatureStoryId = c.Int(),
                    })
                .PrimaryKey(t => t.UserStoryId)
                .ForeignKey("dbo.FeatureStoryModels", t => t.FeatureStoryModel_FeatureStoryId)
                .Index(t => t.FeatureStoryModel_FeatureStoryId);
            
            CreateTable(
                "dbo.StatusModels",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        UserStoryModel_UserStoryId = c.Int(),
                    })
                .PrimaryKey(t => t.StatusId)
                .ForeignKey("dbo.UserStoryModels", t => t.UserStoryModel_UserStoryId)
                .Index(t => t.UserStoryModel_UserStoryId);
            
            CreateTable(
                "dbo.UserInfoViewModels",
                c => new
                    {
                        UserInfoId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        HasRegistered = c.Boolean(nullable: false),
                        LoginProvider = c.String(),
                        FeatureModel_FeatureId = c.Int(),
                    })
                .PrimaryKey(t => t.UserInfoId)
                .ForeignKey("dbo.FeatureModels", t => t.FeatureModel_FeatureId)
                .Index(t => t.FeatureModel_FeatureId);
            
            CreateTable(
                "dbo.ProjectModels",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProjectStartDate = c.DateTime(nullable: false),
                        ProjectEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
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
            
            CreateTable(
                "dbo.SprintModelFeatureModels",
                c => new
                    {
                        SprintModel_SprintId = c.Int(nullable: false),
                        FeatureModel_FeatureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SprintModel_SprintId, t.FeatureModel_FeatureId })
                .ForeignKey("dbo.SprintModels", t => t.SprintModel_SprintId, cascadeDelete: true)
                .ForeignKey("dbo.FeatureModels", t => t.FeatureModel_FeatureId, cascadeDelete: true)
                .Index(t => t.SprintModel_SprintId)
                .Index(t => t.FeatureModel_FeatureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SprintModels", "ProjectModel_ProjectId", "dbo.ProjectModels");
            DropForeignKey("dbo.UserInfoViewModels", "FeatureModel_FeatureId", "dbo.FeatureModels");
            DropForeignKey("dbo.FeatureStoryModels", "FeatureModel_FeatureId", "dbo.FeatureModels");
            DropForeignKey("dbo.UserStoryModels", "FeatureStoryModel_FeatureStoryId", "dbo.FeatureStoryModels");
            DropForeignKey("dbo.StatusModels", "UserStoryModel_UserStoryId", "dbo.UserStoryModels");
            DropForeignKey("dbo.SprintModelFeatureModels", "FeatureModel_FeatureId", "dbo.FeatureModels");
            DropForeignKey("dbo.SprintModelFeatureModels", "SprintModel_SprintId", "dbo.SprintModels");
            DropForeignKey("dbo.FileResults", "FeatureModel_FeatureId", "dbo.FeatureModels");
            DropIndex("dbo.SprintModelFeatureModels", new[] { "FeatureModel_FeatureId" });
            DropIndex("dbo.SprintModelFeatureModels", new[] { "SprintModel_SprintId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserInfoViewModels", new[] { "FeatureModel_FeatureId" });
            DropIndex("dbo.StatusModels", new[] { "UserStoryModel_UserStoryId" });
            DropIndex("dbo.UserStoryModels", new[] { "FeatureStoryModel_FeatureStoryId" });
            DropIndex("dbo.FeatureStoryModels", new[] { "FeatureModel_FeatureId" });
            DropIndex("dbo.SprintModels", new[] { "ProjectModel_ProjectId" });
            DropIndex("dbo.FileResults", new[] { "FeatureModel_FeatureId" });
            DropTable("dbo.SprintModelFeatureModels");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProjectModels");
            DropTable("dbo.UserInfoViewModels");
            DropTable("dbo.StatusModels");
            DropTable("dbo.UserStoryModels");
            DropTable("dbo.FeatureStoryModels");
            DropTable("dbo.SprintModels");
            DropTable("dbo.FileResults");
            DropTable("dbo.FeatureModels");
        }
    }
}
