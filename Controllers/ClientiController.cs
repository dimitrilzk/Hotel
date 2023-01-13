using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class ClientiController : Controller
    {
        // GET: Clienti
        public ActionResult PartialViewClienti()
        {
            return PartialView("_PartialViewClienti",Clienti.GetClienti());
        }
        public ActionResult AggiungiCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AggiungiCliente(Clienti c)
        {
            SqlConnection con = Connessione.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@Nome", c.Nome);
                cmd.Parameters.AddWithValue("@Cognome", c.Cognome);
                cmd.Parameters.AddWithValue("@CodiceFiscale", c.CodiceFiscale);
                cmd.Parameters.AddWithValue("@Citta", c.Citta);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@Cellulare", c.Cellulare);
                cmd.CommandText = "insert into clienti (Nome, Cognome, CodiceFiscale, Citta, Email, Cellulare)" +
                                    " values(@Nome, @Cognome, @CodiceFiscale, @Citta, @Email, @Cellulare)";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                con.Close();
            }
            finally 
            { 
                con.Close(); 
            }

            return RedirectToAction("AggiungiCliente");
        }

    }
}
