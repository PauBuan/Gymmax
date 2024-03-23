using MaxFitnessGym.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxFitnessGym
{
    public partial class Transaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TransactionData.Fetch((txtSearch.Text == string.Empty) ? "SELECT * FROM Transactions ORDER BY DateOfPurchase DESC" : $"SELECT * FROM Transactions WHERE Customer LIKE \'%{txtSearch.Text}%\' OR Subscription LIKE \'%{txtSearch.Text}%\'");
        }
    }
}
