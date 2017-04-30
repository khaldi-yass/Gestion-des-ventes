using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Blogin_Click(object sender, EventArgs e)
    {
        try
        {
            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);

            conn.Open();

            //cherche si le login est correcte
            SqlCommand commande = new SqlCommand("SELECT COUNT(*) FROM client WHERE login = @login", conn);
            SqlParameter param1 = new SqlParameter("@login", tLogin.Text);
            commande.Parameters.Add(param1);

            int temp = Convert.ToInt32(commande.ExecuteScalar().ToString());
            conn.Close();

            //si on trouve le login
            if (temp == 1)
            {
                conn.Open();
                SqlCommand commande2 = new SqlCommand("SELECT pass, nom, prenom FROM client WHERE login = @login", conn);
                SqlParameter param2 = new SqlParameter("@login", tLogin.Text);
                commande2.Parameters.Add(param2);

                SqlDataReader rdr = commande2.ExecuteReader();

                if (rdr.Read())
                {
                    string password = rdr[0].ToString();
                    string nom = rdr[1].ToString();
                    string prenom = rdr[2].ToString();

                    conn.Close();

                    //mot de passe correcte?
                    if (password.Equals(tPass.Text))
                    {
                        //creation d'une nouvelle instance de la classe MaSession
                        MaSession session = new MaSession(tLogin.Text, nom, prenom);
                        Session["userSession"] = session;
                        Session["login"] = session.Login;
                        //redirection vers la page d'accueil
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        (this.Master as Layout).showError("Erreur -> Mot de passe incorrecte");
                    }

                }
            }
            else
            {
                (this.Master as Layout).showError("Erreur -> Login incorrecte");
            }

        }catch(Exception exc)
        {
            (this.Master as Layout).showError("Exception -> " + exc.Message);
        }
    }


    //3 error handling
    //1 success handling

}