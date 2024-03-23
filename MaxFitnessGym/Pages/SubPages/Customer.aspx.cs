using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaxFitnessGym.App_Code;

namespace MaxFitnessGym {
    public partial class Customer : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            CustomerData.Fetch((txtSearch.Text == string.Empty) ? "SELECT * FROM Customer ORDER BY FirstName DESC" : $"SELECT * FROM Customer WHERE FirstName LIKE \'%{txtSearch.Text}%\' OR LastName LIKE \'%{txtSearch.Text}%\'");
        }
        protected void btnNewClient_Click(object sender, EventArgs e) {
            Response.Redirect("~/Pages/NewClient/NewClient.aspx");
        }
        protected void btnUpdate_Click(object sender, EventArgs e) {
            Response.Redirect("~/Pages/NewClient/UpdateClient.aspx");
        }
        protected void btnDelete_Click(object sender, EventArgs e) {
            Response.Redirect("~/Pages/NewClient/DeleteClient.aspx");
        }


    }
}