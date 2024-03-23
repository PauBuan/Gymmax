using System;
using System.Data.SqlClient;
using System.Web.Hosting;

namespace MaxFitnessGym
{
    public partial class NewClient : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Length != 11)
            {
                lblMessage.Text = "Phone number must be exactly 11 digits.";
                return;
            }
            // Define connection string
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{HostingEnvironment.MapPath("/")}App_Data\GymDB.mdf"";Integrated Security=True";

            // Define the SQL query for inserting into the Customer table
            string customerQuery = "INSERT INTO Customer (ID, LastName, FirstName, PhoneNumber) VALUES (@ID, @LastName, @FirstName, @PhoneNumber)";

            // Define the SQL query for inserting into the Transaction table
            string transactionQuery = "INSERT INTO [Transactions] (ID, Customer, Subscription, DateOfPurchase) VALUES (@ID, @Customer, @Subscription, @DateOfPurchase)";

            // Define the SQL query for inserting into the userpass table
            string userpassQuery = "INSERT INTO userpass (ID, Password) VALUES (@ID, @Password)";

            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Start a transaction
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    int customerId;
                    using (SqlCommand command = new SqlCommand(customerQuery, connection, transaction))
                    {
                        // Generate a unique ID for customer
                        int generatedCustomerId = GenerateUniqueID();
                        command.Parameters.AddWithValue("@ID", generatedCustomerId);
                        command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        command.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);

                        // Execute the query
                        command.ExecuteNonQuery();

                        // Set the generated customer ID
                        customerId = generatedCustomerId;
                    }

                    // Generate a unique ID for transaction
                    string transactionId = GenerateTransactionID();

                    // Get subscription ID from the dropdown
                    int subscriptionId = int.Parse(ddlSubscription.SelectedValue);

                    // Get current date and time for DateOfPurchase
                    DateTime dateOfPurchase = GetCurrentDateTime();

                    // Insert into Transaction table
                    using (SqlCommand command = new SqlCommand(transactionQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@ID", transactionId);
                        command.Parameters.AddWithValue("@Customer", customerId);
                        command.Parameters.AddWithValue("@Subscription", subscriptionId);
                        command.Parameters.AddWithValue("@DateOfPurchase", dateOfPurchase);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }

                    // Insert into userpass table
                    using (SqlCommand command = new SqlCommand(userpassQuery, connection, transaction))
                    {
                        // Pass the generated customer ID and the password from the textbox
                        command.Parameters.AddWithValue("@ID", customerId);
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }

                    // Commit the transaction
                    transaction.Commit();

                    // Display success message
                    lblMessage.Text = "New client added successfully with ID: " + customerId + " and TransactionID: " + transactionId;
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if an error occurs
                    transaction.Rollback();

                    // Handle exceptions
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }


        // Method to generate a unique ID for customer
        private int GenerateUniqueID()
        {
            // Use a combination of timestamp and randomness to generate a unique ID
            // This is just a sample implementation, replace it with your own logic
            Random random = new Random();
            return (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + random.Next(1000, 9999);
        }

        // Method to generate a random Transaction ID with the specified format
        private string GenerateTransactionID()
        {
            // Generate a random number and concatenate it with "T"
            Random random = new Random();
            int randomNumber = random.Next(1000, 9999);
            return "T" + randomNumber;
        }

        // Method to get the current date and time
        private DateTime GetCurrentDateTime()
        {
            return DateTime.UtcNow;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/SubPages/Customer.aspx");
        }

    }
}
