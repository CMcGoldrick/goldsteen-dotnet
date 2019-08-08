namespace PotOfMcGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotesToInvestment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Investments", "Notes");
        }
    }
}
