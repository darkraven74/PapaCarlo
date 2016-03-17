namespace PapaCarloDBApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnTypeToProductTechCard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductTechCards", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductTechCards", "Type");
        }
    }
}
