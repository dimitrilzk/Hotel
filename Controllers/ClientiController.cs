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
            ViewBag.ListaClienti = Clienti.ListaDrpdwnClienti;
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
        public ActionResult ModificaCliente(int id)
        {
            SqlConnection con = Connessione.GetConnection();
            Clienti cliente = new Clienti();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = "select * from clienti where IdCliente = @id";
                cmd.Connection=con;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    cliente.Nome = reader["Nome"].ToString();
                    cliente.Cognome = reader["Cognome"].ToString();
                    cliente.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    cliente.Citta = reader["Citta"].ToString();
                    cliente.Email = reader["Email"].ToString();
                    cliente.Cellulare = reader["Cellulare"].ToString();
                }
            }catch(Exception ex) 
            { 
                con.Close(); 
            } 
            finally 
            { 
                con.Close(); 
            }
            return View(cliente);
        }
        [HttpPost]
        public ActionResult ModificaCliente(Clienti c, int id)
        {
            SqlConnection con = Connessione.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@IdCliente", id);
                cmd.Parameters.AddWithValue("@Nome", c.Nome);
                cmd.Parameters.AddWithValue("@Cognome", c.Cognome);
                cmd.Parameters.AddWithValue("@CodiceFiscale", c.CodiceFiscale);
                cmd.Parameters.AddWithValue("@Citta", c.Citta);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@Cellulare", c.Cellulare);
                cmd.CommandText = "update clienti set Nome = @Nome, Cognome = @Cognome, CodiceFiscale = @CodiceFiscale, Citta = @Citta," +
                    "Email = @Email, Cellulare = @Cellulare where IdCliente = @IdCliente";
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
        public ActionResult EliminaCliente(int id)
        {
            SqlConnection con = Connessione.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = "delete from clienti where IdCliente= @id";
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
        public ActionResult DettagliCliente(int id)
        {
            SqlConnection con = Connessione.GetConnection();
            Clienti cliente = new Clienti();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = "select * from clienti where IdCliente = @id";
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    cliente.Nome = reader["Nome"].ToString();
                    cliente.Cognome = reader["Cognome"].ToString();
                    cliente.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    cliente.Citta = reader["Citta"].ToString();
                    cliente.Email = reader["Email"].ToString();
                    cliente.Cellulare = reader["Cellulare"].ToString();
                }
            }catch(Exception ex)
            {
                con.Close();
            }finally
            {
                con.Close();
            }
            return View(cliente);
        }
    }
}
