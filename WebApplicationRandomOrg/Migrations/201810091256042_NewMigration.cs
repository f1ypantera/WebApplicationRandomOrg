namespace WebApplicationRandomOrg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "AccountId", "dbo.UserAccounts");
            DropForeignKey("dbo.Results", "RequestTypeID", "dbo.RequestTypes");
            DropIndex("dbo.Results", new[] { "RequestTypeID" });
            DropIndex("dbo.Results", new[] { "AccountId" });
            DropTable("dbo.Results");
        }
    }
}
