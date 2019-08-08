namespace PotOfMcGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeVolumeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Investments", "Volume", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Investments", "Volume", c => c.Double(nullable: false));
        }
    }
}
