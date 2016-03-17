namespace PapaCarloDBApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcceptProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        ContractSupplyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractAccepts", t => t.ContractSupplyId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.ContractSupplyId);
            
            CreateTable(
                "dbo.ContractAccepts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ContractSupplyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractSupplies", t => t.ContractSupplyId)
                .Index(t => t.ContractSupplyId);
            
            CreateTable(
                "dbo.ContractSupplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ContractorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
                .Index(t => t.ContractorId);
            
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SupplyProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        ContractSupplyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractSupplies", t => t.ContractSupplyId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.ContractSupplyId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        VendorCode = c.Int(nullable: false),
                        Description = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractMoves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        StoreCellFromId = c.Int(nullable: false),
                        StoreCellToId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.StoreCells", t => t.StoreCellFromId)
                .ForeignKey("dbo.StoreCells", t => t.StoreCellToId)
                .Index(t => t.StoreCellFromId)
                .Index(t => t.StoreCellToId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.StoreCells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorehouseId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Storehouses", t => t.StorehouseId)
                .Index(t => t.StorehouseId);
            
            CreateTable(
                "dbo.Storehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractShipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        StoreCellFromId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.StoreCells", t => t.StoreCellFromId)
                .Index(t => t.StoreCellFromId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductTechCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        TechCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.TechnologicalCards", t => t.TechCardId)
                .Index(t => t.ProductId)
                .Index(t => t.TechCardId);
            
            CreateTable(
                "dbo.TechnologicalCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReportBalances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        StoreCellId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.StoreCells", t => t.StoreCellId)
                .Index(t => t.StoreCellId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ReportPredicts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        StorehouseId = c.Int(nullable: false),
                        ContractSupplyId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Predict = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractSupplies", t => t.ContractSupplyId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Storehouses", t => t.StorehouseId)
                .Index(t => t.StorehouseId)
                .Index(t => t.ContractSupplyId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ContractTechOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TechCardId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TechnologicalCards", t => t.TechCardId)
                .Index(t => t.TechCardId);
            
            CreateTable(
                "dbo.EmployeeRights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Patronymic = c.String(),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeRights", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.ContractTechOperations", "TechCardId", "dbo.TechnologicalCards");
            DropForeignKey("dbo.AcceptProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.AcceptProducts", "ContractSupplyId", "dbo.ContractAccepts");
            DropForeignKey("dbo.ContractAccepts", "ContractSupplyId", "dbo.ContractSupplies");
            DropForeignKey("dbo.SupplyProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ReportPredicts", "StorehouseId", "dbo.Storehouses");
            DropForeignKey("dbo.ReportPredicts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ReportPredicts", "ContractSupplyId", "dbo.ContractSupplies");
            DropForeignKey("dbo.ReportBalances", "StoreCellId", "dbo.StoreCells");
            DropForeignKey("dbo.ReportBalances", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductTechCards", "TechCardId", "dbo.TechnologicalCards");
            DropForeignKey("dbo.ProductTechCards", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ContractShipments", "StoreCellFromId", "dbo.StoreCells");
            DropForeignKey("dbo.ContractShipments", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ContractMoves", "StoreCellToId", "dbo.StoreCells");
            DropForeignKey("dbo.ContractMoves", "StoreCellFromId", "dbo.StoreCells");
            DropForeignKey("dbo.StoreCells", "StorehouseId", "dbo.Storehouses");
            DropForeignKey("dbo.ContractMoves", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SupplyProducts", "ContractSupplyId", "dbo.ContractSupplies");
            DropForeignKey("dbo.ContractSupplies", "ContractorId", "dbo.Contractors");
            DropIndex("dbo.Employees", new[] { "PositionId" });
            DropIndex("dbo.EmployeeRights", new[] { "EmployeeId" });
            DropIndex("dbo.ContractTechOperations", new[] { "TechCardId" });
            DropIndex("dbo.ReportPredicts", new[] { "ProductId" });
            DropIndex("dbo.ReportPredicts", new[] { "ContractSupplyId" });
            DropIndex("dbo.ReportPredicts", new[] { "StorehouseId" });
            DropIndex("dbo.ReportBalances", new[] { "ProductId" });
            DropIndex("dbo.ReportBalances", new[] { "StoreCellId" });
            DropIndex("dbo.ProductTechCards", new[] { "TechCardId" });
            DropIndex("dbo.ProductTechCards", new[] { "ProductId" });
            DropIndex("dbo.ContractShipments", new[] { "ProductId" });
            DropIndex("dbo.ContractShipments", new[] { "StoreCellFromId" });
            DropIndex("dbo.StoreCells", new[] { "StorehouseId" });
            DropIndex("dbo.ContractMoves", new[] { "ProductId" });
            DropIndex("dbo.ContractMoves", new[] { "StoreCellToId" });
            DropIndex("dbo.ContractMoves", new[] { "StoreCellFromId" });
            DropIndex("dbo.SupplyProducts", new[] { "ContractSupplyId" });
            DropIndex("dbo.SupplyProducts", new[] { "ProductId" });
            DropIndex("dbo.ContractSupplies", new[] { "ContractorId" });
            DropIndex("dbo.ContractAccepts", new[] { "ContractSupplyId" });
            DropIndex("dbo.AcceptProducts", new[] { "ContractSupplyId" });
            DropIndex("dbo.AcceptProducts", new[] { "ProductId" });
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeRights");
            DropTable("dbo.ContractTechOperations");
            DropTable("dbo.ReportPredicts");
            DropTable("dbo.ReportBalances");
            DropTable("dbo.TechnologicalCards");
            DropTable("dbo.ProductTechCards");
            DropTable("dbo.ContractShipments");
            DropTable("dbo.Storehouses");
            DropTable("dbo.StoreCells");
            DropTable("dbo.ContractMoves");
            DropTable("dbo.Products");
            DropTable("dbo.SupplyProducts");
            DropTable("dbo.Contractors");
            DropTable("dbo.ContractSupplies");
            DropTable("dbo.ContractAccepts");
            DropTable("dbo.AcceptProducts");
        }
    }
}
