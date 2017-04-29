using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Remplissage de dropList
        List<string> villes = new List<string>(new string[] { "Rabat", "Casablanca", "Sale", "Safi", "El jadida" });
        SelectVille.DataSource = villes;
        SelectVille.DataBind();
    }
    
    protected void SelectVille_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            //Cherche si le login est deja utilisé
            SqlCommand commande = new SqlCommand("SELECT COUNT(*) FROM client WHERE login = @login", conn);
            SqlParameter param1 = new SqlParameter("@login", tlogin.Text);
            commande.Parameters.Add(param1);

            int temp = Convert.ToInt32(commande.ExecuteScalar().ToString());
            conn.Close();

            //Si le login est deja utilisee, une erreur s'affiche
            if (temp == 1)
            {
                (this.Master as Layout).showError("Erreur -> Login deja utilisé!");
            }
            else
            {
                conn.Open();

                //insertion
                SqlCommand commande2 = new SqlCommand("INSERT INTO client VALUES (@login, @pass, @nom, @prenom, @email,@ville, @tel)", conn);

                commande2.Parameters.AddRange(new[] {
                new SqlParameter("@login", tlogin.Text),
                new SqlParameter("@pass", tpass.Text),
                new SqlParameter("@nom", tnom.Text),
                new SqlParameter("@prenom", tprenom.Text),
                new SqlParameter("@email", temail.Text),
                new SqlParameter("@ville", SelectVille.SelectedItem.Text),
                new SqlParameter("@tel", ttel.Text),
            });

                int validated = commande2.ExecuteNonQuery();

                //insertion echouee!
                if (validated != 1)
                {
                    //message d'erreur
                    (this.Master as Layout).showError("Erreur -> Une erreur inconnue est survenue!");
                }
                else
                {
                    //creation d'une nouvelle instance de la classe MaSession
                    MaSession session = new MaSession(tlogin.Text, tnom.Text, tprenom.Text);
                    Session["userSession"] = session;
                    //redirection vers la page d'acceuil
                    Response.Redirect("Default.aspx");
                }
            }
        } catch(Exception exce)
        {
            (this.Master as Layout).showError("Exception -> " + exce.Message);
        }
    }

    //3 error handling
    //1 success handling
}