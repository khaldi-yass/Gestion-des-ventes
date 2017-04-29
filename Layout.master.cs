using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Layout : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userSession"] != null)
        {
            Response.Redirect("Default.aspx");
        }
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

}
