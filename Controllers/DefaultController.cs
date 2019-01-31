using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestZadatak2.Models;

namespace TestZadatak2.Controllers
{
    public class DefaultController : Controller
    {  
        // GET: Default
        public ActionResult Index(ClassModel cla)
        {
            return View();
        }

        public ActionResult Sacuvaj(string Ime, string Prezime, string Adresa, string Neto)
        {
               
                string bruto = Convert.ToString((Convert.ToDouble(Neto) - (15000 * 0.1)) / 0.701);
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\C#\TestZadatak2\TestZadatak2\TestZadatak2\App_Data\Database.mdf;Integrated Security=True");
                con.Open();
                string insertQuery = "INSERT INTO tableinfo(ime,prezime,adresa,neto,bruto,tr_pio,tr_zo,tr_nez,tp_pio,tp_zo) values(@ime,@prezime,@adresa,@neto,@bruto," +
                "@tr_pio,@tr_zo,@tr_nez,@tp_pio,@tp_zo)";
                SqlCommand com = new SqlCommand(insertQuery, con);
                com.Parameters.AddWithValue("@ime", Ime);
                com.Parameters.AddWithValue("@prezime", Prezime);
                com.Parameters.AddWithValue("@adresa", Adresa);
                com.Parameters.AddWithValue("@neto", Convert.ToDouble(Neto));
                com.Parameters.AddWithValue("@bruto", Convert.ToDouble(bruto));
                com.Parameters.AddWithValue("@tr_pio", Convert.ToDouble(bruto) * (14.0 / 100));
                com.Parameters.AddWithValue("@tr_zo", Convert.ToDouble(bruto) * (5.15 / 100));
                com.Parameters.AddWithValue("@tr_nez", Convert.ToDouble(bruto) * (0.75 / 100));
                com.Parameters.AddWithValue("@tp_pio", Convert.ToDouble(bruto) * (12.0 / 100));
                com.Parameters.AddWithValue("@tp_zo", Convert.ToDouble(bruto) * (5.15 / 100));
                com.ExecuteNonQuery();
                con.Close();
                
                return RedirectToAction("Index");
           
           
        }

        public ActionResult Prikaz(ClassModel cla)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\C#\TestZadatak2\TestZadatak2\TestZadatak2\App_Data\Database.mdf;Integrated Security=True");
            //con.Open();
            string selectQuery = "SELECT * FROM tableinfo";
            SqlCommand com = new SqlCommand(selectQuery, con);
             
            var model = new List<ClassModel>();
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            while (rdr.Read())
            {
                var radnik = new ClassModel();
                radnik.Ime = rdr["ime"].ToString();
                radnik.Prezime = rdr["prezime"].ToString();
                radnik.Adresa = rdr["adresa"].ToString();
                radnik.Neto = rdr["neto"].ToString();
                radnik.Bruto = rdr["bruto"].ToString();
                radnik.Radnik_PIO = rdr["tr_pio"].ToString();
                radnik.Radnik_ZO = rdr["tr_zo"].ToString();
                radnik.Radnik_Nezaposlenost = rdr["tr_nez"].ToString();
                radnik.Poslodavac_PIO = rdr["tp_pio"].ToString();
                radnik.Poslodavac_ZO = rdr["tp_zo"].ToString();
                model.Add(radnik);


            }
            return View(model);
        }
       
       
    }
    
}