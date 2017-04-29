using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Layout_members : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userSession"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            MaSession session = (MaSession)Session["userSession"];
            username(session.Nom, session.Prenom);
        }
    }

    public void username(string nom, string prenom)
    {
        Label1.Text = nom + " " + prenom;
    }

    public void showError(string errorMsg)
    {
        errorLabel.Text = errorMsg;
        errorPanel.Visible = true;
    }

    public void showSuccess(string successMsg)
    {
        successLabel.Text = successMsg;
        successPanel.Visible = true;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
}
