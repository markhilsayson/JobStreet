using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobStreet.Models
{
    public class Nationality
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(5)]
        public string Abbreviation { get; set; }

        [StringLength(130)]
        public string Adjective { get; set; }

        [StringLength(60)]
        public string Person { get; set; }
    }
}