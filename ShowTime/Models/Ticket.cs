using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShowTime.Models
{
    public class Ticket
    {
        [Key]
        public int Ticket_id { get; set; }

        public string T_NO { get; set; }
        [ForeignKey("seat")]
        public int? Seat_id { get; set; }
        [ForeignKey("user")]
        public int? user_id { get; set; }

        public virtual Seat seat { get; set; }
        public virtual User user { get; set; }
    }
}