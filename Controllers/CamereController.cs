using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class CamereController : Controller
    {
        // GET: Camere
        public ActionResult AggiungiCamera()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AggiungiCamera(Camere c)
        {
            SqlConnection con = Connessione.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("numero", c.NumeroCamera);
                cmd.Parameters.AddWithValue("descrizione", c.Descrizione);
                cmd.Parameters.AddWithValue("tipo", c.Tipologia);
                cmd.CommandText = "insert into camere (NumeroCamera, Descrizione, Tipologia) values (@numero, @descrizione, @tipo)";
                cmd.Connection= con;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }

            TempData["messaggio"] = "Camera aggiunta con successo!";
            return RedirectToAction("AggiungiCamera");
        }

    }
}