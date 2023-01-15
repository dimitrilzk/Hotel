using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Users
    {
        public int IdUser { get; set; }
        [Display(Name ="Username")]
        [Required(ErrorMessage ="Campo obbligatorio!")]
        public string UsernameDip { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Campo obbligatorio!")]
        public string PasswordDip { get; set; }
        public string RuoloDip { get; set; }
        public static bool Auth(string username, string password)
        {
            SqlConnection c = Connessione.GetConnection();
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("select * from users where UsernameDip = @username and PasswordDip = @password", c);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);
                SqlDataReader reader = cmd.ExecuteReader(); 
                if(reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                c.Close();
            }
        }
    }
}