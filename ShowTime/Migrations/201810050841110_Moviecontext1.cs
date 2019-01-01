namespace ShowTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moviecontext1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seats", "ticket_Ticket_id", "dbo.Tickets");
            DropIndex("dbo.Seats", new[] { "ticket_Ticket_id" });
            RenameColumn(table: "dbo.Movies", name: "Theatre_Theatre_id", newName: "Show_Theatre_id");
            RenameIndex(table: "dbo.Movies", name: "IX_Theatre_Theatre_id", newName: "IX_Show_Theatre_id");
            AddColumn("dbo.Seats", "Movie_Movie_id", c => c.Int());
            AddColumn("dbo.Tickets", "Seat_Seat_id", c => c.Int());
            CreateIndex("dbo.Seats", "Movie_Movie_id");
            CreateIndex("dbo.Tickets", "Seat_Seat_id");
            AddForeignKey("dbo.Seats", "Movie_Movie_id", "dbo.Movies", "Movie_id");
            AddForeignKey("dbo.Tickets", "Seat_Seat_id", "dbo.Seats", "Seat_id");
            DropColumn("dbo.Seats", "ticket_Ticket_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seats", "ticket_Ticket_id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Tickets", "Seat_Seat_id", "dbo.Seats");
            DropForeignKey("dbo.Seats", "Movie_Movie_id", "dbo.Movies");
            DropIndex("dbo.Tickets", new[] { "Seat_Seat_id" });
            DropIndex("dbo.Seats", new[] { "Movie_Movie_id" });
            DropColumn("dbo.Tickets", "Seat_Seat_id");
            DropColumn("dbo.Seats", "Movie_Movie_id");
            RenameIndex(table: "dbo.Movies", name: "IX_Show_Theatre_id", newName: "IX_Theatre_Theatre_id");
            RenameColumn(table: "dbo.Movies", name: "Show_Theatre_id", newName: "Theatre_Theatre_id");
            CreateIndex("dbo.Seats", "ticket_Ticket_id");
            AddForeignKey("dbo.Seats", "ticket_Ticket_id", "dbo.Tickets", "Ticket_id");
        }
    }
}
