using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace CarDealership
{
    public partial class NavigationCust : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("CustLogin.aspx");

            }
            else
            {
                lblusername.Text = HttpUtility.HtmlEncode(Session["username"].ToString());
            }
            
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("CustLogin.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
