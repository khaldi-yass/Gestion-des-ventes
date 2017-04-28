using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["connected"] != null && Session["connected"].ToString().Equals("true"))
        {
            MasterPage master = this.Master;
            (this.Master as Layout_members).username(Session["nom"].ToString(), Session["prenom"].ToString());

            if (Request.QueryString["articleId"] != null)
            {
                loadInfos();
            }
            else
            {
                Response.Redirect("ListCat.aspx");
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void loadInfos()
    {
        try
        {
            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            SqlCommand commande = new SqlCommand("SELECT * FROM article WHERE numArticle = @numArticle", conn);
            SqlParameter param = new SqlParameter("@numArticle", Request.QueryString["articleId"]);
            commande.Parameters.Add(param);
            SqlDataReader reader = commande.ExecuteReader();

            if (reader.Read())
            {
                lnumArticle.Text = Convert.ToString(reader[0]) + ".";
                ldesignation.Text = Convert.ToString(reader[1]) + ".";
                lprix.Text = Convert.ToString(reader[2]) + " DH.";
                lstock.Text = Convert.ToString(reader[3]) + " unités.";
                Image1.ImageUrl = Convert.ToString(reader[4]);
            }
            else
            {
                Response.Write("Une erreur est survenue lors de l'operation (Le produit demandé n'existe pas)");
            }

            reader.Close();
            conn.Close();
            
        }
        catch (Exception exce)
        {
            Response.Write(exce.Message);
        }
    }
}