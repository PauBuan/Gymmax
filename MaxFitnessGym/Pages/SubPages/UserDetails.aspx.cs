using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxFitnessGym
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve user ID from query string
                if (!string.IsNullOrEmpty(Request.QueryString["userID"]))
                {
                    string userID = Request.QueryString["userID"];
                    DisplayUserDetails(userID);
                }
            }
        }

        private void DisplayUserDetails(string userID)
        {
            // Define connection string
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GymDB.mdf;Integrated Security=True";

            // Define SQL query to retrieve user details
            string query = "SELECT c.ID, c.LastName, c.FirstName, c.PhoneNumber, t.DateOfPurchase, s.SubscriptionName, s.Duration " +
                           "FROM Customer c " +
                           "JOIN Transactions t ON c.ID = t.Customer " +
                           "JOIN Subscription s ON t.Subscription = s.ID " +
                           "WHERE c.ID = @UserID";



            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set parameter
                    command.Parameters.AddWithValue("@UserID", userID);

                    // Open connection
                    connection.Open();

                    // Execute the query
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if data exists
                    if (reader.Read())
                    {
                        // Display user details
                        lblID.Text = reader["ID"].ToString();
                        lblLastName.Text = reader["LastName"].ToString();
                        lblFirstName.Text = reader["FirstName"].ToString();
                        lblPhoneNumber.Text = reader["PhoneNumber"].ToString();
                        lblDateOfPurchase.Text = Convert.ToDateTime(reader["DateOfPurchase"]).ToString("MM/dd/yyyy");
                        lblSubscription.Text = reader["SubscriptionName"].ToString();
                        lblDuration.Text = reader["Duration"].ToString();
                    }
                    else
                    {
                        // User not found
                        Response.Redirect("~/Pages/SubPages/Customer.aspx?error=UserNotFound");
                    }

                    // Close reader
                    reader.Close();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/LogIn/logIn.aspx");
        }
    }
}