using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShowTime.Models
{
    public class Theatre 
    {
        [Key]
        public int Theatre_id { get; set; }
        public string Theatre_name { get; set; }
        public string City { get; set; }

       // public virtual ICollection<Movie> Movies { get; set; }
        //public virtual ICollection<Seat> Seats { get; set; }
    }
}