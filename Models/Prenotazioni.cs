using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Prenotazioni
    {
        [Display(Name = "N° Prenotazione")]
        public int IdPrenotazione { get; set; }

        [Display(Name ="Data Prenotazione")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataPrenotazione { get; set; }

        [Display(Name = "Inizio Soggiorno")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInizioSoggiorno { get; set; }

        [Display(Name = "Fine Soggiorno")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFineSoggiorno { get; set; }

        [DataType(DataType.Currency)]
        public decimal Acconto { get; set; }

        [DataType(DataType.Currency)]
        public decimal Prezzo { get; set; }
        [Display(Name ="Cliente")]
        public int IdCliente { get; set; }
        [Display(Name = "Camera")]
        public int IdCamera { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Codice Fiscale")]
        public string CodiceFiscale { get; set; }
        [Display(Name = "Numero Camera")]
        public int NumeroCamera { get; set; }

        public static List<Prenotazioni> GetPrenotazioniAndClienti()
        {
            SqlConnection c = Connessione.GetConnection();
            List<Prenotazioni> ListaPrenotazioni = new List<Prenotazioni>();
            try
            {
                c.Open();
                SqlDataReader r = Connessione.GetReader("SELECT Prenotazioni.IdPrenotazione, Prenotazioni.DataPrenotazione, " +
                    "Prenotazioni.DataInizioSoggiorno, Prenotazioni.DataFineSoggiorno, Clienti.Nome, Clienti.Cognome, " +
                    "Clienti.CodiceFiscale, Camere.NumeroCamera FROM Prenotazioni INNER JOIN Clienti ON Prenotazioni.IdCliente = Clienti.IdCliente " +
                    "INNER JOIN Camere ON Prenotazioni.IdCamera = Camere.IdCamera", c);
                while (r.Read())
                {
                    Prenotazioni prenotazione = new Prenotazioni();
                    prenotazione.IdPrenotazione = Convert.ToInt32(r["IdPrenotazione"]);
                    prenotazione.DataPrenotazione = Convert.ToDateTime(r["DataPrenotazione"]);
                    prenotazione.DataInizioSoggiorno = Convert.ToDateTime(r["DataInizioSoggiorno"]);
                    prenotazione.DataFineSoggiorno = Convert.ToDateTime(r["DataFineSoggiorno"]);
                    prenotazione.Nome = $"{r["Nome"].ToString()} {r["Cognome"].ToString()}";
                    prenotazione.CodiceFiscale = r["CodiceFiscale"].ToString();
                    prenotazione.NumeroCamera = Convert.ToInt32(r["NumeroCamera"]);
                    ListaPrenotazioni.Add(prenotazione);
                }
            }
            catch (Exception ex)
            {
                c.Close();
            }
            finally
            {
                c.Close();
            }
            return ListaPrenotazioni;
        }
    }
}