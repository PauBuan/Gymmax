using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxFitnessGym.Pages.LogIn
{
    public partial class logIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Check if the entered credentials match the admin credentials
            if (username == "admin" && password == "admin123")
            {
                // Redirect to the admin homepage
                Response.Redirect("/Pages/SubPages/tryHomePage.aspx");
                return;
            }

            // Define connection string
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GymDB.mdf;Integrated Security=True";

            // SQL query to retrieve user ID based on username and password from userpass table
            string query = "SELECT ID FROM userpass WHERE ID = @ID AND Password = @Password";

            // Variable to store the user ID
            string userID = "";

            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@ID", username); // Assuming username corresponds to user ID
                    command.Parameters.AddWithValue("@Password", password);

                    // Open the connection
                    connection.Open();

                    // Execute the command
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if any rows are returned
                        if (reader.Read())
                        {
                            // Retrieve the user ID
                            userID = reader["ID"].ToString();
                        }
                    }
                }
            }

            // Check if user ID is retrieved
            if (!string.IsNullOrEmpty(userID))
            {
                // Redirect to UserDetails page with the user ID as query string parameter
                Response.Redirect($"/Pages/SubPages/UserDetails.aspx?userID={userID}");
            }
            else
            {
                // Invalid login, display alert
                ClientScript.RegisterStartupScript(this.GetType(), "invalidLogin", "alert('Invalid username or password.');", true);
            }
        }



    }
}