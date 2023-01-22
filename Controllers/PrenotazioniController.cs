using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    [Authorize]
    public class PrenotazioniController : Controller
    {
        public ActionResult PartialViewPrenotazioniAndClienti()
        {
            return PartialView("_PartialViewPrenotazioniAndClienti", Prenotazioni.GetPrenotazioniAndClienti());
        }
        // GET: Prenotazioni
        public ActionResult AggiungiPrenotazione()
        {
            ViewBag.ListaClienti = Clienti.ListaDrpdwnClienti;
            ViewBag.ListaCamere = Camere.ListaDrpdwnCamere;
            return View();
        }
        [HttpPost]
        public ActionResult AggiungiPrenotazione(Prenotazioni p)
        {

            SqlConnection con = Connessione.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@DataPrenotazione", p.DataPrenotazione);
                cmd.Parameters.AddWithValue("@DataInizioSoggiorno", p.DataInizioSoggiorno);
                cmd.Parameters.AddWithValue("@DataFineSoggiorno", p.DataFineSoggiorno);
                cmd.Parameters.AddWithValue("@Acconto", p.Acconto);
                cmd.Parameters.AddWithValue("@Prezzo", p.Prezzo);
                cmd.Parameters.AddWithValue("@IdCliente", p.IdCliente);
                cmd.Parameters.AddWithValue("@IdCamera", p.IdCamera);
                cmd.CommandText = "insert into prenotazioni (DataPrenotazione, DataInizioSoggiorno, DataFineSoggiorno, Acconto, Prezzo, IdCliente, IdCamera)" +
                                    " values(@DataPrenotazione, @DataInizioSoggiorno, @DataFineSoggiorno, @Acconto, @Prezzo, @IdCliente, @IdCamera)";
                cmd.Connection = con;
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

            return RedirectToAction("AggiungiPrenotazione");
        }
    }
}