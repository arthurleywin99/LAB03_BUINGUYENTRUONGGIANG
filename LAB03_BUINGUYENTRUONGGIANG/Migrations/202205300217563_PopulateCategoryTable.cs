namespace LAB03_BUINGUYENTRUONGGIANG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Development')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Business')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'Marketing')");
        }
        
        public override void Down()
        {
        }
    }
}
