namespace PotOfMcGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExchangeColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "Exchange", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Investments", "Exchange");
        }
    }
}
