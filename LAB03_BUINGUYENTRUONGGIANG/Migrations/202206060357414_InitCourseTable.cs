namespace LAB03_BUINGUYENTRUONGGIANG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(nullable: false, maxLength: 255),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Courses",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    LectureId = c.String(maxLength: 128, nullable: false),
                    Place = c.String(nullable: false, maxLength: 255),
                    DateTime = c.DateTime(nullable: false),
                    CategoryId = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.LectureId)
                .Index(t => t.CategoryId);
        }
        
        public override void Down()
        {
        }
    }
}
