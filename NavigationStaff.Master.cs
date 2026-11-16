using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace CarDealership
{
    public partial class NavigationStaff : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["staffid"] == null)
            {
                Response.Redirect("StaffLogin.aspx");

            }
            else
            {
                lblStaffname.Text = Session["staffid"].ToString();
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffLogin.aspx");
        }

    }
}