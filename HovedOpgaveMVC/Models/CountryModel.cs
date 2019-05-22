using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HovedOpgaveMVC.Models
{
    public class CountryModel
    {
        [Required]
        public string Country { get; set; }
    }
}