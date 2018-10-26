namespace WebApplicationRandomOrg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GlobalStatisctics",
                c => new
                    {
                        GlabalStatiscticId = c.Int(nullable: false, identity: true),
                        RequestTypeID = c.Int(nullable: false),
                        TotalByType = c.Int(nullable: false),
                        OverallTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GlabalStatiscticId)
                .ForeignKey("dbo.RequestTypes", t => t.RequestTypeID, cascadeDelete: true)
                .Index(t => t.RequestTypeID);
            
            CreateTable(
                "dbo.RequestTypes",
                c => new
                    {
                        RequestTypeID = c.Int(nullable: false, identity: true),
                        NameType = c.String(),
                    })
                .PrimaryKey(t => t.RequestTypeID);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.RandomDates",
                c => new
                    {
                        KeyId = c.Int(nullable: false, identity: true),
                        minDate = c.Int(nullable: false),
                        maxDate = c.Int(nullable: false),
                        minMonth = c.Int(nullable: false),
                        maxMonth = c.Int(nullable: false),
                        minYear = c.Int(nullable: false),
                        maxYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeyId);
            
            CreateTable(
                "dbo.RandomPasswords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        includeLowerCase = c.Boolean(nullable: false),
                        includeUpperCase = c.Boolean(nullable: false),
                        includeNumber = c.Boolean(nullable: false),
                        includeSpecial = c.Boolean(nullable: false),
                        lengthofPassword = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        PasswordConfirm = c.String(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        RequestTypeID = c.Int(nullable: false),
                        OutPutResult = c.String(),
                    })
                .PrimaryKey(t => t.ResultId)
                .ForeignKey("dbo.RequestTypes", t => t.RequestTypeID, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.RequestTypeID);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        PasswordConfirm = c.String(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Year = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.StatisticsByUsers",
                c => new
                    {
                        StatisticsByUserID = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        RequestTypeID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatisticsByUserID)
                .ForeignKey("dbo.RequestTypes", t => t.RequestTypeID, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.RequestTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatisticsByUsers", "AccountId", "dbo.UserAccounts");
            DropForeignKey("dbo.StatisticsByUsers", "RequestTypeID", "dbo.RequestTypes");
            DropForeignKey("dbo.Results", "AccountId", "dbo.UserAccounts");
            DropForeignKey("dbo.UserAccounts", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Results", "RequestTypeID", "dbo.RequestTypes");
            DropForeignKey("dbo.GlobalStatisctics", "RequestTypeID", "dbo.RequestTypes");
            DropIndex("dbo.StatisticsByUsers", new[] { "RequestTypeID" });
            DropIndex("dbo.StatisticsByUsers", new[] { "AccountId" });
            DropIndex("dbo.UserAccounts", new[] { "RoleID" });
            DropIndex("dbo.Results", new[] { "RequestTypeID" });
            DropIndex("dbo.Results", new[] { "AccountId" });
            DropIndex("dbo.GlobalStatisctics", new[] { "RequestTypeID" });
            DropTable("dbo.StatisticsByUsers");
            DropTable("dbo.Roles");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Results");
            DropTable("dbo.Registrations");
            DropTable("dbo.RandomPasswords");
            DropTable("dbo.RandomDates");
            DropTable("dbo.Logins");
            DropTable("dbo.RequestTypes");
            DropTable("dbo.GlobalStatisctics");
        }
    }
}
