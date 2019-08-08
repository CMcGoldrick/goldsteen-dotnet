namespace PotOfMcGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAmountVolumeDatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Investments", "Amount", c => c.Single(nullable: false));
            AlterColumn("dbo.Investments", "Volume", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Investments", "Volume", c => c.Int(nullable: false));
            AlterColumn("dbo.Investments", "Amount", c => c.Int(nullable: false));
        }
    }
}
