namespace ShowTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moviecontext2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Seats", name: "Movie_Movie_id", newName: "Movie_id");
            RenameColumn(table: "dbo.Seats", name: "Theatre_Theatre_id", newName: "Thea_id");
            RenameColumn(table: "dbo.Tickets", name: "Seat_Seat_id", newName: "Seat_id");
            RenameColumn(table: "dbo.Movies", name: "Show_Theatre_id", newName: "Thea_id");
            RenameIndex(table: "dbo.Movies", name: "IX_Show_Theatre_id", newName: "IX_Thea_id");
            RenameIndex(table: "dbo.Seats", name: "IX_Movie_Movie_id", newName: "IX_Movie_id");
            RenameIndex(table: "dbo.Seats", name: "IX_Theatre_Theatre_id", newName: "IX_Thea_id");
            RenameIndex(table: "dbo.Tickets", name: "IX_Seat_Seat_id", newName: "IX_Seat_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tickets", name: "IX_Seat_id", newName: "IX_Seat_Seat_id");
            RenameIndex(table: "dbo.Seats", name: "IX_Thea_id", newName: "IX_Theatre_Theatre_id");
            RenameIndex(table: "dbo.Seats", name: "IX_Movie_id", newName: "IX_Movie_Movie_id");
            RenameIndex(table: "dbo.Movies", name: "IX_Thea_id", newName: "IX_Show_Theatre_id");
            RenameColumn(table: "dbo.Movies", name: "Thea_id", newName: "Show_Theatre_id");
            RenameColumn(table: "dbo.Tickets", name: "Seat_id", newName: "Seat_Seat_id");
            RenameColumn(table: "dbo.Seats", name: "Thea_id", newName: "Theatre_Theatre_id");
            RenameColumn(table: "dbo.Seats", name: "Movie_id", newName: "Movie_Movie_id");
        }
    }
}
