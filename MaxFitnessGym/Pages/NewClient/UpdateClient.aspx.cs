using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxFitnessGym
{
    public partial class UpdateClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Ensure the initial panel is visible
                pnlEnterID.Visible = true;
                pnlUpdateClient.Visible = false;
            }
        }

        protected void btnEnterID_Click(object sender, EventArgs e)
        {
            
            // Define connection string
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{HostingEnvironment.MapPath("/")}App_Data\GymDB.mdf"";Integrated Security=True";

            // Define the SQL query for fetching client information including subscription from Transactions table
            string query = "SELECT c.LastName, c.FirstName, c.PhoneNumber, t.Subscription " +
                           "FROM Customer c " +
                           "INNER JOIN Transactions t ON c.ID = t.Customer " +
                           "WHERE c.ID = @ID";

            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    int clientId = Convert.ToInt32(txtEnterID.Text);

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", clientId);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // Populate the update form with fetched client information
                            txtLastName.Text = reader["LastName"].ToString();
                            txtFirstName.Text = reader["FirstName"].ToString();
                            txtPhone.Text = reader["PhoneNumber"].ToString();
                            ddlSubscription.SelectedValue = reader["Subscription"].ToString();

                            // Show the update form panel
                            pnlEnterID.Visible = false;
                            pnlUpdateClient.Visible = true;
                        }
                        else
                        {
                            // Client not found, display error message
                            lblIDError.Text = "Client not found.";
                            lblIDError.Visible = true;
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    lblIDError.Text = "Error: " + ex.Message;
                    lblIDError.Visible = true;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect the user back to the previous page
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/SubPages/Customer.aspx");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Define connection string
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{HostingEnvironment.MapPath("/")}App_Data\GymDB.mdf"";Integrated Security=True";

            // Define the SQL query for updating client information
            string updateCustomerQuery = "UPDATE Customer SET LastName = @LastName, FirstName = @FirstName, PhoneNumber = @PhoneNumber WHERE ID = @ID";

            // Define the SQL query for updating subscription information
            string updateSubscriptionQuery = "UPDATE Transactions SET Subscription = @Subscription WHERE Customer = @ID";

            // Define the SQL query for updating the password
            string updatePasswordQuery = "UPDATE userpass SET Password = @Password WHERE ID = @ID";

            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    int clientId = Convert.ToInt32(txtEnterID.Text);

                    // Check if PhoneNumber is 11 digits
                    if (!IsPhoneNumberValid(txtPhone.Text))
                    {
                        lblUpdateError.Text = "Phone number must be exactly 11 digits.";
                        lblUpdateError.Visible = true;
                        return;
                    }

                    // Update client information
                    using (SqlCommand command = new SqlCommand(updateCustomerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", clientId);
                        command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        command.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            lblUpdateError.Text = "Client not found.";
                            lblUpdateError.Visible = true;
                            return;
                        }
                    }

                    // Update subscription information
                    using (SqlCommand command = new SqlCommand(updateSubscriptionQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", clientId);
                        command.Parameters.AddWithValue("@Subscription", ddlSubscription.SelectedValue);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            // Handle the case where the client does not have a subscription in the Transactions table
                            // You may want to insert a new transaction record instead
                        }
                    }

                    // Update password
                    using (SqlCommand command = new SqlCommand(updatePasswordQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", clientId);
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            // Handle the case where the client does not have a password in the userpass table
                            // You may want to insert a new password record instead
                        }
                    }

                    // Both updates were successful
                    lblUpdateError.Text = "Client information updated successfully.";
                    lblUpdateError.Visible = true;
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    lblUpdateError.Text = "Error: " + ex.Message;
                    lblUpdateError.Visible = true;
                }
            }

        }

        // Method to validate phone number format
        private bool IsPhoneNumberValid(string phoneNumber)
        {
            return phoneNumber.Length == 11 && phoneNumber.All(char.IsDigit);
        }


    }
}