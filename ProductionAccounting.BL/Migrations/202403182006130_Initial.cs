namespace ProductionAccounting.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Weight = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        Gender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id)
                .Index(t => t.Gender_Id);
            
            CreateTable(
                "dbo.Productivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountPerHour = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        Finish = c.DateTime(nullable: false),
                        ProductivityID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productivities", t => t.ProductivityID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.ProductivityID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Tares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Volume = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        NumbOfProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Works", "UserID", "dbo.Users");
            DropForeignKey("dbo.Works", "ProductivityID", "dbo.Productivities");
            DropForeignKey("dbo.Productions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Works", new[] { "UserID" });
            DropIndex("dbo.Works", new[] { "ProductivityID" });
            DropIndex("dbo.Users", new[] { "Gender_Id" });
            DropIndex("dbo.Productions", new[] { "UserId" });
            DropTable("dbo.Tares");
            DropTable("dbo.Works");
            DropTable("dbo.Productivities");
            DropTable("dbo.Users");
            DropTable("dbo.Productions");
            DropTable("dbo.Genders");
        }
    }
}
