namespace ShowTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moviecontext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seats", "movie_Movie_id", "dbo.Movies");
            DropForeignKey("dbo.Tickets", "seat_Seat_id", "dbo.Seats");
            DropIndex("dbo.Seats", new[] { "movie_Movie_id" });
            DropIndex("dbo.Tickets", new[] { "seat_Seat_id" });
            RenameColumn(table: "dbo.Movies", name: "show_Theatre_id", newName: "Theatre_Theatre_id");
            RenameColumn(table: "dbo.Seats", name: "show_Theatre_id", newName: "Theatre_Theatre_id");
            RenameIndex(table: "dbo.Movies", name: "IX_show_Theatre_id", newName: "IX_Theatre_Theatre_id");
            RenameIndex(table: "dbo.Seats", name: "IX_show_Theatre_id", newName: "IX_Theatre_Theatre_id");
            AddColumn("dbo.Seats", "ticket_Ticket_id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Seats", "ticket_Ticket_id");
            AddForeignKey("dbo.Seats", "ticket_Ticket_id", "dbo.Tickets", "Ticket_id");
            DropColumn("dbo.Seats", "movie_Movie_id");
            DropColumn("dbo.Tickets", "seat_Seat_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "seat_Seat_id", c => c.Int());
            AddColumn("dbo.Seats", "movie_Movie_id", c => c.Int());
            DropForeignKey("dbo.Seats", "ticket_Ticket_id", "dbo.Tickets");
            DropIndex("dbo.Seats", new[] { "ticket_Ticket_id" });
            DropColumn("dbo.Seats", "ticket_Ticket_id");
            RenameIndex(table: "dbo.Seats", name: "IX_Theatre_Theatre_id", newName: "IX_show_Theatre_id");
            RenameIndex(table: "dbo.Movies", name: "IX_Theatre_Theatre_id", newName: "IX_show_Theatre_id");
            RenameColumn(table: "dbo.Seats", name: "Theatre_Theatre_id", newName: "show_Theatre_id");
            RenameColumn(table: "dbo.Movies", name: "Theatre_Theatre_id", newName: "show_Theatre_id");
            CreateIndex("dbo.Tickets", "seat_Seat_id");
            CreateIndex("dbo.Seats", "movie_Movie_id");
            AddForeignKey("dbo.Tickets", "seat_Seat_id", "dbo.Seats", "Seat_id");
            AddForeignKey("dbo.Seats", "movie_Movie_id", "dbo.Movies", "Movie_id");
        }
    }
}
