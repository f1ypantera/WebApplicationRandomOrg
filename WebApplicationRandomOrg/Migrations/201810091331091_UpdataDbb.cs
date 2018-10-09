namespace WebApplicationRandomOrg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataDbb : DbMigration
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
            DropForeignKey("dbo.GlobalStatisctics", "RequestTypeID", "dbo.RequestTypes");
            DropIndex("dbo.StatisticsByUsers", new[] { "RequestTypeID" });
            DropIndex("dbo.StatisticsByUsers", new[] { "AccountId" });
            DropIndex("dbo.GlobalStatisctics", new[] { "RequestTypeID" });
            DropTable("dbo.StatisticsByUsers");
            DropTable("dbo.GlobalStatisctics");
        }
    }
}
