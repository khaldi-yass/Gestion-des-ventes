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
        List<string> villes = new List<string>(new string[] { "Rabat", "Casablanca", "Sale", "Safi", "El jadida" });
        SelectVille.DataSource = villes;
        SelectVille.DataBind();

        if (Session["errorMsg"] != null)
        {
            errorLabel.Text = Session["errorMsg"].ToString();
            Session["errorMsg"] = null;
        }
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

            SqlCommand commande = new SqlCommand("SELECT COUNT(*) FROM client WHERE login = @login", conn);
            SqlParameter param1 = new SqlParameter("@login", tlogin.Text);
            commande.Parameters.Add(param1);

            int temp = Convert.ToInt32(commande.ExecuteScalar().ToString());
            conn.Close();

            if (temp == 1)
            {
                Session["errorMsg"] = "Login deja utilisé!";
                //Response.Redirect("Default.aspx");
            }
            else
            {
                conn.Open();

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

                if (validated != 1)
                {
                    Session["errorMsg"] = "Une erreur est survenue, veuillez réessayer plus tard!";
                }
                else
                {
                    Session["login"] = tlogin.Text;
                    Session["nom"] = tnom.Text;
                    Session["prenom"] = tprenom.Text;
                    Session["connected"] = "true";
                    Response.Redirect("Default.aspx");
                }
            }
        } catch(Exception exce)
        {
            Session["errorMsg"] = "Exception: " + exce.Message;
        }
    }
}