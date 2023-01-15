using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public static List<SelectListItem> ListaDrpdwnCamere
        {
            get
            {
                List<SelectListItem> lista = new List<SelectListItem>();
                SqlConnection con = Connessione.GetConnection();
                con.Open();
                SqlDataReader reader = Connessione.GetReader("select * from camere", con);
                while (reader.Read())
                {
                    SelectListItem item = new SelectListItem
                    {
                        Text = $"{reader["NumeroCamera"].ToString()} ({reader["Descrizione"].ToString()})",
                        Value = reader["IdCamera"].ToString()
                    };
                    lista.Add(item);
                }
                return lista;
            }
        }
    }
}