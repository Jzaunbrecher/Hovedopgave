using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HovedOpgaveMVC.Models
{
    public class RentalViewModels
    {
        public RentalViewModels()
        {
            RentalItems = new List<RentalItem>();
        }
        public List<RentalItem> RentalItems;
    }
}