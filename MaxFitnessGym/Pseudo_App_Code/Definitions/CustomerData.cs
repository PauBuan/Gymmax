using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Xml.Linq;
using System.Diagnostics;
using System.Web.Hosting;

namespace MaxFitnessGym.App_Code {
    public class CustomerData {
        public static List<CustomerData> List { get; set; } = new List<CustomerData>();
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public long PhoneNumber { get; set; }
        public CustomerData(int ID, string LastName, string FirstName, long PhoneNumber) {
            this.ID = ID;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.PhoneNumber = PhoneNumber;
            List.Add(this);
        }
        public static void Fetch(string sqlCommand) {
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{HostingEnvironment.MapPath("/")}App_Data\GymDB.mdf"";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString)) using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();                                                                  //Open Connection
                command.CommandText = sqlCommand;                                                   //Command
                List = command.ExecuteReader().Cast<IDataRecord>().Select(row => new CustomerData(  //Read Data and cast
                    (int)       row["ID"],
                    (string)    row["LastName"],
                    (string)    row["FirstName"],
                    (long)      row["PhoneNumber"]
                )).ToList();                                                                        //Convert to List<CustomerData>
                connection.Close();                                                                 //Close Connection
            }
        }
        public void Delete() {
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{HostingEnvironment.MapPath("/")}App_Data\GymDB.mdf"";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString)) using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();                                                                  //Open Connection
                command.CommandText = $"DELETE FROM Customer WHERE ID = {ID}";                      //Command
                command.ExecuteNonQuery();
                connection.Close();                                                                 //Close Connection
            }
            Fetch("SELECT * FROM Customer ORDER BY FirstName DESC");
        }
    }
}