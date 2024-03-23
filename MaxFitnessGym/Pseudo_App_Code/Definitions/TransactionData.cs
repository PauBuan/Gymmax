using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace MaxFitnessGym.App_Code {
    public class TransactionData {
        public static List<TransactionData> List { get; set; } = new List<TransactionData>();
        public string ID { get; set; }
        public int CustomerID { get; set; }
        public int SubscriptionID { get; set; }
        public string DateOfPurchase { get; set; }
        public TransactionData(string ID, int CustomerID, int SubscriptionID, string DateOfPurchase) {
            this.ID = ID;
            this.CustomerID = CustomerID;
            this.SubscriptionID = SubscriptionID;
            this.DateOfPurchase = DateOfPurchase;
            List.Add(this);
        }
        public static void Fetch(string sqlCommand) {
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{HostingEnvironment.MapPath("/")}App_Data\GymDB.mdf"";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString)) using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();                                                                      //Open Connection
                command.CommandText = sqlCommand;                                                       //Command
                List = command.ExecuteReader().Cast<IDataRecord>().Select(row => new TransactionData(   //Read Data and cast
                    (string)    row["ID"],
                    (int)       row["Customer"],
                    (int)       row["Subscription"],
                    (string)    row["DateOfPurchase"].ToString()
                )).ToList();                                                                            //Convert to List<CustomerData>
                connection.Close();                                                                     //Close Connection
            }
        }
    }
}