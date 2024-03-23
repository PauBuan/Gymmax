using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace MaxFitnessGym.App_Code {
    public class SubscriptionData {
        public static List<SubscriptionData> List { get; set; } = new List<SubscriptionData>();
        public int ID { get; set; }
        public string Name { get; set; }
        public string Payment { get; set; }
        public int Duration { get; set; }
        public SubscriptionData(int ID, string Name, string Payment, int Duration) {
            this.ID = ID;
            this.Name = Name;
            this.Payment = Payment;
            this.Duration = Duration;
            List.Add(this);
        }
        public static void Fetch(string sqlCommand) {
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{HostingEnvironment.MapPath("/")}App_Data\GymDB.mdf"";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString)) using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();                                                                      //Open Connection
                command.CommandText = sqlCommand;                                                       //Command
                List = command.ExecuteReader().Cast<IDataRecord>().Select(row => new SubscriptionData(  //Read Data and cast
                    (int)       row["ID"],
                    (string)    row["SubscriptionName"],
                    (string)    row["Payment"].ToString(),
                    (int)       row["Duration"]
                )).ToList();                                                                            //Convert to List<CustomerData>
                connection.Close();                                                                     //Close Connection
            }
        }
    }
}