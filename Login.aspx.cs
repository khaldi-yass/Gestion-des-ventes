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
        if(Session["connected"] != null && Session["connected"].Equals("true"))
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            if (Session["errorMsg"] != null)
            {
                errorLabel.Text = Session["errorMsg"].ToString();
                Session["errorMsg"] = null;
            }
        }
    }

    protected void Blogin_Click(object sender, EventArgs e)
    {
        try
        {
            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);

            conn.Open();

            SqlCommand commande = new SqlCommand("SELECT COUNT(*) FROM client WHERE login = @login", conn);
            SqlParameter param1 = new SqlParameter("@login", tLogin.Text);
            commande.Parameters.Add(param1);

            int temp = Convert.ToInt32(commande.ExecuteScalar().ToString());
            conn.Close();

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

                    if (password.Equals(tPass.Text))
                    {
                        Session["login"] = tLogin.Text;
                        Session["nom"] = nom;
                        Session["prenom"] = prenom;
                        Session["connected"] = "true";

                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Session["errorMsg"] = "Erreur: Mot de passe incorrecte";
                    }

                }
            }
            else
            {
                Session["errorMsg"] = "Erreur: Login incorrecte";
            }

        }catch(Exception exc)
        {
            Session["errorMsg"] = "Exception: " + exc.Message;
        }
    }


}