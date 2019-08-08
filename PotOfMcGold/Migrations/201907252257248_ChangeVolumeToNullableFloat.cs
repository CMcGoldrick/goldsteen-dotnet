namespace PotOfMcGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVolumeToNullableFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Investments", "Volume", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Investments", "Volume", c => c.Double());
        }
    }
}
