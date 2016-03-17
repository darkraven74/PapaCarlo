namespace PapaCarloDBApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameColumnInSupplyProduct : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AcceptProducts", name: "ContractSupplyId", newName: "ContractAcceptId");
            RenameIndex(table: "dbo.AcceptProducts", name: "IX_ContractSupplyId", newName: "IX_ContractAcceptId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AcceptProducts", name: "IX_ContractAcceptId", newName: "IX_ContractSupplyId");
            RenameColumn(table: "dbo.AcceptProducts", name: "ContractAcceptId", newName: "ContractSupplyId");
        }
    }
}
