namespace ShowTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moviecontext7 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tickets");
            AddColumn("dbo.Tickets", "T_NO", c => c.String());
            AlterColumn("dbo.Tickets", "Ticket_id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tickets", "Ticket_id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Tickets", "Ticket_id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Tickets", "T_NO");
            AddPrimaryKey("dbo.Tickets", "Ticket_id");
        }
    }
}
