namespace PotOfMcGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCurrentValueToCrypto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Portfolios", "CurrentValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Portfolios", "CurrentValue");
        }
    }
}
