namespace Insurances.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Identification = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Description = c.String(maxLength: 500),
                        CoveringTypeId = c.Int(nullable: false),
                        CoveringPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PolicyStart = c.DateTime(nullable: false),
                        Period = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientId = c.Int(nullable: false),
                        Risk = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoveringTypes", t => t.CoveringTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.CoveringTypeId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.CoveringTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policies", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Policies", "CoveringTypeId", "dbo.CoveringTypes");
            DropIndex("dbo.Policies", new[] { "ClientId" });
            DropIndex("dbo.Policies", new[] { "CoveringTypeId" });
            DropTable("dbo.CoveringTypes");
            DropTable("dbo.Policies");
            DropTable("dbo.Clients");
        }
    }
}
