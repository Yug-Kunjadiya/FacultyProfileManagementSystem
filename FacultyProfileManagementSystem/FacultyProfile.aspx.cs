using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; // For SQL Server
using System.Configuration; // To read Web.config
using System.Data;          // For command types


namespace FacultyProfileManagementSystem
{
    public partial class FacultyProfile : System.Web.UI.Page
    {

        string connectionString = ConfigurationManager.ConnectionStrings["facultyDBConnectionString2"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            Response.Write("");
            con.Close();

            if (!IsPostBack)
            {
                // ViewState retains control values on postback, so this runs only on initial load.
                lblMessage.Text = "";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // 1. Generate Employee ID (same as before)
                string initials = GetInitials(txtFullName.Text);
                string timestamp = DateTime.Now.ToString("mmss");
                string employeeId = $"{initials}{timestamp}";

                // 2. Get connection string from Web.config
                //string connectionString = ConfigurationManager.ConnectionStrings["FacultyDBConnectionString"].ConnectionString;


                // 3. Define the SQL INSERT query
                // Using parameters (@ParamName) to prevent SQL Injection attacks
                string query = "INSERT INTO FacultyProfiles (EmployeeID, FullName, Department, HighestQualification, Specialization, Experience, Email, Mobile, DateCreated) " +
                               "VALUES (@EmployeeID, @FullName, @Department, @HighestQualification, @Specialization, @Experience, @Email, @Mobile, @DateCreated)";

                // 4. Create and open a connection
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // 5. Add parameters and their values
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@Department", ddlDepartment.SelectedValue);
                        cmd.Parameters.AddWithValue("@HighestQualification", txtQualification.Text);
                        cmd.Parameters.AddWithValue("@Specialization", string.IsNullOrWhiteSpace(txtSpecialization.Text) ? (object)DBNull.Value : txtSpecialization.Text);
                        cmd.Parameters.AddWithValue("@Experience", string.IsNullOrWhiteSpace(txtExperience.Text) ? (object)DBNull.Value : Convert.ToInt32(txtExperience.Text));
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Mobile", string.IsNullOrWhiteSpace(txtMobile.Text) ? (object)DBNull.Value : txtMobile.Text);
                        cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);

                        try
                        {
                            con.Open();
                            // 6. Execute the query
                            cmd.ExecuteNonQuery();

                            // 7. Show success message
                            lblMessage.Text = $"Profile created successfully! Your Employee ID is: {employeeId}";
                            lblMessage.ForeColor = System.Drawing.Color.Green;

                            // 8. Clear the form
                            ClearForm();
                        }
                        // --- PUT THIS CODE BACK WHEN YOU ARE FINISHED DEBUGGING ---
                        catch (SqlException ex)
                        {
                            // Handle potential SQL errors, like a duplicate email
                            if (ex.Number == 2627 || ex.Number == 2601) // Unique key violation
                            {
                                lblMessage.Text = "Error: A profile with this email address already exists.";
                            }
                            else
                            {
                                lblMessage.Text = "A database error occurred. Please try again.";
                            }
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
        }

        private string GetInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "XX";

            var initials = new System.Text.StringBuilder();
            var parts = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                initials.Append(part[0]);
            }
            return initials.ToString().ToUpper();
        }

        private void ClearForm()
        {
            txtFullName.Text = string.Empty;
            ddlDepartment.SelectedIndex = 0;
            txtQualification.Text = string.Empty;
            txtSpecialization.Text = string.Empty;
            txtExperience.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
        }
    }
}