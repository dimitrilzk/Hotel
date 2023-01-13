using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace Hotel.Models
{
    public class Clienti
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        [Display(Name ="Codice Fiscale")]
        public string CodiceFiscale { get; set; }
        public string Citta { get; set; }
        public string Email { get; set; }
        public string Cellulare { get; set; }
        public static List<Clienti> GetClienti()
        {
            SqlConnection c = Connessione.GetConnection();
            List<Clienti> ListaClienti = new List<Clienti>();
            try
            {
                c.Open();
                SqlDataReader r = Connessione.GetReader("select * from clienti", c);
                while(r.Read())
                {
                    Clienti cliente = new Clienti();
                    cliente.IdCliente = Convert.ToInt32(r["IdCliente"]);
                    cliente.Nome = r["Nome"].ToString();
                    cliente.Cognome = r["Cognome"].ToString();
                    cliente.CodiceFiscale = r["CodiceFiscale"].ToString();
                    cliente.Citta = r["Citta"].ToString();
                    cliente.Email = r["Email"].ToString();
                    cliente.Cellulare = r["Cellulare"].ToString();
                    ListaClienti.Add(cliente);

                }
            }
            catch(Exception ex)
            {
                c.Close();
            }
            finally
            {
                c.Close();
            }
            return ListaClienti;
        }

    }
}