using HovedOpgaveMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HovedOpgaveMVC.Controllers
{
    public class CountryController : Controller
    {
        readonly string strConnString = "Data Source=DESKTOP-PC0LDAO;Initial Catalog=HovedOpgaveCountry;Integrated Security=True";
        // GET: Statestic
        [Authorize(Roles = "Admin")]
        public ActionResult Statestic()
        {
            CountryViewModel CVM = new CountryViewModel();
            try
            {
                SqlConnection conn = new SqlConnection(strConnString);

                SqlCommand cmd = new SqlCommand("select * from Country", conn);

                conn.Open();

                //cmd.ExecuteNonQuery();
                SqlDataReader sqld = null;
                sqld = cmd.ExecuteReader();

                List<string> DatabaseDataCountry = new List<string>();
                List<string> DatabaseDataDates = new List<string>();

                if (sqld.HasRows)
                {
                    while (sqld.Read())
                    {
                        DatabaseDataCountry.Add(sqld["Country"].ToString());
                        DatabaseDataDates.Add(sqld["Date"].ToString());
                    }
                }
                DatabaseDataCountry.Sort();
                DatabaseDataDates = DatesSort(DatabaseDataDates);
                #region Dates
                var g = DatabaseDataDates.GroupBy(i => i);
                foreach (var grp in g)
                {
                    CVM.Dates.Add(grp.Key);
                    CVM.DatesNumbers.Add(grp.Count());
                }
                #endregion
                #region Countries
                g = DatabaseDataCountry.GroupBy(i => i);
                foreach (var grp in g)
                {
                    CVM.Countries.Add(grp.Key);
                    CVM.CountriesNumbers.Add(grp.Count());
                }
                #endregion

                conn.Close();
                conn.Dispose();

                return View(CVM);
            }
            catch
            {
                return View(CVM);
            }
        }
        public List<string> DatesSort(List<string> Dates)
        {
            var orderedList = Dates.OrderBy(x => DateTime.Parse(x)).ToList();
            return orderedList;
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public void Create(string country, string date)
        {
            try
            {
                // TODO: Add insert logic here
                string strConnString = "Data Source=DESKTOP-PC0LDAO;Initial Catalog=HovedOpgaveCountry;Integrated Security=True";
                SqlConnection conn = new SqlConnection(strConnString);

                SqlCommand cmd = new SqlCommand("insert into Country (Country, Date) values ('" + country + "', '" + date + "')", conn);

                conn.Open();

                //cmd.ExecuteNonQuery();
                var result = cmd.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();

                //return View();
            }
            catch
            {
                //return View();
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
