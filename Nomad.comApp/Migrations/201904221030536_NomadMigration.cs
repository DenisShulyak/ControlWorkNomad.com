namespace Nomad.comApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomadMigration : DbMigration
    {
       
        public override void Up()
        {
            CreateTable(
                "dbo.Magazines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberMagazine = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.Long(nullable: false),
                        Magazine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Magazines", t => t.Magazine_Id)
                .Index(t => t.Magazine_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.Long(nullable: false),
                        Address = c.String(),
                        PublisherId = c.Int(nullable: false),
                        SubscriptionId = c.Int(),
                        StateSubscription = c.Boolean(nullable: false),
                        StateDeliveryLastMagazine = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .ForeignKey("dbo.Subscriptions", t => t.SubscriptionId)
                .Index(t => t.PublisherId)
                .Index(t => t.SubscriptionId);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeSubscriptionId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        MagazineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Magazines", t => t.MagazineId, cascadeDelete: true)
                .ForeignKey("dbo.TimeSubscriptions", t => t.TimeSubscriptionId, cascadeDelete: true)
                .Index(t => t.TimeSubscriptionId)
                .Index(t => t.MagazineId);
            
            CreateTable(
                "dbo.TimeSubscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountMonths = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Publishers", "Magazine_Id", "dbo.Magazines");
            DropForeignKey("dbo.Users", "SubscriptionId", "dbo.Subscriptions");
            DropForeignKey("dbo.Subscriptions", "TimeSubscriptionId", "dbo.TimeSubscriptions");
            DropForeignKey("dbo.Subscriptions", "MagazineId", "dbo.Magazines");
            DropForeignKey("dbo.Users", "PublisherId", "dbo.Publishers");
            DropIndex("dbo.Subscriptions", new[] { "MagazineId" });
            DropIndex("dbo.Subscriptions", new[] { "TimeSubscriptionId" });
            DropIndex("dbo.Users", new[] { "SubscriptionId" });
            DropIndex("dbo.Users", new[] { "PublisherId" });
            DropIndex("dbo.Publishers", new[] { "Magazine_Id" });
            DropTable("dbo.TimeSubscriptions");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.Users");
            DropTable("dbo.Publishers");
            DropTable("dbo.Magazines");
        }
    }
}
