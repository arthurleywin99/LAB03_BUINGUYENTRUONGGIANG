namespace LAB03_BUINGUYENTRUONGGIANG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClone : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
