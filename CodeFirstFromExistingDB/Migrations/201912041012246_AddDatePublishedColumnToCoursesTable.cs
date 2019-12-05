namespace CodeFirstFromExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatePublishedColumnToCoursesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "DatetimePublished", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "DatetimePublished");
        }
    }
}
