using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Prenotazioni
    {
        public int IdPrenotazione { get; set; }

        [Display(Name ="Data Prenotazione")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataPrenotazione { get; set; }

        [Display(Name = "Data Inizio Soggiorno")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInizioSoggiorno { get; set; }

        [Display(Name = "Data Fine Soggiorno")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFineSoggiorno { get; set; }

        [DataType(DataType.Currency)]
        public decimal Acconto { get; set; }

        [DataType(DataType.Currency)]
        public decimal Prezzo { get; set; }
        public int IdCliente { get; set; }
        public int IdCamera { get; set; }
    }
}