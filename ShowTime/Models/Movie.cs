using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShowTime.Models
{
    public class Movie
    {
        [Key]
        public int Movie_id { get; set; }
        public string Movie_name { get; set; }
        public string Show_time { get; set; }
        [ForeignKey("theatre")]
        public int? Thea_id { get; set; }
        public virtual Theatre theatre { get; set; }

       // public virtual ICollection<Seat> Seats { get; set; }
    }
}