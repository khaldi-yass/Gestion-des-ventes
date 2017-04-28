using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListCat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["connected"] != null && Session["connected"].ToString().Equals("true"))
        {
            MasterPage master = this.Master;
            (this.Master as Layout_members).username(Session["nom"].ToString(), Session["prenom"].ToString());
            showCats();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void showCats()
    {
        try
        {
            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            SqlCommand commande = new SqlCommand("SELECT numArticle, designation, prixU, photo FROM article", conn);

            SqlDataReader reader = commande.ExecuteReader();

            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    tableLiteral.Text += "<tr'><td>" + reader[1] + "</td> <td>" + reader[2] + "</td><td> <img class='img img-thumbnail' width='100' src='" + reader[3] + "' alt='" + reader[1] + "'/> </td><td> <a href='/Details.aspx?articleId=" + reader[0] + "'>Voir details</a> </td></tr>";
                }
            }else
            {
                tableLiteral.Text = "<tr class='text-center warning'> <td colspan=4> Aucun article dans la base </td> </tr>";
            }

            reader.Close();
            conn.Close();
        }catch(Exception exce)
        {
            Session["errorMsg"] = exce.Message;
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
}