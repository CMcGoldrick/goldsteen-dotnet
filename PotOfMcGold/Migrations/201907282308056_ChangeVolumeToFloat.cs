namespace PotOfMcGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVolumeToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Portfolios", "Volume", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Portfolios", "Volume", c => c.Int(nullable: false));
        }
    }
}
