namespace CodeFirstFromExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryColumnToCoursesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Category_Id", c => c.Int());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            CreateIndex("dbo.Courses", "Category_Id");
            AddForeignKey("dbo.Courses", "Category_Id", "dbo.Categories", "Id");
            Sql("UPDATE Courses SET Category_Id = 1");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            AlterColumn("dbo.Categories", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Courses", "Category_Id");
        }
    }
}
