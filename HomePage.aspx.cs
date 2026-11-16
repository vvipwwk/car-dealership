using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarDealership
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CustLogin.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("StaffLogin.aspx");
        }
    }
}