using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class PrenotazioniController : Controller
    {
        // GET: Prenotazioni
        public ActionResult AggiungiPrenotazione()
        {
            return View();
        }
    }
}