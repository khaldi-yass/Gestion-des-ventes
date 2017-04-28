using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["connected"] != null && Session["connected"].ToString().Equals("true"))
        {
            MasterPage master = this.Master;
            (this.Master as Layout_members).username(Session["nom"].ToString(), Session["prenom"].ToString());
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}