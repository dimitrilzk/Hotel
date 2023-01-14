using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Camere
    {
        public int IdCamera { get; set; }
        [Display(Name = "Numero della camera")]
        public int NumeroCamera { get; set; }
        public string Descrizione { get; set; }
        [Display(Name ="Seleziona per camera tripla - lascia vuoto per camera doppia")]
        public bool Tipologia { get; set; }
    }
}