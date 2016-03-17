namespace PapaCarloDBApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRowTitleTechCard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TechnologicalCards", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TechnologicalCards", "Title");
        }
    }
}
