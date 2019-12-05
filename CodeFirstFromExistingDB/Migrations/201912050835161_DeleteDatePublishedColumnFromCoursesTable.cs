namespace CodeFirstFromExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDatePublishedColumnFromCoursesTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "DatetimePublished");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "DatetimePublished", c => c.DateTime());
        }
    }
}
