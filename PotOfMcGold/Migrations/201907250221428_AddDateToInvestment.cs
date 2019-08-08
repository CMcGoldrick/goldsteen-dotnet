namespace PotOfMcGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToInvestment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Investments", "Date");
        }
    }
}
