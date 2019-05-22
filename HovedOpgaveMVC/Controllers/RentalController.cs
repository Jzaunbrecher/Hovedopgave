using HovedOpgaveMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HovedOpgaveMVC.Controllers
{
    public class RentalController : Controller
    {
        readonly string strConnString = "Data Source=DESKTOP-PC0LDAO;Initial Catalog=HovedOpgaveRental;Integrated Security=True";
        // GET: Rental
        [Authorize]
        public ActionResult Index()
        {
            var RVM = new RentalViewModels();
            try
            {
                SqlConnection conn = new SqlConnection(strConnString);

                SqlCommand cmd = new SqlCommand("select * from Rental", conn);

                conn.Open();

                //cmd.ExecuteNonQuery();
                SqlDataReader sqld = null;
                sqld = cmd.ExecuteReader();
                if (sqld.HasRows)
                {
                    RentalItem rentalItem;
                    while (sqld.Read())
                    {
                        rentalItem = new RentalItem
                        {
                            ID= Convert.ToInt32(sqld["Id"].ToString()),
                            Billede = sqld["Billede"].ToString(),
                            Tekst = sqld["Tekst"].ToString(),
                            Pris = sqld["Pris"].ToString()
                        };
                        char dummyChar = '&'; //here put a char that you know won't appear in the strings
                        var temp = rentalItem.Pris.Replace('.', dummyChar)
                                               .Replace(',', '.')
                                               .Replace(dummyChar, ',');
                        rentalItem.Pris = temp.Substring(0,temp.Length-2);

                        RVM.RentalItems.Add(rentalItem);
                    }
                }
                conn.Close();
                conn.Dispose();

                return View(RVM);
            }
            catch
            {
                return View(RVM);
            }
        }

        // GET: Rental/Rent/5
        [Authorize]
        public ActionResult Rent(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConnString);

                SqlCommand cmd = new SqlCommand("select * from Rental where Id=" + id, conn);

                conn.Open();

                //cmd.ExecuteNonQuery();
                SqlDataReader sqld = null;
                sqld = cmd.ExecuteReader();

                RentalItem rentalItem = new RentalItem();

                if (sqld.HasRows)
                {
                    while (sqld.Read())
                    {
                        rentalItem = new RentalItem
                        {
                            ID = Convert.ToInt32(sqld["Id"].ToString()),
                            Billede = sqld["Billede"].ToString(),
                            Tekst = sqld["Tekst"].ToString(),
                            Pris = sqld["Pris"].ToString()
                        };
                        char dummyChar = '&'; //here put a char that you know won't appear in the strings
                        var temp = rentalItem.Pris.Replace('.', dummyChar)
                                               .Replace(',', '.')
                                               .Replace(dummyChar, ',');
                        rentalItem.Pris = temp.Substring(0, temp.Length - 2);
                    }
                }
                conn.Close();
                conn.Dispose();

                return View(rentalItem);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
        }

        // GET: Rental/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rental/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(string Billede, string Tekst, string Pris)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConnString);

                SqlCommand cmd = new SqlCommand("insert into Rental (Billede, Tekst, Pris) values ('" + Billede + "','" + Tekst + "', " + Pris + ")", conn);

                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();

                return RedirectToAction("Index");
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
        }

        // GET: Rental/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConnString);

                SqlCommand cmd = new SqlCommand("select * from Rental where Id=" + id, conn);

                conn.Open();

                //cmd.ExecuteNonQuery();
                SqlDataReader sqld = null;
                sqld = cmd.ExecuteReader();
                
                RentalItem rentalItem = new RentalItem();

                if (sqld.HasRows)
                {
                    while (sqld.Read())
                    {
                        rentalItem = new RentalItem
                        {
                            ID = Convert.ToInt32(sqld["Id"].ToString()),
                            Billede = sqld["Billede"].ToString(),
                            Tekst = sqld["Tekst"].ToString(),
                            Pris = sqld["Pris"].ToString()
                        };
                        char dummyChar = '&'; //here put a char that you know won't appear in the strings
                        var temp = rentalItem.Pris.Replace('.', dummyChar)
                                               .Replace(',', '.')
                                               .Replace(dummyChar, ',');
                        rentalItem.Pris = temp.Substring(0, temp.Length - 2);
                    }
                }
                conn.Close();
                conn.Dispose();

                return View(rentalItem);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
        }

        // POST: Rental/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, string Billede, string Tekst, string Pris)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConnString);
                
                SqlCommand cmd = new SqlCommand("UPDATE Rental SET Billede = '" + Billede + "', Tekst= '" + Tekst + "', Pris= " + Pris + " WHERE Id = " + id, conn);

                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();

                return RedirectToAction("Index");
            }
            catch(SqlException e)
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Rental/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConnString);

                SqlCommand cmd = new SqlCommand("select * from Rental where Id=" + id, conn);

                conn.Open();

                //cmd.ExecuteNonQuery();
                SqlDataReader sqld = null;
                sqld = cmd.ExecuteReader();

                RentalItem rentalItem = new RentalItem();

                if (sqld.HasRows)
                {
                    while (sqld.Read())
                    {
                        rentalItem = new RentalItem
                        {
                            ID = Convert.ToInt32(sqld["Id"].ToString()),
                            Billede = sqld["Billede"].ToString(),
                            Tekst = sqld["Tekst"].ToString(),
                            Pris = sqld["Pris"].ToString()
                        };
                        char dummyChar = '&'; //here put a char that you know won't appear in the strings
                        var temp = rentalItem.Pris.Replace('.', dummyChar)
                                               .Replace(',', '.')
                                               .Replace(dummyChar, ',');
                        rentalItem.Pris = temp.Substring(0, temp.Length - 2);
                    }
                }
                conn.Close();
                conn.Dispose();

                return View(rentalItem);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
        }

        // POST: Rental/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConnString);

                SqlCommand cmd = new SqlCommand("DELETE FROM Rental WHERE Id = " + id, conn);

                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();

                return RedirectToAction("Index");
            }
            catch (SqlException e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
