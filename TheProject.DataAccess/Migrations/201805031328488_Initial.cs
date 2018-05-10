namespace TheProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ZipCode = c.String(nullable: false, maxLength: 8),
                        StreetName = c.String(nullable: false, maxLength: 20),
                        StreetNum = c.String(nullable: false, maxLength: 20),
                        Extra = c.String(nullable: false, maxLength: 50),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.CarsParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                         Price = c.Int(nullable: false),
                         About=c.String(nullable: false),
                        inStoke = c.String(nullable: false),
                         Order = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarsParts", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "CityId", "dbo.Cities");
            DropIndex("dbo.CarsParts", new[] { "LocationId" });
            DropIndex("dbo.CarsParts", new[] { "Name" });
            DropIndex("dbo.Locations", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "Name" });
            DropTable("dbo.CarsParts");
            DropTable("dbo.Locations");
            DropTable("dbo.Cities");
        }
    }
}
