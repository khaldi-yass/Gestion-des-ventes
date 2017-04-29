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
            //Remplissage de la liste des categories
            DropDownList1.DataSource = fillCats();
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Toutes les categories");

            //lors de du chargement on appel la methode
            showCats();
    }


    //remplis le dropMenu des categories
    protected List<string> fillCats()
    {
        try
        {
            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            SqlCommand commande = new SqlCommand("SELECT nomCat FROM categorie", conn);

            SqlDataReader reader = commande.ExecuteReader();

            List<string> list = new List<string>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
            }
            else
            {
                return null;
            }

            reader.Close();
            conn.Close();
            return list;
        }
        catch (Exception exce)
        {
            (this.Master as Layout_members).showError("Exception -> " + exce.Message);
            return null;
        }
    }


    //cherche dans la base de donnee les articles et les affiches dans une table
    protected void showCats(string cat = "*")
    {
        try
        {
            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            SqlCommand commande;

            if (cat.Equals("*"))
            {
                commande = new SqlCommand("SELECT numArticle, designation, prixU, photo FROM article", conn);
            }
            else
            {
                commande = new SqlCommand(@"   SELECT numArticle, designation, prixU, photo 
                                                FROM article 
                                                WHERE refCat = (SELECT refCat FROM categorie
                                                                WHERE nomCat = '" + cat + "')", conn);
            }

            SqlDataReader reader = commande.ExecuteReader();

            string output = @"<table class='table table-bordered table-hover table-striped table-responsive table-condensed'>
                              <thead>
                                <tr class='info'> <th>Designations</th> <th>Prix unitaire(Dh)</th> <th>Photo de produit</th> <th>Details</th> </tr>
                              </thead>
                              <tbody>";

            if (reader.HasRows)
            {        
                while (reader.Read())
                {
                    output += "<tr><td>" + reader[1] + "</td> <td>" + reader[2] + "</td><td> <img class='img img-thumbnail' width='100' src='" + reader[3] + "' alt='" + reader[1] + "'/> </td><td> <a href='/Details.aspx?articleId=" + reader[0] + "'>Voir details</a> </td></tr>";
                }
            }else
            {
                output = "<tr class='text-center warning'> <td colspan=4> Aucun article dans la base </td> </tr>";
            }

            output += "</tbody></ table>";

            tableLiteral.Text = output;
            reader.Close();
            conn.Close();
        }
        catch(Exception exce)
        {
            (this.Master as Layout_members).showError("Exception -> " + exce.Message);
        }
    }

    protected void update_table(object sender, EventArgs e)
    {
        string categorie = DropDownList1.SelectedValue;

        if (categorie.Equals("Toutes les categories"))
        {
            showCats();
        }
        else
        {
            showCats(categorie);
        }
    }

}