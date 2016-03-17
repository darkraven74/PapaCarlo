namespace PapaCarloDBApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTwoColumnsInConractSupply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContractSupplies", "wasReceived", c => c.Boolean(nullable: false));
            AddColumn("dbo.ContractSupplies", "numberOfSupply", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContractSupplies", "numberOfSupply");
            DropColumn("dbo.ContractSupplies", "wasReceived");
        }
    }
}
