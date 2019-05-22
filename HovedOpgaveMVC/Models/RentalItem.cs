using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HovedOpgaveMVC.Models
{
    public class RentalItem
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Billede { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Tekst { get; set; }

        [Range(1, 100)]
        public string Pris { get; set; }
    }
}