using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacultyProfileManagementSystem
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Session validation: Check if the user is logged in
            if (Session["username"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                // Display welcome message
                lblWelcome.Text = "Welcome, " + Session["username"].ToString();
            }

            // Highlight the active navigation link
            SetActivePage();
        }

        private void SetActivePage()
        {
            string activePage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            if (activePage.Equals("FacultyProfile.aspx", StringComparison.InvariantCultureIgnoreCase))
            {
                lnkHome.CssClass = "active";
            }
        }
    }
}