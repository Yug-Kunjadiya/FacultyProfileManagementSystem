using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FacultyProfileManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Handle logout
            if (!IsPostBack && Request.QueryString["logout"] == "true")
            {
                Session.Clear();
                Session.Abandon();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Hardcoded credentials for simulation
            string adminUser = "admin";
            string adminPass = "password123";

            if (txtUsername.Text == adminUser && txtPassword.Text == adminPass)
            {
                // Store username in session
                Session["username"] = txtUsername.Text;
                Response.Redirect("~/FacultyProfile.aspx");
            }
            else
            {
                lblError.Text = "Invalid username or password.";
            }
        }
    }
}