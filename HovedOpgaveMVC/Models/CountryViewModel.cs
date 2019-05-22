using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HovedOpgaveMVC.Models
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {
            Dates = new List<string>();
            DatesNumbers = new List<int>();

            Countries = new List<string>();
            CountriesNumbers = new List<int>();
        }
        public List<string> Dates;
        public List<int> DatesNumbers;

        public List<string> Countries;
        public List<int> CountriesNumbers;
    }
}