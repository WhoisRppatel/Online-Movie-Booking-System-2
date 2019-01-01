namespace ShowTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moviecontext5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.user_id);
            
            AddColumn("dbo.Tickets", "user_id", c => c.Int());
            CreateIndex("dbo.Tickets", "user_id");
            AddForeignKey("dbo.Tickets", "user_id", "dbo.Users", "user_id");
            DropColumn("dbo.Tickets", "u_nm");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "u_nm", c => c.String());
            DropForeignKey("dbo.Tickets", "user_id", "dbo.Users");
            DropIndex("dbo.Tickets", new[] { "user_id" });
            DropColumn("dbo.Tickets", "user_id");
            DropTable("dbo.Users");
        }
    }
}
