namespace ShowTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moviecontext3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Show_time", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Show_time", c => c.DateTime(nullable: false));
        }
    }
}
