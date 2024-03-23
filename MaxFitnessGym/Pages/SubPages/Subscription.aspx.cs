
using MaxFitnessGym.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxFitnessGym {
    public partial class Subscription : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            SubscriptionData.Fetch((txtSearch.Text == string.Empty) ? "SELECT * FROM Subscription ORDER BY Duration DESC" : $"SELECT * FROM Subscription WHERE SubscriptionName LIKE \'%{txtSearch.Text}%\'");
        }
    }
}